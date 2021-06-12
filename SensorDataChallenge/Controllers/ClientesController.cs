using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SensorDataChallenge.Database;
using SensorDataChallenge.Models;
using SensorDataChallenge.Models.Enum;

namespace SensorDataChallenge.Controllers
{
    public class ClientesController : Controller
    {
        private readonly SensorDataDBContext _context;

        public ClientesController(SensorDataDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var sensorDataDBContext = _context.Clientes.Include(c => c.Seguro);
            return View(await sensorDataDBContext.ToListAsync());
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .Include(c => c.Seguro)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            Zona zona = new Zona();
            ViewData["Paises"] = new SelectList(CountryList().OrderBy(p => p.Value), "Key", "Value");
            //If you do have an enum value use the value (the value will be marked as selected)
            ////ViewBag.DropDownList = EnumHelper.SelectListFor(myEnumValue);
            //ViewData["Zona"] = System.Enum.GetValues(typeof(Zona));
            ViewData["Zona"] = new SelectList(GetZoneList(), "Value", "Text");
            ViewData["SeguroId"] = new SelectList(_context.Seguros, "Id", "Id");
            return View();
        }

        public static List<SelectListItem> GetZoneList()
        {
            Array values = Enum.GetValues(typeof(Zona));
            //List<SelectListItem> items = new List<SelectListItem>(values.Length);
            List<SelectListItem> items = new List<SelectListItem>(values.Length);



            foreach (var i in values)
            {
                string Nombre = Enum.GetName(typeof(Zona), i);
                items.Add(new SelectListItem() { Text = Nombre, Value = i.ToString() });
                //items.Add(new SelectListItem() { Text = Nombre.ToString(), Value = ((int)i).ToString()});
                items[0].ToString();

            }

            return items;
        }

        public static Dictionary<string, string> CountryList()
        {
            Dictionary<string, string> cultureList = new Dictionary<string, string>();
            CultureInfo[] getCultureInfo = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

            foreach (CultureInfo getCulture in getCultureInfo)
            {
                RegionInfo getRegionInfo = new RegionInfo(getCulture.LCID);
                if (!(cultureList.ContainsKey(getRegionInfo.Name)))
                {
                    cultureList.Add(getRegionInfo.Name, getRegionInfo.EnglishName);
                }
            }
            return cultureList;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RazonSocial,NroRuc,Direccion,Pais,Ciudad,CodigoPostal,Zona,Telefono,Fax,Email,Web,SeguroId,Activo")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                cliente.Id = Guid.NewGuid();
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SeguroId"] = new SelectList(_context.Seguros, "Id", "Id", cliente.SeguroId);
            return View(cliente);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            ViewData["SeguroId"] = new SelectList(_context.Seguros, "Id", "Id", cliente.SeguroId);
            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,RazonSocial,NroRuc,Direccion,Pais,Ciudad,CodigoPostal,Zona,Telefono,Fax,Email,Web,SeguroId,Activo")] Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["SeguroId"] = new SelectList(_context.Seguros, "Id", "Id", cliente.SeguroId);
            return View(cliente);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .Include(c => c.Seguro)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(Guid id)
        {
            return _context.Clientes.Any(e => e.Id == id);
        }
    }
}

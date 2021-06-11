using SensorDataChallenge.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SensorDataChallenge.Models
{
    public class Cliente
    {
        public string RazonSocial { get; set; }
        public int NroRuc { get; set; }
        public string Direccion { get; set; }
        public string[] Pais { get; set; }
        public string Ciudad { get; set; }
        public int CodigoPostal { get; set; }
        public string Zona { get; set; }
        public string Telefono { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Web { get; set; }
        public Seguro Seguro { get; set; }
        public bool Activo { get; set; }
    }
}

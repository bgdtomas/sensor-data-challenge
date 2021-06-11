using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SensorDataChallenge.Models
{
    public class Usuario
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Cliente Cliente { get; set; }
        public enum Permisos { get; set; }

    }
}

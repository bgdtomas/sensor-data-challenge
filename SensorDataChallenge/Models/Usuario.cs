using SensorDataChallenge.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SensorDataChallenge.Models
{
    public class Usuario
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage ="Este campo es requerido.")]
        [MaxLength(50, ErrorMessage = "La longitud del campo es de 50 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Este campo es requerido.")]
        [MaxLength(200, ErrorMessage = "La longitud del campo es de 200 caracteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Este campo es requerido.")]
        [MaxLength(50, ErrorMessage = "La longitud del campo es de 50 caracteres")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Este campo es requerido.")]
        [MaxLength(50, ErrorMessage = "La longitud del campo es de 50 caracteres")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Este campo es requerido.")]
        public Cliente Cliente { get; set; }
        
        [Required(ErrorMessage = "Este campo es requerido.")]
        public Permisos Permisos { get; set; }

    }
}

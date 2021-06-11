using SensorDataChallenge.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SensorDataChallenge.Models
{
    public class Cliente
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Este campo es requerido.")]
        [MaxLength(50, ErrorMessage = "La longitud del campo es de 50 caracteres")]
        public string RazonSocial { get; set; }

        [Required(ErrorMessage = "Este campo es requerido.")]
        [MaxLength(50, ErrorMessage = "La longitud del campo es de 50 caracteres")]
        public int NroRuc { get; set; }

        [Required(ErrorMessage = "Este campo es requerido.")]
        [MaxLength(50, ErrorMessage = "La longitud del campo es de 50 caracteres")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Este campo es requerido.")]
        public string Pais { get; set; }

        [Required(ErrorMessage = "Este campo es requerido.")]
        [MaxLength(50, ErrorMessage = "La longitud del campo es de 50 caracteres")]
        public string Ciudad { get; set; }

        [Required(ErrorMessage = "Este campo es requerido.")]
        [MaxLength(50, ErrorMessage = "La longitud del campo es de 50 caracteres")]
        public int CodigoPostal { get; set; }

        [Required(ErrorMessage = "Este campo es requerido.")]
        public string Zona { get; set; }

        [Required(ErrorMessage = "Este campo es requerido.")]
        [MaxLength(50, ErrorMessage = "La longitud del campo es de 50 caracteres")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Este campo es requerido.")]
        [MaxLength(50, ErrorMessage = "La longitud del campo es de 50 caracteres")]
        public string Fax { get; set; }

        [Required(ErrorMessage = "Este campo es requerido.")]
        [MaxLength(50, ErrorMessage = "La longitud del campo es de 50 caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Este campo es requerido.")]
        [MaxLength(50, ErrorMessage = "La longitud del campo es de 50 caracteres")]
        public string Web { get; set; }

        [ForeignKey(nameof(Seguro))]
        public Guid SeguroId { get; set; }
        public Seguro Seguro { get; set; }
        public bool Activo { get; set; } = true;
    }
}

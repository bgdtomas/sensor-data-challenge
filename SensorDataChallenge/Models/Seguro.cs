using SensorDataChallenge.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SensorDataChallenge.Models
{
    public class Seguro
    {
        [Key]
        public Guid Id { get; set; }
        public Transitos Uruguay { get; set; }
        public Transitos UruguayCargaSuelta { get; set; }
    }
}

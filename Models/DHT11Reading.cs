using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class DHT11Reading
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime TimeOfReading { get; set; }
        [Required]
        public float HumidityValue { get; set; }
        [Required]
        public float TempValue { get; set; }
        [Required]
        public int HumidityUpperThreshold { get; set; }
        [Required]
        public int HumidityLowerThreshold { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class C2DUpdateEvent
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime UpdatedAtTime { get; set; }
        [Required]
        [ForeignKey("IdentityUser")]
        public string UpdatedDoneBy { get; set; }
        public virtual IdentityUser? IdentityUser { get; set; }
        [Required]
        public string UpdateType { get; set; }
        [Required]
        public int UpperThreshold { get; set; }
        [Required]
        public int LowerThreshold { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetASP.NET.Models
{
    public class Travaux
    {
        [Key]
        public int idTravaux { get; set; }
        [Required]
        public String Nom { get; set; }
        [Required]
        public String Description { get; set; }
        [Required]
        public String Type { get; set; }
        [Required]
        public String DateDelai { get; set; }

        public String File { get; set; }

        public int IdElement { get; set; }
        [ForeignKey("IdElement")]
        public Element Element { get; set; }

    }
}

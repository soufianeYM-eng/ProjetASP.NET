using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetASP.NET.Models
{
    public class Seance
    {
        [Key]
        public int idSeance { get; set; }
        [Required]
        public string Nom { get; set; }
        [Required]
        public string LienSeance { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public int IdElement { get; set; }
        [ForeignKey("IdElement")]
        public Element Element { get; set; }


    }
}

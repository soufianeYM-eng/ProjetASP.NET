using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetASP.NET.Models
{
    public class Module
    {
        [Key]
        public int IdModule { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Nom { get; set; }

        public int IdFil { get; set; }
        [ForeignKey("IdFil")]
        public Filiere Filiere { get; set; }
    }
}

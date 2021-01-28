using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetASP.NET.Models
{
    public class Filiere
    {
        [Key]
        public int IdFil { get; set; }
        [Required]
        public string Nom { get; set; }
        [Required]
        public string Abrev { get; set; }
    }
}

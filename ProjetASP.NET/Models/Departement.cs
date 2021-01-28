using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetASP.NET.Models
{
    public class Departement
    {
        [Key]
        public int IdDept { get; set; }
        [Required]
        public string Nom { get; set; }
    }
}

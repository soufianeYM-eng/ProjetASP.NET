using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetASP.NET.Models
{
    public class Element
    {
        [Key]
        public int IdElement { get; set; }
        [Required]
        public string Nom { get; set; }
        [Required]
        public float pourcentage { get; set; }

        public int IdModule { get; set; }
        [ForeignKey("IdModule")]
        public Module Module { get; set; }

        public string userId { get; set; }


    }
}

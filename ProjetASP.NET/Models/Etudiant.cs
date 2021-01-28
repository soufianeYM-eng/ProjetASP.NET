using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetASP.NET.Models
{
    public class Etudiant
    {
        [Key]
        public int CodeApogee { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }

        public int IdFil { get; set; }
        [ForeignKey("IdFil")]
        public Filiere Filiere { get; set; }
        [Required]
        public int Année { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetASP.NET.Models
{
    public class Travail
    {
        [Key]
        public int idTravail { get; set; }
        [Required]
        public String Nom { get; set; }
        [Required]
        public String DateRemis { get; set; }

        public double Note { get; set; }

        public int idTravaux { get; set; }
        [ForeignKey("idTravaux")]
        public Travaux Travaux { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }

    }
}

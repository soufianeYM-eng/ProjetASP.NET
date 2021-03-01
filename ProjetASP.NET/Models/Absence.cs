using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetASP.NET.Models
{
    public class Absence
    {
        [Key]
        public int idAbsence { get; set; }
        
        public int idSeance { get; set; }
        [ForeignKey("idSeance")]
        public Seance seance { get; set; }

        public string idEtudiant { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }

    }
}

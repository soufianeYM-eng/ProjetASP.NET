using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetASP.NET.Models
{
    public class NoteElement
    {
        [Key]
        public int idNote { get; set; }

        [Required]
        public double note { get; set; }

        public int IdElement { get; set; }
        [ForeignKey("IdElement")]
        public Element Element { get; set; }

        public string idEtudiant { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }
    }
}

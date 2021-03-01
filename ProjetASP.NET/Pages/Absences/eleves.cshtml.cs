using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjetASP.NET.Data;
using ProjetASP.NET.Models;

namespace ProjetASP.NET.Pages.Absences
{
    public class elevesModel : PageModel
    {
        private readonly ApplicationDbContext db;

        public elevesModel(ApplicationDbContext db)
        {
            this.db = db;
        }

        [BindProperty]
        public IList<ApplicationUser> Etudiants { get; set; }

        [BindProperty]
        public string idEleve { get; set; }

        [BindProperty]
        public string abs { get; set; }

        public Module Module { get; set; }
        public Element Element { get; set; }
        public ApplicationUser Etudiant { get; set; }

        [BindProperty]
        public Absence absences { get; set; }
        [BindProperty]
        public Seance seance { get; set; }
        [BindProperty]
        public Absence absence { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            absence = new Absence();
            absence.idSeance = id;
            seance = await db.Seances.Where(m => m.idSeance == id).FirstAsync();
            Element = await db.Elements.Where(m => m.IdElement == seance.IdElement).FirstAsync();
            Module = await db.Modules.Where(m => m.IdModule == Element.IdModule).FirstAsync();
            Etudiants = await db.ApplicationUsers.Where(m => m.IdFil == Module.IdFil).ToListAsync();
            Etudiant = await db.ApplicationUsers.Where(m => m.IdFil == Module.IdFil).FirstAsync();
            absences = await db.Absences.Where(m => m.idEtudiant == Etudiant.Id).FirstAsync();

            if(absences != null)
            {
                abs = "Oui";
            }

            absence.idEtudiant = Etudiant.Id;
            
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if(abs == "Oui")
            {
                await db.Absences.AddAsync(absence);
                await db.SaveChangesAsync();
            }
            else
            {
                var absenceObj = await db.Absences.FindAsync(absence.idAbsence);
                db.Absences.Remove(absenceObj);
                await db.SaveChangesAsync();
            }

            return RedirectToPage("eleves", new { id = absence.idSeance });
        }
    }
}

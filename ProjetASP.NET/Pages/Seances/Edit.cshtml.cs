using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetASP.NET.Data;
using ProjetASP.NET.Models;
using ProjetASP.NET.Utility;

namespace ProjetASP.NET.Pages.Seances
{
    [Authorize(Roles = SD.ProfessorEndUser)]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext db;

        public EditModel(ApplicationDbContext db)
        {
            this.db = db;
        }

        [BindProperty]
        public Seance seance { get; set; }


        [TempData]
        public string StatusMessage { get; set; }


        public async Task<IActionResult> OnGet(int id)
        {
            seance = await db.Seances.FindAsync(id);


            return Page();

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var seanceObj = await db.Seances.FindAsync(seance.idSeance);
                seanceObj.Nom = seance.Nom;
                seanceObj.LienSeance = seance.LienSeance;
                seanceObj.Date = seance.Date;
                await db.SaveChangesAsync();
                StatusMessage = "Séance modifier avec succès";
                return RedirectToPage("Index", new { IdElement = seance.IdElement });
            }
            return Page();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetASP.NET.Data;
using ProjetASP.NET.Models;

namespace ProjetASP.NET.Pages.TravailPROF
{
    public class NoteModel : PageModel
    {
        private readonly ApplicationDbContext db;

        public NoteModel(ApplicationDbContext db)
        {
            this.db = db;
        }

        [BindProperty]
        public Travail Travail { get; set; }


        [TempData]
        public string StatusMessage { get; set; }


        public async Task<IActionResult> OnGet(int id)
        {
            Travail = await db.Travails.FindAsync(id);


            return Page();

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var travailObj = await db.Travails.FindAsync(Travail.idTravail);
                travailObj.idTravail = Travail.idTravail;
                travailObj.Note = Travail.Note;
                await db.SaveChangesAsync();
                StatusMessage = "Element modifier avec succès";
                return RedirectToPage("Lister", new { IdTravaux = Travail.idTravaux });
            }
            return Page();
        }
    }
}

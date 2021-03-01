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
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext db;

        public DeleteModel(ApplicationDbContext db)
        {
            this.db = db;
        }

        [BindProperty]
        public Travaux Travaux { get; set; }


        [TempData]
        public string StatusMessage { get; set; }


        public async Task<IActionResult> OnGet(int id)
        {
            Travaux = await db.Travaux.FindAsync(id);

            return Page();

        }

        public async Task<IActionResult> OnPost()
        {

            var TravailObj = await db.Travaux.FindAsync(Travaux.idTravaux);
            db.Travaux.Remove(TravailObj);
            await db.SaveChangesAsync();
            StatusMessage = "Travail supprimer avec succès";
            return RedirectToPage("Index", new { IdElement = Travaux.IdElement });
        }
    }
}

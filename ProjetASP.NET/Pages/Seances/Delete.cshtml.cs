using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetASP.NET.Data;
using ProjetASP.NET.Models;

namespace ProjetASP.NET.Pages.Seances
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext db;

        public DeleteModel(ApplicationDbContext db)
        {
            this.db = db;
        }

        [BindProperty]
        public Seance Seance { get; set; }


        [TempData]
        public string StatusMessage { get; set; }


        public async Task<IActionResult> OnGet(int id)
        {
            Seance = await db.Seances.FindAsync(id);

            return Page();

        }

        public async Task<IActionResult> OnPost()
        {

            var SeanceObj = await db.Seances.FindAsync(Seance.idSeance);
            db.Seances.Remove(SeanceObj);
            await db.SaveChangesAsync();
            StatusMessage = "Seance supprimer avec succès";
            return RedirectToPage("Index", new { IdElement = Seance.IdElement });
        }
    }
}

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
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext db;

        public CreateModel(ApplicationDbContext db)
        {
            this.db = db;
        }

        [BindProperty]
        public Seance Seance { get; set; }


        [TempData]
        public string StatusMessage { get; set; }


        public async Task<IActionResult> OnGet(int IdElement)
        {
            Seance = new Seance();
            Seance.IdElement = IdElement;
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await db.Seances.AddAsync(Seance);
                await db.SaveChangesAsync();
                StatusMessage = "Ajout réussi avec succès";
                return RedirectToPage("Index", new { IdElement = Seance.IdElement });
            }
            return Page();
        }
    }
}

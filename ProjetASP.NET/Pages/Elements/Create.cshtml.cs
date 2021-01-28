using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetASP.NET.Data;
using ProjetASP.NET.Models;

namespace ProjetASP.NET.Pages.Elements
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext db;

        public CreateModel(ApplicationDbContext db)
        {
            this.db = db;
        }

        [BindProperty]
        public Element Element { get; set; }


        [TempData]
        public string StatusMessage { get; set; }


        public async Task<IActionResult> OnGet(int IdModule)
        {
            Element = new Element();
            Element.IdModule = IdModule;
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await db.Elements.AddAsync(Element);
                await db.SaveChangesAsync();
                StatusMessage = "Ajout réussi avec succès";
                return RedirectToPage("Index",new { IdModule = Element.IdModule});
            }
            return Page();
        }
    }
}

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
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext db;

        public DeleteModel(ApplicationDbContext db)
        {
            this.db = db;
        }

        [BindProperty]
        public Element Element { get; set; }


        [TempData]
        public string StatusMessage { get; set; }


        public async Task<IActionResult> OnGet(int id)
        {
            Element = await db.Elements.FindAsync(id);

            return Page();

        }

        public async Task<IActionResult> OnPost()
        {
            
            var elementObj = await db.Elements.FindAsync(Element.IdElement);
            db.Elements.Remove(elementObj);
            await db.SaveChangesAsync();
            StatusMessage = "Element supprimer avec succès";
            return RedirectToPage("Index", new { IdModule = Element.IdModule });
        }
    }
}

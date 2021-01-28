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
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext db;

        public EditModel (ApplicationDbContext db)
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
            if (ModelState.IsValid)
            {
                var elementObj = await db.Elements.FindAsync(Element.IdElement);
                elementObj.Nom = Element.Nom;
                elementObj.pourcentage = Element.pourcentage;
                await db.SaveChangesAsync();
                StatusMessage = "Element modifier avec succ�s";
                return RedirectToPage("Index", new { IdModule = Element.IdModule });
            }
            return Page();
        }
    }
}

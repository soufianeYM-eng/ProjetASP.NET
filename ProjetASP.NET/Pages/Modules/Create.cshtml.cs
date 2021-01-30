using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetASP.NET.Data;
using ProjetASP.NET.Models;
using ProjetASP.NET.Utility;

namespace ProjetASP.NET.Pages.Modules
{
    [Authorize(Roles = SD.AdminEndUser)]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext db;

        public CreateModel(ApplicationDbContext db)
        {
            this.db = db;
        }

        [BindProperty]
        public Module Module { get; set; }


        [TempData]
        public string StatusMessage { get; set; }


        public async Task<IActionResult> OnGet(int IdFil)
        {
            Module = new Module();
            Module.IdFil = IdFil;
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await db.Modules.AddAsync(Module);
                await db.SaveChangesAsync();
                StatusMessage = "Ajout réussi avec succès";
                return RedirectToPage("Index", new { IdFil = Module.IdFil });
            }
            return Page();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetASP.NET.Data;
using ProjetASP.NET.Models;
using ProjetASP.NET.Utility;

namespace ProjetASP.NET.Pages.Modules
{
    [Authorize(Roles = SD.AdminEndUser)]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext db;

        public EditModel(ApplicationDbContext db)
        {
            this.db = db;
        }

        [BindProperty]
        public Module Module { get; set; }


        [TempData]
        public string StatusMessage { get; set; }


        public async Task<IActionResult> OnGet(int id)
        {
            Module = await db.Modules.FindAsync(id);


            return Page();

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var moduleObj = await db.Modules.FindAsync(Module.IdModule);
                moduleObj.Code = Module.Code;
                moduleObj.Nom = Module.Nom;
                await db.SaveChangesAsync();
                StatusMessage = "Element modifier avec succès";
                return RedirectToPage("Index", new { IdFil = Module.IdFil });
            }
            return Page();
        }
    }
}

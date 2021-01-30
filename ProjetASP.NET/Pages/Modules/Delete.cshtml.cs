using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjetASP.NET.Data;
using ProjetASP.NET.Models;
using ProjetASP.NET.Utility;

namespace ProjetASP.NET.Pages.Modules
{
    [Authorize(Roles = SD.AdminEndUser)]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext db;

        public DeleteModel(ApplicationDbContext db)
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

            var ModuleObj = await db.Modules.FindAsync(Module.IdModule);
            db.Modules.Remove(ModuleObj);
            await db.SaveChangesAsync();
            StatusMessage = "Element supprimer avec succès";
            return RedirectToPage("Index", new { IdFil = Module.IdFil });
        }
    }
}

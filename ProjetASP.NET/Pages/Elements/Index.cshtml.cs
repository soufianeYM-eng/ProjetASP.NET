using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjetASP.NET.Data;
using ProjetASP.NET.Models.ViewModels;

namespace ProjetASP.NET.Pages.Elements
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext db;

        public IndexModel(ApplicationDbContext db)
        {
            this.db = db;
        }

        public ModuleEtElementsViewModel ModulesEtElementsVM { get; set; }

        [TempData]
        public string StatusMessage { get; set; }


        public async Task<IActionResult> OnGet(int IdModule)
        {
            ModulesEtElementsVM = new ModuleEtElementsViewModel
            {
                ModuleObj = db.Modules.Find(IdModule),
                Elements = await db.Elements.Where(m => m.IdModule == IdModule).ToListAsync()
            };

            return Page();
        }
    }
}

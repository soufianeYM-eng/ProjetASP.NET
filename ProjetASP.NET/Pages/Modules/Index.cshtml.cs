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
using ProjetASP.NET.Models.ViewModels;
using ProjetASP.NET.Utility;

namespace ProjetASP.NET.Pages.Modules
{
    [Authorize(Roles = SD.AdminEndUser)]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext db;

        public IndexModel(ApplicationDbContext db)
        {
            this.db = db;
        }

        public FiliereEtModulesViewModel FiliereEtModulesViewModel { get; set; }
        public IList<Module> Modules { get; set; }

        public async Task<IActionResult> OnGet(int idFil)
        {
            //Modules = await db.Modules.ToListAsync();
            FiliereEtModulesViewModel = new FiliereEtModulesViewModel
            {
                FiliereObj = db.Filieres.Find(idFil),
                Modules = await db.Modules.Where(m => m.Filiere.IdFil == idFil).ToListAsync()
            };
            return Page();
        }
    }
}

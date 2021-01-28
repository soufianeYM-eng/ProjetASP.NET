using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjetASP.NET.Data;
using ProjetASP.NET.Utility;

namespace ProjetASP.NET.Pages.Departements
{
    [Authorize(Roles = SD.AdminEndUser)]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext db;

        public IndexModel(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IList<ProjetASP.NET.Models.Departement> Departements { get; set; }


        public async Task<IActionResult> OnGet()
        {
            Departements = await db.Departements.ToListAsync();

            return Page();
        }
    }
}

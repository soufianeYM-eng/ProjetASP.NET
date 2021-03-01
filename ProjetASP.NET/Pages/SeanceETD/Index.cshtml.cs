using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjetASP.NET.Data;
using ProjetASP.NET.Models;

namespace ProjetASP.NET.Pages.SeanceETD
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext db;

        public IndexModel(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IList<Seance> seances { get; set; }
        public Filiere filieres { get; set; }

        public Element elements { get; set; }


        public Module modules { get; set; }

        public IList<ApplicationUser> UserActive { get; set; }


        public async Task<IActionResult> OnGet()
        {
            UserActive = await db.ApplicationUsers.Where(m => m.NormalizedUserName == User.Identity.Name).ToListAsync();


            filieres = await db.Filieres.Where(m => m.IdFil == UserActive.First().IdFil).FirstAsync();

            modules = await db.Modules.Where(m => m.IdFil == filieres.IdFil).FirstAsync();

            elements = await db.Elements.Where(m => m.IdModule == modules.IdModule).FirstAsync();

            seances = await db.Seances.Where(m => m.IdElement == elements.IdElement).ToListAsync();

            return Page();
        }
    }
}

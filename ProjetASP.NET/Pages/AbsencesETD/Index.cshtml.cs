using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjetASP.NET.Data;
using ProjetASP.NET.Models;

namespace ProjetASP.NET.Pages.AbsencesETD
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext db;

        public IndexModel(ApplicationDbContext db)
        {
            this.db = db;
        }

        [BindProperty]
        public IList<Absence> absences { get; set; }
        public Seance seance { get; set; }

        [BindProperty]

        public IFormFile File { get; set; }
        public IList<ApplicationUser> UserActive { get; set; }


        public async Task<IActionResult> OnGet()
        {
            UserActive = await db.ApplicationUsers.Where(m => m.NormalizedUserName == User.Identity.Name).ToListAsync();

            absences = await db.Absences.Where(m => m.idEtudiant == UserActive.FirstOrDefault().Id).ToListAsync();

            return Page();
        }
    }
}
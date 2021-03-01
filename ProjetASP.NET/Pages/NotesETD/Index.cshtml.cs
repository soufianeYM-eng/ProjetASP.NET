using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjetASP.NET.Data;
using ProjetASP.NET.Models;

namespace ProjetASP.NET.Pages.NotesETD
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext db;

        public IndexModel(ApplicationDbContext db)
        {
            this.db = db;
        }

        [BindProperty]
        public IList<NoteElement> notes { get; set; }
        public Element element { get; set; }
        public IList<ApplicationUser> UserActive { get; set; }


        public async Task<IActionResult> OnGet()
        {
            UserActive = await db.ApplicationUsers.Where(m => m.NormalizedUserName == User.Identity.Name).ToListAsync();

            notes = await db.NoteElements.Where(m => m.idEtudiant == UserActive.FirstOrDefault().Id).ToListAsync();

            return Page();
        }
    }
}
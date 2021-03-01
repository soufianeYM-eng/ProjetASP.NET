using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjetASP.NET.Data;
using ProjetASP.NET.Models;

namespace ProjetASP.NET.Pages.Notes
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext db;

        public IndexModel(ApplicationDbContext db)
        {
            this.db = db;
        }

        [BindProperty]
        public Element element { get; set; }
        [BindProperty]
        public IList<Element> Elements { get; set; }
        [BindProperty]
        public Module Module { get; set; }
        [BindProperty]
        public IList<ApplicationUser> Etudiants { get; set; }

        [BindProperty]
        public NoteElement noteElement { get; set; }

        [BindProperty]
        public double note { get; set; }


        public async Task<IActionResult> OnGet()
        {
            noteElement = new NoteElement();
            Elements = await db.Elements.Where(m => m.userId == User.Identity.Name).ToListAsync();
            Module = await db.Modules.Where(m => m.IdModule == Elements.FirstOrDefault().IdModule).FirstAsync();
            Etudiants = await db.ApplicationUsers.Where(m => m.IdFil == Module.IdFil).ToListAsync();
            return Page();
        }


        public async Task<IActionResult> OnPost()
        {
            
        }

    }
}

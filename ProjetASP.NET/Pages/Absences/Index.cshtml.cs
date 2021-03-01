using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjetASP.NET.Data;
using ProjetASP.NET.Models;

namespace ProjetASP.NET.Pages.Absences
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext db;

        public IndexModel(ApplicationDbContext db)
        {
            this.db = db;
        }

        [BindProperty]
        public List<Seance> Seances { get; set; }
        [BindProperty]
        public Element element { get; set; }
        [BindProperty]
        public IList<Element> Elements { get; set; }
        [BindProperty]
        public Seance seance { get; set; }


        public async Task<IActionResult> OnGet()
        {
            Elements = await db.Elements.Where(m => m.userId == User.Identity.Name).ToListAsync();

            Seances = new List<Seance>();
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            Elements = await db.Elements.Where(m => m.userId == User.Identity.Name).ToListAsync();
            Seances = await db.Seances.Where(m => m.IdElement == element.IdElement).ToListAsync();
            return Page();
        }




    }
}

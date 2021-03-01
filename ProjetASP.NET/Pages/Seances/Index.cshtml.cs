using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjetASP.NET.Data;
using ProjetASP.NET.Models.ViewModels;

namespace ProjetASP.NET.Pages.Seances
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext db;

        public IndexModel(ApplicationDbContext db)
        {
            this.db = db;
        }

        public SeanceEtElementViewModel SeanceEtElementsVM { get; set; }

        [TempData]
        public string StatusMessage { get; set; }


        public async Task<IActionResult> OnGet(int IdElement)
        {
            SeanceEtElementsVM = new SeanceEtElementViewModel
            {
                ElementObj = db.Elements.Find(IdElement),
                Seances = await db.Seances.Where(m => m.IdElement == IdElement).ToListAsync()
            };

            return Page();
        }
    }
}

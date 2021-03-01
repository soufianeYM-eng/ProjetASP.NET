using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjetASP.NET.Data;
using ProjetASP.NET.Models.ViewModels;

namespace ProjetASP.NET.Pages.TravailPROF
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext db;

        public IndexModel(ApplicationDbContext db)
        {
            this.db = db;
        }

        public TravailEtElement TravailEtElementVM { get; set; }

        [TempData]
        public string StatusMessage { get; set; }


        public async Task<IActionResult> OnGet(int IdElement)
        {
            TravailEtElementVM = new TravailEtElement
            {
                ElementObj = db.Elements.Find(IdElement),
                Travaux = await db.Travaux.Where(m => m.IdElement == IdElement).ToListAsync()
            };

            return Page();
        }
    }
}

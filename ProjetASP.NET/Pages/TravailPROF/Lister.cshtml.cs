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
    public class ListerModel : PageModel
    {
        private readonly ApplicationDbContext db;

        public ListerModel(ApplicationDbContext db)
        {
            this.db = db;
        }

        public TravailEtTravaux TravailEtTravauxVM { get; set; }

        [TempData]
        public string StatusMessage { get; set; }


        public async Task<IActionResult> OnGet(int idTravaux)
        {
            TravailEtTravauxVM = new TravailEtTravaux
            {
                TravauxObj = db.Travaux.Find(idTravaux),
                Travails = await db.Travails.Where(m => m.idTravaux == idTravaux).ToListAsync()
            };

            return Page();
        }
    }
}

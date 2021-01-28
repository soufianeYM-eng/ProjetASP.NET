using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjetASP.NET.Data;
using ProjetASP.NET.Models;
using ProjetASP.NET.Utility;

namespace ProjetASP.NET.Pages.Users
{
    [Authorize(Roles = SD.AdminEndUser)]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext db;
        public IndexModel(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IList<ApplicationUser> ApplicationUsersList { get; set; }


        public async Task<IActionResult> OnGet(string chercherCIN,string chercherEmail, string chercherNom)
        {
            if(chercherCIN == null)
            {
                chercherCIN = "";
            }
            if (chercherEmail == null)
            {
                chercherEmail = "";
            }
            if (chercherNom == null)
            {
                chercherNom = "";
            }

          ApplicationUsersList = await db.ApplicationUsers
              .Where(
                  m => m.CIN.ToLower().Contains(chercherCIN.ToLower()) &&
                  m.LastName.ToLower().Contains(chercherNom.ToLower()) &&
                  m.Email.ToLower().Contains(chercherEmail.ToLower())
              )
              .ToListAsync();

            

            return Page(); 
        }
    }
}

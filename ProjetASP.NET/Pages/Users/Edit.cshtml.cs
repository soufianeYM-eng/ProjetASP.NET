using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetASP.NET.Data;
using ProjetASP.NET.Models;
using ProjetASP.NET.Utility;

namespace ProjetASP.NET.Pages.Users
{
    [Authorize(Roles = SD.AdminEndUser)]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext db;

        public EditModel(ApplicationDbContext db)
        {
            this.db = db;
        }

        [BindProperty]
        public ApplicationUser ApplicationUser { get; set; }

        public async Task<IActionResult> OnGet(string id)
        {
            ApplicationUser = await db.ApplicationUsers.FindAsync(id);
            return Page();
        }


        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var user = await db.ApplicationUsers.FindAsync(ApplicationUser.Id);

                user.CIN = ApplicationUser.CIN;
                user.LastName = ApplicationUser.LastName;
                user.FirstName = ApplicationUser.FirstName;
                user.City = ApplicationUser.City;
                user.Adress = ApplicationUser.Adress;
                user.PhoneNumber = ApplicationUser.PhoneNumber;


                await db.SaveChangesAsync();

                return RedirectToPage("Index");
            }

            return Page();
            

        }

    }
}

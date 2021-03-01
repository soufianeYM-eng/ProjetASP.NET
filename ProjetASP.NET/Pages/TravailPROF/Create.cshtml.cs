using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetASP.NET.Data;
using ProjetASP.NET.Models;

namespace ProjetASP.NET.Pages.TravailPROF
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext db;
        private readonly IWebHostEnvironment webHostEnvironment;

        public CreateModel(ApplicationDbContext db,IWebHostEnvironment webHostEnvironment)
        {
            this.db = db;
            this.webHostEnvironment = webHostEnvironment;
        }

        [BindProperty]
        public Travaux Travaux { get; set; }

        [BindProperty]

        public IFormFile File { get; set; }


        [TempData]
        public string StatusMessage { get; set; }




        public async Task<IActionResult> OnGet(int IdElement)
        {
            Travaux = new Travaux();
            Travaux.IdElement = IdElement;
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (File != null)
            {
                if (Travaux.File != null)
                {
                    string filePath = Path.Combine(webHostEnvironment.WebRootPath,
                        "Travaux", Travaux.File);
                    System.IO.File.Delete(filePath);
                }
                Travaux.File = ProcessUploadedFile();
            }

            if (ModelState.IsValid)
            {
                await db.Travaux.AddAsync(Travaux);
                await db.SaveChangesAsync();
                StatusMessage = "Ajout réussi avec succès";
                return RedirectToPage("Index", new { IdElement = Travaux.IdElement });
            }
            return Page();
        }

        private string ProcessUploadedFile()
        {
            string uniqueFileName = null;
            if (File != null)
            {
                Travaux.File = "";
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Travaux");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + File.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    File.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}

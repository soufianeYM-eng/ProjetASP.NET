using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjetASP.NET.Data;
using ProjetASP.NET.Models;
using ProjetASP.NET.Utility;

namespace ProjetASP.NET.Pages.Filieres
{
    [Authorize(Roles = SD.AdminEndUser)]
    public class DeleteModel : PageModel
    {
        private readonly ProjetASP.NET.Data.ApplicationDbContext _context;

        public DeleteModel(ProjetASP.NET.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Filiere Filiere { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Filiere = await _context.Filieres.FirstOrDefaultAsync(m => m.IdFil == id);

            if (Filiere == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Filiere = await _context.Filieres.FindAsync(id);

            if (Filiere != null)
            {
                _context.Filieres.Remove(Filiere);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("Index");
        }
    }
}

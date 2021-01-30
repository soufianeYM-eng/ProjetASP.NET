using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetASP.NET.Data.ApplicationDbContext;

namespace ProjetASP.NET.Pages.MatieresProf
{
    public class IndexModel : PageModel
    {

        public void OnGet(ApplicationDbContext db)
        {
        }
    }
}

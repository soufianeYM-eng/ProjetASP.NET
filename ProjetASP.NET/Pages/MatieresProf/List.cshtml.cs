using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjetASP.NET.Data;
using ProjetASP.NET.Models;

namespace ProjetASP.NET.Pages.MatieresProf
{
    public class ListModel : PageModel
    {
        private readonly ProjetASP.NET.Data.ApplicationDbContext _context;

        private readonly UserManager<ApplicationUser> _userManager;
        public ListModel(ProjetASP.NET.Data.ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public ApplicationUser UserActual { get; set; }
        public IList<Element> Element { get;set; }

        public async Task OnGetAsync()
        {
            //Elements = await _context.Elements.Include(e => e.Module).ToList();
            //foreach(Element e in Elements)
            //{
            //    //if(e.userId == "Khalid.Amechnoue@gmail.com")
            //    //{
            //    //    Element.Add(e);
            //    //}
            //}
        }
    }
}

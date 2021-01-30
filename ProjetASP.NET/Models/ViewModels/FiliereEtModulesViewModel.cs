using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetASP.NET.Models.ViewModels
{
    public class FiliereEtModulesViewModel
    {
        public Filiere FiliereObj { get; set; }

        public IEnumerable<Module> Modules { get; set; }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetASP.NET.Models.ViewModels
{
    public class ModuleEtElementsViewModel
    {
        public Module ModuleObj { get; set; }

        public IEnumerable<Element> Elements { get; set; }
    }
}

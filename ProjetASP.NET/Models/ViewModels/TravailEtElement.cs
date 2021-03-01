using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetASP.NET.Models.ViewModels
{
    public class TravailEtElement
    {
        public Element ElementObj { get; set; }

        public IEnumerable<Travaux> Travaux { get; set; }
    }
}

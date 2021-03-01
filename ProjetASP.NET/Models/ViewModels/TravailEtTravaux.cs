using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetASP.NET.Models.ViewModels
{
    public class TravailEtTravaux
    {
        public Travaux TravauxObj { get; set; }

        public IEnumerable<Travail> Travails { get; set; }
    }
}

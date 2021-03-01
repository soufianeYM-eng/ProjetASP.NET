using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetASP.NET.Models.ViewModels
{
    public class SeanceEtElementViewModel
    {
        public Element ElementObj { get; set; }


        public IEnumerable<Seance> Seances { get; set; }

    }
}

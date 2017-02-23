using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakkerijGoedGeSpelt
{
    class Brood
    {
        
        private string beschrijving;
        private BroodSoort _Soort;
        private decimal prijs;

        public string Beschrijving { get { return beschrijving; } }
        public BroodSoort Soort { get { return _Soort; } }
        public decimal Prijs { get { return prijs; } }
        
       

        public Brood(string beschrijving, BroodSoort soort, decimal prijs)
        {
            this.beschrijving = beschrijving;
            this._Soort = soort;
            this.prijs = prijs;
            
        }

        public override string ToString()
        {
            return beschrijving;
        }
    }
}

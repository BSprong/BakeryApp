using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakkerijGoedGeSpelt
{
    class Beleg
    {       

        private string beschrijving;
        private decimal prijs;
        private BelegSoort soort;
       

        public string Beschrijving { get { return beschrijving; } }
        public decimal Prijs { get { return prijs; } }
        

        public Beleg(string beschrijving, BelegSoort soort, decimal prijs)
        {
            this.beschrijving = beschrijving;
            this.prijs = prijs;
            this.soort = soort;
            
        }

        public override string ToString()
        {
            return beschrijving;
        }

       

    }
}

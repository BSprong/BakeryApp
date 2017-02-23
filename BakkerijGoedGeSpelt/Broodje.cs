using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakkerijGoedGeSpelt
{
    class Broodje
    {
        
        private string naam;
        private decimal prijs;
        private string NaamEnPrijs;

        //private List<Broodje> Broodjes;
       private Brood brood;
        
       //Brood brood = new Brood("brood", Spelt, 9 );
        private List<Beleg> beleg;

        public string Naam
        {
            get { return naam; }
            set { naam = value; }
            
        }

        public decimal Prijs {
            get {
                decimal prijs = 0;
                prijs = brood.Prijs;
                foreach(Beleg b in beleg)
                {
                   prijs += b.Prijs;
                    
                }

                return prijs;

            }

        }

        public string NaamEnprijs
        {
            get
            {
                return naam + " " + "€ " + Prijs.ToString("0.00");
            }
        }

        public List<Beleg> Beleg { get { return beleg; } }
        //public string NaamenPrijs { get { return NaamEnPrijs; } }

        public Broodje(string naam, Brood brood)
        {
            this.naam = naam;
            this.brood = brood;
            //this.prijs = prijs;
            //this.NaamEnPrijs = naamenprijs;
            //Broodjes = new List<Broodje>();
            beleg = new List<Beleg>();
        }

        public bool VoegBelegToe(Beleg beleg, out Boolean MeerDanVijf)
        {
            if (this.beleg.Count >= 5)
            {
                MeerDanVijf = true;
            }
            else { MeerDanVijf = false; }
            
            // Controleer eerst of er niet al eentje is met dezelfde naam.
            foreach (Beleg artikel in this.beleg)
            {
                if (artikel.Beschrijving == beleg.Beschrijving)
                {
                    return false;
                }
            }

            // Voeg het artikel toe aan de lijst.
            this.beleg.Add(beleg);

            //MeerDanVijf = true;
            return true;
        }
    }
}

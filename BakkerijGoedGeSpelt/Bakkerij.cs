using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakkerijGoedGeSpelt
{
    class Bakkerij
    {
        private string naam;
        //private decimal prijs;
        private List<Broodje> Broodjes;

        public string name { get { return naam; } }
        //public decimal price { get { return prijs; } }
        public List<Broodje> Broodje { get { return Broodjes; } }

        public Bakkerij(string naam)
        {
            this.naam = naam;
            //this.prijs = prijs;
            Broodjes = new List<Broodje>();
        }

        public bool VoegBroodjeToe(Broodje broodje)
        {
            // Controleer eerst of er niet al eentje is met dezelfde naam.
            foreach (Broodje artikel in Broodjes)
            {
                if (artikel.Naam == broodje.Naam)
                {
                    return false;
                }
            }

            // Voeg het artikel toe aan de lijst.
            Broodjes.Add(broodje);

            return true;
        }

        public decimal GeefTotaalPrijs ()
        {
            decimal totaalprijs = 0;
            foreach(Broodje b in Broodjes)
            {
                totaalprijs += b.Prijs;
            }
            return  totaalprijs;
        }

        public void WisLijst()
        {
            Broodjes.Clear();
        }

        //public List<Broodje> GeefAlleArtikelen()
        //{
        //    return Broodjes;
        //}
    }
}

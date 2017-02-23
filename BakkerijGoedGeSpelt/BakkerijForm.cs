using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BakkerijGoedGeSpelt
{
    public partial class bakkerijForm : Form
    {
        private Bakkerij bakkerij;
        private Broodje huidigBroodje;
        private Broodje broodje;

        public bakkerijForm()
        {
            InitializeComponent();
            bakkerij = new Bakkerij("jan");
            //broodje = new Broodje("brood",  );
            VulBelegComboBox();
            VulBroodComboBox();
        }

        public void VulBroodComboBox()
        {
            
            List<Brood> broodsoorten = new List<Brood>();
            broodsoorten.Add(new Brood("Boeren bruin", BroodSoort.Tarwe, 2.0m));
            broodsoorten.Add(new Brood("Grof Spelt", BroodSoort.Spelt, 1.8m));
            broodsoorten.Add(new Brood("Abdijbrood", BroodSoort.Volkoren, 1.4m));
            broodsoorten.Add(new Brood("Pain de Mer", BroodSoort.Wit, 2.4m));

            cbBroodSoorten.DataSource = broodsoorten;
            cbBroodSoorten.DisplayMember = "Beschrijving";
            
        }

        public void VulBelegComboBox()
        {
            
            List<Beleg> belegsoorten = new List<Beleg>();
            belegsoorten.Add(new Beleg("Sla", BelegSoort.Groente, 0.1m));
            belegsoorten.Add(new Beleg("Oude kaas", BelegSoort.Kaas, 0.15m));
            belegsoorten.Add(new Beleg("Jong belegen", BelegSoort.Kaas, 0.1m));
            belegsoorten.Add(new Beleg("Tomaat", BelegSoort.Groente, 0.05m));
            belegsoorten.Add(new Beleg("Komkommer", BelegSoort.Groente, 0.1m));
            belegsoorten.Add(new Beleg("Ham", BelegSoort.Vlees, 0.15m));
            belegsoorten.Add(new Beleg("Salame", BelegSoort.Vlees, 0.15m));
            belegsoorten.Add(new Beleg("Rookvlees", BelegSoort.Vlees, 0.2m));
            belegsoorten.Add(new Beleg("Tonijnsalade", BelegSoort.Vis, 0.3m));
            belegsoorten.Add(new Beleg("Brie", BelegSoort.Kaas, 0.25m));
            belegsoorten.Add(new Beleg("Appel", BelegSoort.Fruit, 0.15m));
            belegsoorten.Add(new Beleg("Gerookte zalm", BelegSoort.Vis, 0.45m));

            cbBeleg.DataSource = belegsoorten;
            cbBeleg.DisplayMember = "Beschrijving";
            
        }

        private void btBroodjeAanmaken_Click(object sender, EventArgs e)
        {
            string naam = tbNaamBroodje.Text;
            if (string.IsNullOrEmpty(naam))
            {
                MessageBox.Show("Je dient een naam op te geven.");
                return;
            }

           

            Brood geselecteerdBrood = (Brood)cbBroodSoorten.SelectedItem;
            huidigBroodje = new Broodje(naam, geselecteerdBrood);

            if (geselecteerdBrood == null)
            {
                MessageBox.Show("vul in");
                return;
            }

                //Brood brood = new Brood("");
                bool gelukt = bakkerij.VoegBroodjeToe(huidigBroodje);
            if (!gelukt)
            {
                MessageBox.Show("Er is al een brood met die naam.");
                return;
            }

            if(gelukt)
            {
                MessageBox.Show("Brood toegevoegd.");
                cbBeleg.Enabled = true;
                btBelegToevoegen.Enabled = true;
            }
            tbNaamBroodje.Clear();
        }

        private void btBelegToevoegen_Click(object sender, EventArgs e)
        {
            bool meerdanVijf;
            Beleg geselecteerdBeleg = (Beleg)cbBeleg.SelectedItem;
            bool gelukt =  huidigBroodje.VoegBelegToe(geselecteerdBeleg, out meerdanVijf);
            if (!gelukt)
            {
                MessageBox.Show("Beleg bestaat al");

            }
            else if (meerdanVijf == true)
            {
                MessageBox.Show("vijf bereikt");
            }

            
            else 
            {
                MessageBox.Show("Beleg toegevoegd.");
                btBroodjeKlaar.Enabled = true;
            }
            
        }

        private void btBroodjeKlaar_Click(object sender, EventArgs e)
        {

            lbBroodjes.Items.Add(huidigBroodje.Naam + " " + huidigBroodje.Prijs.ToString());
            

        }

        private void lblGeselecteerdBroodje_Click(object sender, EventArgs e)
        {

        }

        private void lbBroodjes_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblGeselecteerdBroodje.Text = huidigBroodje.NaamEnprijs.ToString();
            //lblBeleg.Text = huidigBroodje.beleg1.
            lblBeleg.Text = string.Empty;
            foreach (Beleg beleg in huidigBroodje.Beleg)
            {
                
                lblBeleg.Text += " " + beleg.Beschrijving ;
            }
            
        }

        private void btWisDeLijst_Click(object sender, EventArgs e)
        {

            bakkerij.WisLijst();
            lbBroodjes.Items.Clear();          
        }

        private void btGeefTotaalprijs_Click(object sender, EventArgs e)
        {
            decimal d = bakkerij.GeefTotaalPrijs();
            MessageBox.Show(d.ToString("€ 0.00"));
        }
    }
}

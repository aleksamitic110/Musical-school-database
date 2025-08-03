using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Prodavnica
{
    public partial class DodajSefaForma : Form
    {
        ProdavnicaBasic prodavnica;

        public DodajSefaForma()
        {
            InitializeComponent();
        }
        
        public DodajSefaForma(ProdavnicaBasic p)
        {
            InitializeComponent();
            prodavnica = p;
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {

            //Dodavanje Sefa
            
            SefBasic s = new SefBasic();
            s.Mbr = Int32.Parse(txbMbr.Text);
            s.Ime = txbIme.Text;
            s.SrednjeSlovo = Char.Parse(txbSrednjeSlovo.Text);
            s.Prezime = txbPrezime.Text;
            s.DatumRodjenja = datumRodjenja.Value;
            s.StrucnaSpema = txbStrucnaSprema.Text;
            s.Sef = true;

            DTOManager.dodajSefa(s);

            //Dodavanje RadiU
            dodajRadniOdnos();

            //sefuje.DatumPostavljenja = DateTime.Now;
            SefujeBasic sefuje = new SefujeBasic();
            sefuje.DatumPostavljenja = datumPostavljanja.Value;
            sefuje.Upravnik =DTOManager.vratiSveSefove().OrderByDescending(item => item.Jbr).First();
            sefuje.Upravlja = prodavnica;

            //Dodavanje Sefuje
            DTOManager.dodajSefOdnos(sefuje);
            MessageBox.Show("Uspesno ste dodali novog sefa!");
        }

        public void dodajRadniOdnos()
        {
            RadiUBasic radi = new RadiUBasic();
            ProdavnicaBasic p = DTOManager.vratiProdavnicu(prodavnica.Id);
            List<RadnikBasic> radnici = DTOManager.vratiSveRadnike();
            RadnikBasic radnikPoslednjiDodat = radnici.OrderByDescending(item => item.Jbr).First();
            radi.Id = new RadiUIdBasic();
            radi.Id.RadiUProdavnica = p;
            radi.Id.RadnikRadiU = radnikPoslednjiDodat;
            radi.DatumOd = datumPostavljanja.Value;
            DTOManager.dodajRadniOdnos(radi);
            this.Close();
        }
    }
}

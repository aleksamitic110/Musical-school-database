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
    public partial class DodajProizvodDodaciZaLutkeForma : Form
    {
        OdeljenjeBasic odeljenje;
        
        public DodajProizvodDodaciZaLutkeForma()
        {
            InitializeComponent();
        }

        public DodajProizvodDodaciZaLutkeForma(OdeljenjeBasic o)
        {
            InitializeComponent();
            odeljenje = o;
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            DodatakZaLutkuBasic dzl = new DodatakZaLutkuBasic();
            dzl.Tip = "DODACI ZA LUTKE";
            dzl.Naziv = txbNaziv.Text;
            dzl.Proizvodjac = txbProizvodjac.Text;
            dzl.NazivDodatka = txbNazivDodatka.Text;
            dzl.TipDodatka = txbTipDodatka.Text;

            DTOManager.sacuvajDodatakZaLutku(dzl);
            ProdajeSeBasic prodaja = new ProdajeSeBasic();
            prodaja.ProdajeOdeljenje = odeljenje;
            prodaja.ProdajeProzivod = DTOManager.vratiSveProizvodeBasic().OrderByDescending(item => item.BarKod).First();
            DTOManager.sacuvajProdajeSe(prodaja);
            MessageBox.Show("Uspesno ste dodali igracku dodatak za lutku!");
            this.Close();
        }
    }
}

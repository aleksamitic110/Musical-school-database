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
    public partial class DodajProizvodAutomobiliForma : Form
    {
        OdeljenjeBasic odeljenje;

        public DodajProizvodAutomobiliForma()
        {
            InitializeComponent();
        }

        public DodajProizvodAutomobiliForma(OdeljenjeBasic o)
        {
            InitializeComponent();
            odeljenje = o;
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            AutomobilBasic a = new AutomobilBasic();
            a.Tip = "AUTOMOBILI";
            a.Naziv = txbNaziv.Text;
            a.Proizvodjac = txbProizvodjac.Text;
            a.NazivSerije = txbNazivSerije.Text;

            if (chbBaterije.Checked == true)
                a.Baterije = "Da";
            else
                a.Baterije = "Ne";

            DTOManager.sacuvajAutomobil(a);
            ProdajeSeBasic prodaja = new ProdajeSeBasic();
            prodaja.ProdajeOdeljenje = odeljenje;
            prodaja.ProdajeProzivod=DTOManager.vratiSveProizvodeBasic().OrderByDescending(item => item.BarKod).First();
            DTOManager.sacuvajProdajeSe(prodaja);
            MessageBox.Show("Uspesno ste dodali igracku automobil!");
            this.Close();
        }
    }
}

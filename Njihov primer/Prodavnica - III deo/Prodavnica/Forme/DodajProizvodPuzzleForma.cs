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
    public partial class DodajProizvodPuzzleForma : Form
    {
        OdeljenjeBasic odeljenje;

        public DodajProizvodPuzzleForma()
        {
            InitializeComponent();
        }

        public DodajProizvodPuzzleForma(OdeljenjeBasic o)
        {
            InitializeComponent();
            odeljenje = o;
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            SlagalicaBasic s = new SlagalicaBasic();
            s.Tip = "PUZZLE";
            s.Naziv = txbNaziv.Text;
            s.Proizvodjac = txbProizvodjac.Text;
            s.BrojDelova = (int)brojDelova.Value;

            if (chbTuristicka.Checked == true)
                s.Turisticka = "Da";
            else
                s.Turisticka = "Ne";

            if (chbUmetnicka.Checked == true)
                s.Umetnicka = "Da";
            else
                s.Umetnicka = "Ne";

            if (chbIlustracija.Checked == true)
                s.Ilustracija = "Da";
            else
                s.Ilustracija = "Ne";

            DTOManager.sacuvajSlagalicu(s);
            ProdajeSeBasic prodaja = new ProdajeSeBasic();
            prodaja.ProdajeOdeljenje = odeljenje;
            prodaja.ProdajeProzivod = DTOManager.vratiSveProizvodeBasic().OrderByDescending(item => item.BarKod).First();
            DTOManager.sacuvajProdajeSe(prodaja);
            MessageBox.Show("Uspesno ste dodali igracku slagalicu!");
            this.Close();
        }
    }
}

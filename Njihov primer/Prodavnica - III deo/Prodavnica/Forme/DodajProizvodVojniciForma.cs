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
    public partial class DodajProizvodVojniciForma : Form
    {
        OdeljenjeBasic odeljenje;

        public DodajProizvodVojniciForma()
        {
            InitializeComponent();
        }

        public DodajProizvodVojniciForma(OdeljenjeBasic o)
        {
            InitializeComponent();
            odeljenje = o;
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            VojnikBasic v = new VojnikBasic();
            v.Tip = "VOJNICI";
            v.Naziv = txbNaziv.Text;
            v.Proizvodjac = txbProizvodjac.Text;
            v.NazivSerije = txbNazivSerije.Text;

            if (chbBaterije.Checked == true)
                v.Baterije = "Da";
            else
                v.Baterije = "Ne";

            if (chbMetal.Checked == true)
                v.Metal = "Da";
            else
                v.Metal = "Ne";

            if (chbPlastika.Checked == true)
                v.Plastika = "Da";
            else
                v.Plastika = "Ne";

            DTOManager.sacuvajVojnika(v);
            ProdajeSeBasic prodaja = new ProdajeSeBasic();
            prodaja.ProdajeOdeljenje = odeljenje;
            prodaja.ProdajeProzivod = DTOManager.vratiSveProizvodeBasic().OrderByDescending(item => item.BarKod).First();
            DTOManager.sacuvajProdajeSe(prodaja);
            MessageBox.Show("Uspesno ste dodali igracku vojnika!");
            this.Close();
        }
    }
}

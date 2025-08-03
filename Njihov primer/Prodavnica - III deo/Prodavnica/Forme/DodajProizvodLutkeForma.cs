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
    public partial class DodajProizvodLutkeForma : Form
    {
        OdeljenjeBasic odeljenje;
        
        public DodajProizvodLutkeForma()
        {
            InitializeComponent();
        }

        public DodajProizvodLutkeForma(OdeljenjeBasic o)
        {
            InitializeComponent();
            odeljenje = o;
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            LutkaBasic l = new LutkaBasic();
            l.Tip = "LUTKE";
            l.Naziv = txbNaziv.Text;
            l.Proizvodjac = txbProizvodjac.Text;
            l.Ime = txbIme.Text;

            if (chbGovori.Checked == true)
                l.Govori = "Da";
            else
                l.Govori = "Ne";

            if (chbOsetljivaDodir.Checked == true)
                l.OsetljivaDodir = "Da";
            else
                l.OsetljivaDodir = "Ne";

            DTOManager.sacuvajLutku(l);
            ProdajeSeBasic prodaja = new ProdajeSeBasic();
            prodaja.ProdajeOdeljenje = odeljenje;
            prodaja.ProdajeProzivod = DTOManager.vratiSveProizvodeBasic().OrderByDescending(item => item.BarKod).First();
            DTOManager.sacuvajProdajeSe(prodaja);
            MessageBox.Show("Uspesno ste dodali igracku lutku!");
            this.Close();
        }
    }
}

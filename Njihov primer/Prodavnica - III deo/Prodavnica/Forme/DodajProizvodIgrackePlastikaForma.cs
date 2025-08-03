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
    public partial class DodajProizvodIgrackePlastikaForma : Form
    {
        OdeljenjeBasic odeljenje;

        public DodajProizvodIgrackePlastikaForma()
        {
            InitializeComponent();
        }

        public DodajProizvodIgrackePlastikaForma(OdeljenjeBasic o)
        {
            InitializeComponent();
            odeljenje = o;
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            IgrackaPlastikaBasic ip = new IgrackaPlastikaBasic();
            ip.Tip = "IGRACKE PLASTIKA";
            ip.Naziv = txbNaziv.Text;
            ip.Proizvodjac = txbProizvodjac.Text;
            ip.Uzrast = (int)uzrast.Value;

            if (chbVodootporna.Checked == true)
                ip.Vodootporna = "Da";
            else
                ip.Vodootporna = "Ne";

            if (chbLomljiva.Checked == true)
                ip.Lomljiva = "Da";
            else
                ip.Lomljiva = "Ne";

            DTOManager.sacuvajIgrackuPlastika(ip);
            ProdajeSeBasic prodaja = new ProdajeSeBasic();
            prodaja.ProdajeOdeljenje = odeljenje;
            prodaja.ProdajeProzivod = DTOManager.vratiSveProizvodeBasic().OrderByDescending(item => item.BarKod).First();
            DTOManager.sacuvajProdajeSe(prodaja);
            MessageBox.Show("Uspesno ste dodali igracku od plastike!");
            this.Close();
        }
    }
}

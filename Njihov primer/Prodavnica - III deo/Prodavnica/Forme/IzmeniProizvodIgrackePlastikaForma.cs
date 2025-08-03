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
    public partial class IzmeniProizvodIgrackePlastikaForma : Form
    {
        IgrackaPlastikaBasic igracka;

        public IzmeniProizvodIgrackePlastikaForma()
        {
            InitializeComponent();
        }

        public IzmeniProizvodIgrackePlastikaForma(IgrackaPlastikaBasic ip)
        {
            InitializeComponent();
            igracka = ip;
            popuniPodacima();
        }

        public void popuniPodacima()
        {
            txbNaziv.Text = igracka.Naziv;
            txbProizvodjac.Text = igracka.Proizvodjac;
            uzrast.Value = igracka.Uzrast;
            if (igracka.Vodootporna == "Da")
                chbVodootporna.Checked = true;
            if (igracka.Lomljiva == "Da")
                chbLomljiva.Checked = true;
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            igracka.Naziv = txbNaziv.Text;
            igracka.Proizvodjac = txbProizvodjac.Text;
            igracka.Uzrast = (int)uzrast.Value;

            if (chbVodootporna.Checked == true)
                igracka.Vodootporna = "Da";
            else
                igracka.Vodootporna = "Ne";

            if (chbLomljiva.Checked == true)
                igracka.Lomljiva = "Da";
            else
                igracka.Lomljiva = "Ne";

            DTOManager.azurirajIgrackuPlastika(igracka);
            this.Close();
        }
    }
}

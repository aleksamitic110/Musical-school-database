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
    public partial class IzmeniProizvodLutkaForma : Form
    {
        LutkaBasic lutka;

        public IzmeniProizvodLutkaForma()
        {
            InitializeComponent();
        }

        public IzmeniProizvodLutkaForma(LutkaBasic l)
        {
            InitializeComponent();
            lutka = l;
            popuniPodacima();
        }

        public void popuniPodacima()
        {
            txbNaziv.Text = lutka.Naziv;
            txbProizvodjac.Text = lutka.Proizvodjac;
            txbIme.Text = lutka.Ime;
            if (lutka.Govori == "Da")
                chbGovori.Checked = true;
            if (lutka.OsetljivaDodir == "Da")
                chbOsetljivaDodir.Checked = true;
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            lutka.Naziv = txbNaziv.Text;
            lutka.Proizvodjac = txbProizvodjac.Text;
            lutka.Ime = txbIme.Text;

            if (chbGovori.Checked == true)
                lutka.Govori = "Da";
            else
                lutka.Govori = "Ne";

            if (chbOsetljivaDodir.Checked == true)
                lutka.OsetljivaDodir = "Da";
            else
                lutka.OsetljivaDodir = "Ne";

            DTOManager.azurirajLutku(lutka);
            this.Close();
        }
    }
}

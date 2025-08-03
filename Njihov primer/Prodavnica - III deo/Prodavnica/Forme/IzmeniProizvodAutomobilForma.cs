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
    public partial class IzmeniProizvodAutomobilForma : Form
    {
        AutomobilBasic automobil;

        public IzmeniProizvodAutomobilForma()
        {
            InitializeComponent();
        }

        public IzmeniProizvodAutomobilForma(AutomobilBasic a)
        {
            InitializeComponent();
            automobil = a;
            popuniPodacima();
        }

        public void popuniPodacima()
        {
            txbNaziv.Text = automobil.Naziv;
            txbProizvodjac.Text = automobil.Proizvodjac;
            txbNazivSerije.Text = automobil.NazivSerije;
            if (automobil.Baterije == "Da")
                chbBaterije.Checked = true;
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            automobil.Naziv = txbNaziv.Text;
            automobil.Proizvodjac = txbProizvodjac.Text;
            automobil.NazivSerije = txbNazivSerije.Text;

            if (chbBaterije.Checked == true)
                automobil.Baterije = "Da";
            else
                automobil.Baterije = "Ne";

            DTOManager.azurirajAutomobil(automobil);
            this.Close();
        }
    }
}

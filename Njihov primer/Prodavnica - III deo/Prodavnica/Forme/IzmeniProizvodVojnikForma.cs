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
    public partial class IzmeniProizvodVojnikForma : Form
    {
        VojnikBasic vojnik;

        public IzmeniProizvodVojnikForma()
        {
            InitializeComponent();
        }

        public IzmeniProizvodVojnikForma(VojnikBasic v)
        {
            InitializeComponent();
            vojnik = v;
            popuniPodacima();
        }

        public void popuniPodacima()
        {
            txbNaziv.Text = vojnik.Naziv;
            txbProizvodjac.Text = vojnik.Proizvodjac;
            txbNazivSerije.Text = vojnik.NazivSerije;
            if (vojnik.Baterije == "Da")
                chbBaterije.Checked = true;
            if (vojnik.Metal == "Da")
                chbMetal.Checked = true;
            if (vojnik.Plastika == "Da")
                chbPlastika.Checked = true;
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            vojnik.Naziv = txbNaziv.Text;
            vojnik.Proizvodjac = txbProizvodjac.Text;
            vojnik.NazivSerije = txbNazivSerije.Text;

            if (chbBaterije.Checked == true)
                vojnik.Baterije = "Da";
            else
                vojnik.Baterije = "Ne";

            if (chbMetal.Checked == true)
                vojnik.Metal = "Da";
            else
                vojnik.Metal = "Ne";

            if (chbPlastika.Checked == true)
                vojnik.Plastika = "Da";
            else
                vojnik.Plastika = "Ne";

            DTOManager.azurirajVojnika(vojnik);
            this.Close();
        }
    }
}

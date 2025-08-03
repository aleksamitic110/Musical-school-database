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
    public partial class IzmeniProizvodSlagalicaForma : Form
    {
        SlagalicaBasic slagalica;

        public IzmeniProizvodSlagalicaForma()
        {
            InitializeComponent();
        }

        public IzmeniProizvodSlagalicaForma(SlagalicaBasic sl)
        {
            InitializeComponent();
            slagalica = sl;
            popuniPodacima();
        }

        public void popuniPodacima()
        {
            txbNaziv.Text = slagalica.Naziv;
            txbProizvodjac.Text = slagalica.Proizvodjac;
            brojDelova.Value = slagalica.BrojDelova;
            if (slagalica.Turisticka == "Da")
                chbTuristicka.Checked = true;
            if (slagalica.Umetnicka == "Da")
                chbUmetnicka.Checked = true;
            if (slagalica.Ilustracija == "Da")
                chbIlustracija.Checked = true;
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            slagalica.Naziv = txbNaziv.Text;
            slagalica.Proizvodjac = txbProizvodjac.Text;
            slagalica.BrojDelova = (int)brojDelova.Value;

            if (chbTuristicka.Checked == true)
                slagalica.Turisticka = "Da";
            else
                slagalica.Turisticka = "Ne";

            if (chbUmetnicka.Checked == true)
                slagalica.Umetnicka = "Da";
            else
                slagalica.Umetnicka = "Ne";

            if (chbIlustracija.Checked == true)
                slagalica.Ilustracija = "Da";
            else
                slagalica.Ilustracija = "Ne";

            DTOManager.azurirajSlagalicu(slagalica);
            this.Close();
        }
    }
}

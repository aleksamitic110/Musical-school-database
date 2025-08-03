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
    public partial class IzmeniProizvodDodatakZaLutkuForma : Form
    {
        DodatakZaLutkuBasic dodatakLutka;

        public IzmeniProizvodDodatakZaLutkuForma()
        {
            InitializeComponent();
        }

        public IzmeniProizvodDodatakZaLutkuForma(DodatakZaLutkuBasic dl)
        {
            InitializeComponent();
            dodatakLutka = dl;
            popuniPodacima();
        }

        public void popuniPodacima()
        {
            txbNaziv.Text = dodatakLutka.Naziv;
            txbProizvodjac.Text = dodatakLutka.Proizvodjac;
            txbNazivDodatka.Text = dodatakLutka.NazivDodatka;
            txbTipDodatka.Text = dodatakLutka.TipDodatka;
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            dodatakLutka.Naziv = txbNaziv.Text;
            dodatakLutka.Proizvodjac = txbProizvodjac.Text;
            dodatakLutka.NazivDodatka = txbNazivDodatka.Text;
            dodatakLutka.TipDodatka = txbTipDodatka.Text;

            DTOManager.azurirajDodatakZaLutku(dodatakLutka);
            this.Close();
        }
    }
}

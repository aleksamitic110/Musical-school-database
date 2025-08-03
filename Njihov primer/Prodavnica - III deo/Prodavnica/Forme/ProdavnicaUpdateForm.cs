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
    public partial class ProdavnicaUpdateForm : Form
    {
        public ProdavnicaBasic prodavnica;

        public ProdavnicaUpdateForm()
        {
            InitializeComponent();
        }

        public ProdavnicaUpdateForm(ProdavnicaBasic p)
        {
            InitializeComponent();
            this.prodavnica = p;
        }

        private void ProdavnicaUpdateForm_Load(object sender, EventArgs e)
        {
            popuniPodacima();
            this.Text = $"AZURIRANJE PRODAVNICE {prodavnica.Naziv.ToUpper()}";
        }

        public void popuniPodacima()
        {
            txbNaziv.Text = this.prodavnica.Naziv;
            txbAdresa.Text = this.prodavnica.Adresa;
            txbBrojTelefona.Text = this.prodavnica.BrojTelefona;
            txbRadniDani.Text = this.prodavnica.RadniDan;
            txbSubota.Text = this.prodavnica.Subota;
            txbNedelja.Text = this.prodavnica.Nedelja;
        }

        private void btnAzuriraj_Click(object sender, EventArgs e)
        {
            string poruka = "Da li zelite da izvrsite izmene prodavnice?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);
            if (result == DialogResult.OK)
            {
                this.prodavnica.Naziv = txbNaziv.Text;
                this.prodavnica.Adresa = txbAdresa.Text;
                this.prodavnica.BrojTelefona = txbBrojTelefona.Text;
                this.prodavnica.RadniDan = txbRadniDani.Text;
                this.prodavnica.Subota = txbSubota.Text;
                this.prodavnica.Nedelja = txbNedelja.Text;

                DTOManager.azurirajProdavnicu(this.prodavnica);
                MessageBox.Show("Azuriranje prodavnice je uspesno izvrseno!");
                this.Close();
            }
            else
            {

            }
        }
    }
}

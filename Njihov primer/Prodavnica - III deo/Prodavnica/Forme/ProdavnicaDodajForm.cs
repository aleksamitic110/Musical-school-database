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
    public partial class ProdavnicaDodajForm : Form
    {
        ProdavnicaBasic prodavnica;

        public ProdavnicaDodajForm()
        {
            InitializeComponent();
            prodavnica = new ProdavnicaBasic();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            string poruka = "Da li zelite da dodate novu prodavnicu?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                this.prodavnica.Naziv = txbNaziv.Text;
                this.prodavnica.Adresa = txbBrojTelefona.Text;
                this.prodavnica.BrojTelefona = txbAdresa.Text;
                this.prodavnica.RadniDan = txbRadniDani.Text;
                this.prodavnica.Subota = txbSubota.Text;
                this.prodavnica.Nedelja = txbNedelja.Text;

                DTOManager.dodajProdavnicu(this.prodavnica);
                MessageBox.Show("Uspesno ste dodali novu prodavnicu!");
                this.Close();
            }
            else
            {

            }
        }
    }
}

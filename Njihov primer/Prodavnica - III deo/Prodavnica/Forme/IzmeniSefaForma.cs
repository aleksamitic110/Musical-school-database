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
    public partial class IzmeniSefaForma : Form
    {
        RadnikBasic sef;

        public IzmeniSefaForma()
        {
            InitializeComponent();
        }

        public IzmeniSefaForma(RadnikBasic s)
        {
            InitializeComponent();
            sef = s;
            popuniPodacima();
        }

        public void popuniPodacima()
        {
            txbIme.Text = sef.Ime;
            txbMbr.Text = sef.Mbr.ToString();
            txbMbr.Enabled = false;
            txbPrezime.Text = sef.Prezime;
            txbSrednjeSlovo.Text = sef.SrednjeSlovo.ToString();
            txbStrucnaSprema.Text = sef.StrucnaSpema;
            datumRodjenja.Value = sef.DatumRodjenja;
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            sef.Ime = txbIme.Text;
            sef.SrednjeSlovo = Char.Parse(txbSrednjeSlovo.Text);
            sef.Prezime = txbPrezime.Text;
            sef.StrucnaSpema = txbStrucnaSprema.Text;
            sef.DatumRodjenja = datumRodjenja.Value;
            //radnik.Sef = false;
            
            DTOManager.azurirajSefa(sef);
            MessageBox.Show("Uspesno ste izmenili podatke o sefu!");
            this.Close();
        }
    }
}

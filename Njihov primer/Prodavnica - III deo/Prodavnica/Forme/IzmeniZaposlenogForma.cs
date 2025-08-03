using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Prodavnica.Forme
{
    public partial class IzmeniZaposlenogForma : Form
    {
        RadnikBasic radnik;
        public IzmeniZaposlenogForma()
        {
            InitializeComponent();
        }
        public IzmeniZaposlenogForma(RadnikBasic r)
        {
            InitializeComponent();
            radnik = r;
            popuniPodacima();
        }
        public void popuniPodacima()
        {
            txbIme.Text = radnik.Ime;
            txbMbr.Text = radnik.Mbr.ToString();
            txbMbr.Enabled = false;
            txbPrezime.Text = radnik.Prezime;
            txbSrednjeSlovo.Text = radnik.SrednjeSlovo.ToString();
            txbStrucnaSprema.Text = radnik.StrucnaSpema;
            datumRodjenja.Value = radnik.DatumRodjenja;
        }  
           
        private void button1_Click(object sender, EventArgs e)
        {radnik.Ime = txbIme.Text;
            radnik.SrednjeSlovo = Char.Parse(txbSrednjeSlovo.Text);
            radnik.Prezime = txbPrezime.Text;
            radnik.StrucnaSpema = txbStrucnaSprema.Text;
            radnik.DatumRodjenja = datumRodjenja.Value;
            //radnik.Sef = false;
            
            DTOManager.azurirajRadnika(radnik);
            MessageBox.Show("Uspesno ste izmenili podatke o zaposlenom!");
            this.Close();
        }
    }
}

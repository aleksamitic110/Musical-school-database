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
    public partial class DodajOdeljenjeOdrasliForma : Form
    {
        ProdavnicaBasic prodavnica;
        public DodajOdeljenjeOdrasliForma()
        {
            InitializeComponent();
        }
        public DodajOdeljenjeOdrasliForma(ProdavnicaBasic p)
        {
            InitializeComponent();
            prodavnica = p;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OdeljenjeOdrasliBasic o = new OdeljenjeOdrasliBasic();
            o.Lokacija = txbLokacija.Text;
            o.BrojKasa = (int)brojKasa.Value;
            if (chbPult.Checked == true)
                o.infoPult = "Da";
            else
                o.infoPult = "Ne";
            o.Prodavnica = prodavnica;
            DTOManager.sacuvajOdeljenjeOdrasli(o);
            MessageBox.Show("Uspesno ste dodali novo odeljenje!");
            this.Close();

        }
       
       

       







     
    }
}

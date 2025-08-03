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
    public partial class DodajOdeljenjeOd6Do15Forma : Form
    {
        ProdavnicaBasic prodavnica;
        public DodajOdeljenjeOd6Do15Forma()
        {
            InitializeComponent();
        }
        public DodajOdeljenjeOd6Do15Forma(ProdavnicaBasic p)
        {
            InitializeComponent();
            prodavnica = p;
        }

        private void DodajOdeljenjeOd6Do15Forma_Load(object sender, EventArgs e)
        {

        }
      
        
       

     

       

        private void button1_Click_1(object sender, EventArgs e)
        {
            OdeljenjeOd6Do15Basic o = new OdeljenjeOd6Do15Basic();
            o.Lokacija = txbLokacija.Text;
            o.BrojKasa = (int)brojKasa.Value;
            if (chbPult.Checked == true)
                o.infoPult = "Da";
            else
                o.infoPult = "Ne";
            o.Prodavnica = prodavnica;
            DTOManager.sacuvajOdeljenjeOd6Do15(o);
            MessageBox.Show("Uspesno ste dodali novo odeljenje!");
            this.Close();
        }
    }
}

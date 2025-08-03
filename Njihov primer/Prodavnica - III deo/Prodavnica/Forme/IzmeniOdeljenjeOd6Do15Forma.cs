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
    public partial class IzmeniOdeljenjeOd6Do15Forma : Form
    {
        OdeljenjeOd6Do15Basic odeljenje;
        public IzmeniOdeljenjeOd6Do15Forma()
        {
            InitializeComponent();
        }
        public IzmeniOdeljenjeOd6Do15Forma(OdeljenjeOd6Do15Basic o)
        {
            InitializeComponent();
            odeljenje = o;
        }
        private void IzmeniOdeljenjeOd6Do15Forma_Load(object sender, EventArgs e)
        {
            popuniPodacima();
        }
        
        public void popuniPodacima()
        {
            txbLokacija.Text = odeljenje.Lokacija;
            brojKasa.Value = odeljenje.BrojKasa;
            if (odeljenje.infoPult == "Da")
                chbPult.Checked = true;
            else
                chbPult.Checked = false;
        }

      

        private void button1_Click_1(object sender, EventArgs e)
        {
            odeljenje.Lokacija = txbLokacija.Text;
            odeljenje.BrojKasa = (int)brojKasa.Value;
            if (chbPult.Checked == true)
                odeljenje.infoPult = "Da";
            else
                odeljenje.infoPult = "Ne";
            DTOManager.izmeniOdeljenjeOd6Do15(odeljenje);
            MessageBox.Show("Uspesno ste izmenili odeljenje!");
            this.Close();

        }
    }
   

        
    
}

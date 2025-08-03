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
    public partial class IzmeniOdeljenjeOdrasliForm : Form
    {
        OdeljenjeOdrasliBasic odeljenje;
        public IzmeniOdeljenjeOdrasliForm()
        {
            InitializeComponent();
        }
        public IzmeniOdeljenjeOdrasliForm(OdeljenjeOdrasliBasic o)
        {
            InitializeComponent();
            odeljenje = o;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

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



       

        private void IzmeniOdeljenjeOdrasliForm_Load(object sender, EventArgs e)
        {
            popuniPodacima();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            odeljenje.Lokacija = txbLokacija.Text;
            odeljenje.BrojKasa = (int)brojKasa.Value;
            if (chbPult.Checked == true)
                odeljenje.infoPult = "Da";
            else
                odeljenje.infoPult = "Ne";
            DTOManager.izmeniOdeljenjeOdrasli(odeljenje);
            MessageBox.Show("Uspesno ste izmenili odeljenje!");
            this.Close();
        }
    }
}


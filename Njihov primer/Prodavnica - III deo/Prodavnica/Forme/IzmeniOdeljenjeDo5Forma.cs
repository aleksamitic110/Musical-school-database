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
    public partial class IzmeniOdeljenjeDo5Forma : Form
    {
        OdeljenjeDo5Basic odeljenje;
        public IzmeniOdeljenjeDo5Forma()
        {
            InitializeComponent();
        }
        public IzmeniOdeljenjeDo5Forma(OdeljenjeDo5Basic o)
        {
            InitializeComponent();
            odeljenje = o;
        }

        private void IzmeniOdeljenjeDo5Forma_Load(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            odeljenje.Lokacija = txbLokacija.Text;
            odeljenje.BrojKasa = (int)brojKasa.Value;
            if (chbPult.Checked == true)
                odeljenje.infoPult = "Da";
            else
                odeljenje.infoPult = "Ne";
            DTOManager.izmeniOdeljenjeDo5(odeljenje);
            MessageBox.Show("Uspesno ste izmenili odeljenje!");
            this.Close();

        }
    }
}

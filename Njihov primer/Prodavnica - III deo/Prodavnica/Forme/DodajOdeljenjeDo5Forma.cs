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
    public partial class DodajOdeljenjeDo5Forma : Form
    {
        ProdavnicaBasic prodavnica;
        public DodajOdeljenjeDo5Forma()
        {
            InitializeComponent();
        }
        public DodajOdeljenjeDo5Forma(ProdavnicaBasic p)
        {
            InitializeComponent();
            prodavnica = p;
        }

        private void DodajOdeljenjeDo5Forma_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OdeljenjeDo5Basic o = new OdeljenjeDo5Basic();
            o.Lokacija = txbLokacija.Text;
            o.BrojKasa = (int)brojKasa.Value;
            if (chbPult.Checked == true)
                o.infoPult = "Da";
            else
                o.infoPult = "Ne";
            o.Prodavnica = prodavnica;
            DTOManager.sacuvajOdeljenjeDo5(o);
            MessageBox.Show("Uspesno ste dodali novo odeljenje!");
            this.Close();

        }
    }
}

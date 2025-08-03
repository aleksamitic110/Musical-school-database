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
    public partial class IzmeniRadniOdnosForma : Form
    {
        RadiUBasic radi;
        public IzmeniRadniOdnosForma()
        {
            InitializeComponent();
        }
        public IzmeniRadniOdnosForma(RadiUBasic r)
        {
            InitializeComponent();
            radi = r;
            popuniPodacima();
        }
        public void popuniPodacima()
        {
            datumOd.Value = radi.DatumOd;
            if (radi.DatumDo == null)
                chbDatumDo.Checked = true;
            else
            {
                chbDatumDo.Checked = false;
                DatumDo.Value = (DateTime)radi.DatumDo;
            }


        }
        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void omoguciDatumDo(object sender, EventArgs e)
        {
            if (chbDatumDo.Checked == true)
                DatumDo.Enabled = false;
            else
                DatumDo.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            radi.DatumOd = datumOd.Value;
            if (chbDatumDo.Checked == true)
                radi.DatumDo = null;
            else
                radi.DatumDo = (DateTime?)DatumDo.Value;
            DTOManager.izmeniRadniOdnos(radi);
            MessageBox.Show("Uspesno ste izmenili podatke o radnom odnosu!");
            this.Close();
        }
    }
}

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
    public partial class DodajProizvodDo5Forma : Form
    {
        OdeljenjeBasic odeljenje;

        public DodajProizvodDo5Forma()
        {
            InitializeComponent();
        }

        public DodajProizvodDo5Forma(OdeljenjeBasic o)
        {
            InitializeComponent();
            odeljenje = o;
        }

        private void btnOdaberi_Click(object sender, EventArgs e)
        {
            if (rdbIgrackePlastika.Checked)
            {
                DodajProizvodIgrackePlastikaForma forma = new DodajProizvodIgrackePlastikaForma(odeljenje);
                forma.ShowDialog();
            }
        }
    }
}

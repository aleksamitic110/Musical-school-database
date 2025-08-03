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
    public partial class PocetnaStranica : Form
    {
        public PocetnaStranica()
        {
            InitializeComponent();
        }

        private void btnProdavnice_Click(object sender, EventArgs e)
        {
            ProdavniceForm forma = new ProdavniceForm();
            forma.ShowDialog();
        }

        private void btnZaposleni_Click(object sender, EventArgs e)
        {
            SviZaposleniForma forma = new SviZaposleniForma();
            forma.ShowDialog();
        }

        private void btnIgracke_Click(object sender, EventArgs e)
        {
            SviProizvodiForma forma = new SviProizvodiForma();
            forma.ShowDialog();
        }
    }
}

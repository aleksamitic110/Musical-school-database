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
    public partial class DodajProizvodOdrasliForma : Form
    {
        OdeljenjeBasic odeljenje;

        public DodajProizvodOdrasliForma()
        {
            InitializeComponent();
        }

        public DodajProizvodOdrasliForma(OdeljenjeBasic o)
        {
            InitializeComponent();
            odeljenje = o;
        }

        private void btnOdaberi_Click(object sender, EventArgs e)
        {
            if (rdbPuzzle.Checked)
            {
                DodajProizvodPuzzleForma forma = new DodajProizvodPuzzleForma(odeljenje);
                forma.ShowDialog();
            }
        }
    }
}

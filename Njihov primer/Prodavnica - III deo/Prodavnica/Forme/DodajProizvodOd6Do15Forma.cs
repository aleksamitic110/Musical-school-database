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
    public partial class DodajProizvodOd6Do15Forma : Form
    {
        OdeljenjeBasic odeljenje;

        public DodajProizvodOd6Do15Forma()
        {
            InitializeComponent();
        }

        public DodajProizvodOd6Do15Forma(OdeljenjeBasic o)
        {
            InitializeComponent();
            odeljenje = o;
        }

        private void btnOdaberi_Click(object sender, EventArgs e)
        {
            if(rdbAutomobili.Checked)
            {
                DodajProizvodAutomobiliForma forma = new DodajProizvodAutomobiliForma(odeljenje);
                forma.ShowDialog();
            }
            else if(rdbVojnici.Checked)
            {
                DodajProizvodVojniciForma forma = new DodajProizvodVojniciForma(odeljenje);
                forma.ShowDialog();
            }
            else if (rdbLutke.Checked)
            {
                DodajProizvodLutkeForma forma = new DodajProizvodLutkeForma(odeljenje);
                forma.ShowDialog();
            }
            else if (rdbDodaciZaLutke.Checked)
            {
                DodajProizvodDodaciZaLutkeForma forma = new DodajProizvodDodaciZaLutkeForma(odeljenje);
                forma.ShowDialog();
            }
        }
    }
}

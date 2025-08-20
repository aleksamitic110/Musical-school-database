using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Muzicka_skola.Forme.Kursevi
{
    public partial class DodajPredmet : Form
    {
        public DodajPredmet()
        {
            InitializeComponent();
        }
        private GlobalForm _globalForm;
        private char selektovanKurs;
        public DodajPredmet(GlobalForm globalForm, char x)
        {
            InitializeComponent();
            _globalForm = globalForm;
            selektovanKurs = x;
            if (selektovanKurs == 'T')
            {
                label1.Text = "Predmet";
            } 
            else if (selektovanKurs == 'V')
            {
                label1.Text = "Tip Pevanja";
            } 
            else if (selektovanKurs == 'I')
            {
                label1.Text = "Instrument";
            }
        }

        private void DodajPredmet_Load(object sender, EventArgs e)
        {
            var kursevi = DTOManager.vratiSveKurseve(); // returns list of DTOs
            comboBox1.DataSource = kursevi;
            comboBox1.DisplayMember = "Id"; // what user sees
            comboBox1.ValueMember = "Id";      // actual value stored
        }
    }
}

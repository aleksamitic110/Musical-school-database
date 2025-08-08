using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Muzicka_skola.Forme.Kursevi
{
    public partial class DodajKurs : Form
    {
        private GlobalForm _globalForm;
        public DodajKurs(GlobalForm globalForm)
        {
            InitializeComponent();
            _globalForm = globalForm;
        }

        private void dodajKursButton_Click(object sender, EventArgs e)
        {
            
            bool nivoChecked =
            napredni.Checked || srednji.Checked || pocetni.Checked;

            bool tipNastaveChecked =
                grupna.Checked || individualna.Checked;

            if (!JMBGNastavnikaTextBox.Text.All(char.IsDigit))
            {
                MessageBox.Show("JMBG nije validan");
                return;
            }
            if (string.IsNullOrWhiteSpace(JMBGNastavnikaTextBox.Text) 
                || string.IsNullOrWhiteSpace(nazivKursaTextBox.Text)
                || string.IsNullOrWhiteSpace(idFilijalaTextBox.Text) 
                || string.IsNullOrWhiteSpace(idKursaTextBox.Text)
                || !nivoChecked
                || !tipNastaveChecked)
            {
                MessageBox.Show("Nisu sva polja popunjena");
                return;
            }
            MessageBox.Show("Radi");
            return;
        }
    }


}

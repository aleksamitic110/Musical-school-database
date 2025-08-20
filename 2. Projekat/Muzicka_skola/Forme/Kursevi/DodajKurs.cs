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
            if (string.IsNullOrWhiteSpace(idKursaTextBox.Text))
            {
                MessageBox.Show("ID kursa mora biti unet");
                return;
            }

            if (DTOManager.nadjiKurs(idKursaTextBox.Text) != null)
            {
                MessageBox.Show("ID kursa već postoji");
                return;
            }

            if (string.IsNullOrWhiteSpace(nazivKursaTextBox.Text))
            {
                MessageBox.Show("Naziv kursa mora biti unet");
                return;
            }

            
            if (idFilijalaComboBox.SelectedItem == null)
            {
                MessageBox.Show("Morate izabrati filijalu");
                return;
            }

            
            if (jmbgNastavnikaComboBox.SelectedItem == null)
            {
                MessageBox.Show("Morate izabrati nastavnika");
                return;
            }

            
            if (!(napredni.Checked || srednji.Checked || pocetni.Checked))
            {
                MessageBox.Show("Morate izabrati nivo kursa");
                return;
            }
            string nivo = groupBox1.Controls
            .OfType<System.Windows.Forms.RadioButton>()
            .FirstOrDefault(r => r.Checked)?.Text;
            //proverava koji je selektovan u grupi

            if (!(grupna.Checked || individualna.Checked))
            {
                MessageBox.Show("Morate izabrati tip nastave");
                return;
            }

            string tipNastave = groupBox2.Controls
            .OfType<System.Windows.Forms.RadioButton>()
            .FirstOrDefault(r => r.Checked)?.Text;
            //proverava koji je selektovan u grupi

            

            var noviKurs = new KursDTO()
            {
                Id = idKursaTextBox.Text,
                Naziv = nazivKursaTextBox.Text,
                Nivo = nivo,
                TipNastave = tipNastave,
                Filijala = (string)idFilijalaComboBox.SelectedValue,
                Nastavnik = (int)jmbgNastavnikaComboBox.SelectedValue
            };

            DTOManager.addKurs(noviKurs);
            _globalForm.prikaziPodKurs();
            Close();
        }

        private void DodajKurs_Load(object sender, EventArgs e)
        {
            //TODO Filijale return

            // Load Filijale IDs
            var filijale = DTOManager.vratiSveFilijale(); // returns list of DTOs
            idFilijalaComboBox.DataSource = filijale;
            idFilijalaComboBox.DisplayMember = "Id"; // what user sees
            idFilijalaComboBox.ValueMember = "Id";      // actual value stored

            // Load Nastavnici JMBGs
            var nastavnici = DTOManager.PrikaziSveNastavnike();
            jmbgNastavnikaComboBox.DataSource = nastavnici;
            jmbgNastavnikaComboBox.DisplayMember = "JMBG"; // what user sees
            jmbgNastavnikaComboBox.ValueMember = "Id";         // actual JMBG
        }
    }


}

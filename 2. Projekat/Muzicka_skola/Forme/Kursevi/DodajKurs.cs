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
            setPanelVisibleFalse();
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

            if (!(teorijski.Checked || instrumentalni.Checked || vokalni.Checked))
            {
                MessageBox.Show("Morate izabrati pod tip kursa");
                return;
            }

            string podTipKursa = groupBox3.Controls
            .OfType<System.Windows.Forms.RadioButton>()
            .FirstOrDefault(r => r.Checked)?.Text.ToLower();

            if (podTipKursa == "instrumentalni")
            {
                var Kurs = new KursInstrumentalniDTO(
                    idKursaTextBox.Text,
                    nazivKursaTextBox.Text,
                    nivo.ToLower(),
                    tipNastave.ToLower().Split(' ')[0],
                    (string)idFilijalaComboBox.SelectedValue,
                    (int)jmbgNastavnikaComboBox.SelectedValue,
                    textBoxInstrument.Text
                );
                DTOManager.addKurs(Kurs);
            }

            else if (podTipKursa == "teorijski")
            {

                var Kurs = new KursTeorijskiDTO(
                    idKursaTextBox.Text,
                    nazivKursaTextBox.Text,
                    nivo.ToLower(),
                    tipNastave.ToLower().Split(' ')[0],
                    (string)idFilijalaComboBox.SelectedValue,
                    (int)jmbgNastavnikaComboBox.SelectedValue,
                    textBoxNazivPredmeta.Text
                );

                DTOManager.addKurs(Kurs);
            }

            else if (podTipKursa == "vokalni")
            {
                string tipPevanja = panelVokalni.Controls
                .OfType<System.Windows.Forms.RadioButton>()
                .FirstOrDefault(r => r.Checked)?.Text.ToLower();
                var Kurs = new KursVokalniDTO(
                    idKursaTextBox.Text,
                    nazivKursaTextBox.Text,
                    nivo.ToLower(),
                    tipNastave.ToLower().Split(' ')[0],
                    (string)idFilijalaComboBox.SelectedValue,
                    (int)jmbgNastavnikaComboBox.SelectedValue,
                    tipPevanja
                );
                DTOManager.addKurs(Kurs);
            }

            
            _globalForm.prikaziPodKurs();
            Close();
        }

        private void DodajKurs_Load(object sender, EventArgs e)
        {
            

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

        private void setPanelVisibleFalse()
        {
            panelInstrumentalni.Visible = false;
            panelTeorijski.Visible = false;
            panelVokalni.Visible = false;
        }

        private void instrumentalni_CheckedChanged(object sender, EventArgs e)
        {
            if (instrumentalni.Checked)
            {
                setPanelVisibleFalse();
                panelInstrumentalni.Visible = true;
                panelInstrumentalni.BringToFront();
                panelInstrumentalni.Show();
            }
        }

        private void teorijski_CheckedChanged(object sender, EventArgs e)
        {
            if (teorijski.Checked)
            {
                setPanelVisibleFalse();
                panelTeorijski.Visible = true;
                panelTeorijski.BringToFront();
                panelTeorijski.Show();
            }
        }

        private void vokalni_CheckedChanged(object sender, EventArgs e)
        {
            if (vokalni.Checked)
            {
                setPanelVisibleFalse();
                panelVokalni.Visible = true;
                panelVokalni.BringToFront();
                panelVokalni.Show();
            }
        }

    }


}

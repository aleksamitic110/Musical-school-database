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
    public partial class UpdateKurs : Form
    {
        private GlobalForm _globalForm;
        private KursDTO Kurs;
        private char Tip;
        public UpdateKurs(GlobalForm globalForm,KursDTO kurs)
        {
            InitializeComponent();
            _globalForm = globalForm;
            Kurs = kurs;
            setPanelVisibleCorrect();
            labelKursID.Text = Kurs.Id;
        }

        private void setPanelVisibleFalse()
        {
            panelInstrumentalni.Visible = false;
            panelTeorijski.Visible = false;
            panelVokalni.Visible = false;
            napredni.Checked = false;
            srednji.Checked = false;
            pocetni.Checked = false;
            individualna.Checked = false;
            grupna.Checked = false;
            textBoxNaziv.Text = "";
            textBoxInstrument.Text = "";
            textBoxPredmet.Text = "";
            individualnoPod.Checked = false;
            horsko.Checked = false;
        }

        private void setPanelVisibleCorrect()
        {
            setPanelVisibleFalse();

            var kI = DTOManager.nadjiKursI(Kurs.Id);
            var kV = DTOManager.nadjiKursV(Kurs.Id);
            var kT = DTOManager.nadjiKursT(Kurs.Id);

            if (kI != null)
            {
                panelInstrumentalni.Visible = true;
                panelInstrumentalni.BringToFront();
                Tip = 'I';
                textBoxInstrument.Text = kI.Instrumenti;
            }
            else if (kV != null)
            {
                panelVokalni.Visible = true;
                panelVokalni.BringToFront();
                Tip = 'V';
                if (kV.TipPevanja == "individualno") 
                {
                    individualnoPod.Checked = true;
                }
                else if (kV.TipPevanja == "horsko")
                {
                    horsko.Checked = true;
                }
            }
            else if (kT != null)
            {
                panelTeorijski.Visible = true;
                panelTeorijski.BringToFront();
                Tip = 'T';
                textBoxPredmet.Text = kT.NazivPredmeta;
            }
            else
            {
                MessageBox.Show("Greska Pri ucitavanju");
                Close();
            }

            loadValue();
        }

        private void loadValue()
        {
            textBoxNaziv.Text = Kurs.Naziv;

            if (Kurs.Nivo == "napredni")
            {
                napredni.Checked = true;
            } else if (Kurs.Nivo == "srednji")
            {
                srednji.Checked = true;
            } else if (Kurs.Nivo == "pocetni")
            {
                pocetni.Checked = true;
            }

            if (Kurs.TipNastave == "individualna")
            {
                individualna.Checked = true;
            } else if (Kurs.TipNastave == "grupna")
            {
                grupna.Checked = true;
            }

            idFilijalaComboBox.SelectedValue = Kurs.Filijala;

            jmbgNastavnikaComboBox.SelectedValue = Kurs.Nastavnik;


        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(textBoxNaziv.Text))
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

            KursDTO updatedKurs = null;

            if (Tip == 'I')
            {
                updatedKurs = new KursInstrumentalniDTO(
                    Kurs.Id,
                    textBoxNaziv.Text,
                    nivo.ToLower(),
                    tipNastave.ToLower().Split(' ')[0],
                    (string)idFilijalaComboBox.SelectedValue,
                    (int)jmbgNastavnikaComboBox.SelectedValue,
                    textBoxInstrument.Text
                    );
            }
            else if (Tip == 'V')
            {

                string tipPevanja = panelVokalni.Controls
                .OfType<System.Windows.Forms.RadioButton>()
                .FirstOrDefault(r => r.Checked)?.Text.ToLower();
                updatedKurs = new KursVokalniDTO(
                    Kurs.Id,
                    textBoxNaziv.Text,
                    nivo.ToLower(),
                    tipNastave.ToLower(),
                    (string)idFilijalaComboBox.SelectedValue,
                    (int)jmbgNastavnikaComboBox.SelectedValue,
                    tipPevanja
                );
            }
            else if (Tip == 'T')
            {
                updatedKurs = new KursTeorijskiDTO(
                    Kurs.Id,
                    textBoxNaziv.Text,
                    nivo.ToLower(),
                    tipNastave.ToLower().Split(' ')[0],
                    (string)idFilijalaComboBox.SelectedValue,
                    (int)jmbgNastavnikaComboBox.SelectedValue,
                    textBoxPredmet.Text
                    );
            }

            

            DTOManager.updateKurs(updatedKurs);
            _globalForm.prikaziPodKurs();
            Close();
        }

        private void UpdateKurs_Load(object sender, EventArgs e)
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
    }
}

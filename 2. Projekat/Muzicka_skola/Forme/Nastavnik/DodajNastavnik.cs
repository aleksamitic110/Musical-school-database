using Muzicka_skola.Entiteti;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Muzicka_skola.Forme
{
    public partial class DodajNastavnik : Form
    {
        private GlobalForm _globalForm;
        public DodajNastavnik(GlobalForm globalForm)
        {
            InitializeComponent();
            _globalForm = globalForm;
        }

        private void RadioButtons_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButtonHonorarni.Checked)
            {
                panelHonorarni.Show();
                panelHonorarni.BringToFront();
                panelStalni.Hide();

            }
            else if (radioButtonStalni.Checked)
            {
                panelHonorarni.Hide();
                panelStalni.Show();
                panelStalni.BringToFront();

            }
        }

        

        private void buttonObrisiBroj_Click(object sender, EventArgs e)
        {
            if (listBoxDodatiBrojevi.SelectedItem != null)
            {
                listBoxDodatiBrojevi.Items.Remove(listBoxDodatiBrojevi.SelectedItem);
            }
            else
            {
                MessageBox.Show("Izaberi broj za brisanje");
            }
        }

        private void buttonDodajBroj_Click(object sender, EventArgs e)
        {
            string input = textBoxBrojTelefona.Text.Trim();
            if (listBoxDodatiBrojevi.Items.Count >= 3)
            {
                MessageBox.Show("Moguce je upisati najvise 3 broja");
                return;
            }
            if (!textBoxBrojTelefona.Text.All(char.IsDigit) || string.IsNullOrEmpty(input))
            {
                MessageBox.Show("Broj telefona nije validan");
                return;
            }

            foreach (var item in listBoxDodatiBrojevi.Items)
            {
                if (item.ToString() == input)
                {
                    MessageBox.Show("Taj broj telefona je već dodat");
                    return;
                }
            }

            listBoxDodatiBrojevi.Items.Add(input);
            textBoxBrojTelefona.Clear();
        }

        private void ButtonDodajNastavnika_Click(object sender, EventArgs e)
        {
            if (!textBoxJMBG.Text.All(char.IsDigit) || !textBoxJMBGMentora.Text.All(char.IsDigit))
            {
                MessageBox.Show("JMBG nije validan");
                return;
            }
            if (string.IsNullOrWhiteSpace(textBoxJMBG.Text) || string.IsNullOrWhiteSpace(textBoxIme.Text)
                || string.IsNullOrWhiteSpace(textBoxPrezime.Text) || string.IsNullOrWhiteSpace(textBoxAdresa.Text)
                || string.IsNullOrWhiteSpace(textBoxMail.Text) || listBoxDodatiBrojevi.Items.Count == 0
                || string.IsNullOrWhiteSpace(textBoxStrucnaSprema.Text))
            {
                MessageBox.Show("Nisu sva polja popunjena");
                return;
            }
            if (radioButtonHonorarni.Checked)
            {
                if (string.IsNullOrEmpty(textBoxBrojUgovora.Text) || numericUpDownBrojCasova.Value <= 0)
                {
                    MessageBox.Show("Nisu sva polja popunjena za honorarnog radnika");
                    return;
                }
                if (PickerTrajanjeUgovora.Value < PickerDatumZaposlenja.Value)
                {
                    MessageBox.Show("Trajanje ugovora nije validno");
                    return;
                }
            }
            if (radioButtonStalni.Checked)
            {
                if(pickerRadnoVremeDo.Value < pickerRadnoVremeOd.Value || pickerRadnoVremeOd.Value.ToString("HH:mm") == pickerRadnoVremeDo.Value.ToString("HH:mm"))
                {
                    MessageBox.Show("Radno vreme nije validno");
                    return;
                }
            }

            var osoba = new OsobaBasic
            {
                JMBG = textBoxJMBG.Text,
                Ime = textBoxIme.Text,
                Prezime = textBoxPrezime.Text,
                Adresa = textBoxAdresa.Text,
                Mail = textBoxMail.Text
            };

            foreach (var item in listBoxDodatiBrojevi.Items)
            {
                osoba.Telefoni.Add(new TelefonBasic { BrojTelefona = item.ToString() });
            }
            var nastavnik = new NastavnikBasic
            {
                StrucnaSprema = textBoxStrucnaSprema.Text,
                DatumZaposlenja = PickerDatumZaposlenja.Value,
            };

            string sacuvanaOsobaJMBG = DTOManager.sacuvajOsobu(osoba);
            int nastavnikId = DTOManager.SacuvajNastavnika(nastavnik, sacuvanaOsobaJMBG);

            if (radioButtonHonorarni.Checked)
            {
                var honorarni = new HonorarniBasic
                {
                    BrojUgovora = textBoxBrojUgovora.Text,
                    BrojCasovaMesecno = (int)numericUpDownBrojCasova.Value,
                    TrajanjeUgovora = PickerTrajanjeUgovora.Value
                };
                DTOManager.SacuvajHonorarnogNastavnika(honorarni, nastavnikId);
            }
            else if (radioButtonStalni.Checked)
            {
                string radnoVreme = pickerRadnoVremeOd.Value.ToString("HH:mm") + " - " + pickerRadnoVremeDo.Value.ToString("HH:mm");
                string mentorJMBG = textBoxJMBGMentora.Text;
                var stalni = new StalniBasic
                {
                    RadnoVreme = radnoVreme,
                    StatusMentora = checkBoxMentor.Checked
                };
                DTOManager.SacuvajStalnog(stalni, nastavnikId, mentorJMBG);
            }
            MessageBox.Show("Nastavnik uspesno dodat!");
            _globalForm.PrikaziNastavnikeUDataGrid();
            Close();
        }
    }
}

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
    public partial class AddNastavnik : Form
    {
        public AddNastavnik()
        {
            InitializeComponent();
        }

        private void textBoxBrojTelefonaOnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
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

                listBoxDodatiBrojevi.Items.Add(input);
                textBoxBrojTelefona.Clear();
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
           if(string.IsNullOrWhiteSpace(textBoxJMBG.Text) || string.IsNullOrWhiteSpace(textBoxIme.Text)
                || string.IsNullOrWhiteSpace(textBoxPrezime.Text) || string.IsNullOrWhiteSpace(textBoxAdresa.Text)
                || string.IsNullOrWhiteSpace(textBoxMail.Text) || listBoxDodatiBrojevi.Items.Count == 0 
                || string.IsNullOrWhiteSpace(textBoxStrucnaSprema.Text))
            {
                MessageBox.Show("Nisu sva polja popunjena");
                return;
            }
            if (radioButtonHonorarni.Checked)
            {
                if(string.IsNullOrEmpty(textBoxBrojUgovora.Text) || numericUpDownBrojCasova.Value <= 0)
                {
                    MessageBox.Show("Nisu sva polja popunjena za honorarnog radnika");
                    return;
                }
            }
            if (radioButtonStalni.Checked)
            {
                if(string.IsNullOrEmpty(textBoxRadnoVremeDo.Text) || string.IsNullOrEmpty(textBoxRadnoVremeOd.Text))
                {
                    MessageBox.Show("Nisu sva polja popunjena za stalnog radnika");
                    return;
                }
            }
            if(PickerTrajanjeUgovora.Value < PickerDatumZaposlenja.Value && radioButtonHonorarni.Checked)
            {
                MessageBox.Show("Trajanje ugovora nije validno");
                return;
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
            int nastavnikId = DTOManager.sacuvajNastavnika(nastavnik, sacuvanaOsobaJMBG);

            if (radioButtonHonorarni.Checked)
            {
                var honorarni = new HonorarniBasic
                {
                    BrojUgovora = textBoxBrojUgovora.Text,
                    BrojCasovaMesecno = (int)numericUpDownBrojCasova.Value,
                    TrajanjeUgovora = PickerTrajanjeUgovora.Value
                };
                DTOManager.sacuvajHonorarnogNastavnika(honorarni, nastavnikId);
            }
            else if (radioButtonStalni.Checked)
            {
                string radnoVreme = textBoxRadnoVremeOd.Text + " - " + textBoxRadnoVremeDo.Text;
                string mentorJMBG = textBoxJMBGMentora.Text;
                var stalni = new StalniBasic
                {
                    RadnoVreme = radnoVreme,
                    StatusMentora = checkBoxMentor.Checked
                };
                DTOManager.sacuvajStalnog(stalni, nastavnikId, mentorJMBG);
            }
            this.Close();
        }

        private void ObrisiBroj_Click(object sender, EventArgs e)
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
    }
}

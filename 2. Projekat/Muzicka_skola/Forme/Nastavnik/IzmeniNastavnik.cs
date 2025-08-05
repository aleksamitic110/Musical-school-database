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

namespace Muzicka_skola.Forme.Nastavnik
{
    public partial class IzmeniNastavnik : Form
    {
        private GlobalForm _globalForm;
        private NastavnikDTO _nastavnik;
        private Honorarni _honorarni;
        private Stalni _stalni;
        public IzmeniNastavnik(GlobalForm globalForm, NastavnikDTO nastavnik)
        {
            InitializeComponent();
            _globalForm = globalForm;
            _nastavnik = nastavnik;
            UcitajNastavnika();
        }

        private void UcitajNastavnika()
        {
            textBoxJMBG.Text = _nastavnik.JMBG;
            textBoxAdresa.Text = _nastavnik.Adresa;
            textBoxMail.Text = _nastavnik.Mail;
            textBoxIme.Text = _nastavnik.Ime;
            textBoxPrezime.Text = _nastavnik.Prezime;
            textBoxStrucnaSprema.Text = _nastavnik.StrucnaSprema;
            PickerDatumZaposlenja.Value = _nastavnik.DatumZaposlenja;
            string[] brojevi = _nastavnik.Telefoni.Split(',');
            foreach (string broj in brojevi)
            {
                if (!string.IsNullOrEmpty(broj))
                {
                    listBoxDodatiBrojevi.Items.Add(broj);
                }
            }
            _honorarni = DTOManager.NadjiHonorarnog(_nastavnik.Id);
            _stalni = DTOManager.NadjiStalnog(_nastavnik.Id);
            if (_honorarni != null)
            {
                radioButtonHonorarni.Checked = true;
                textBoxBrojUgovora.Text = _honorarni.BrojUgovora;
                PickerTrajanjeUgovora.Value = _honorarni.TrajanjeUgovora;
                numericUpDownBrojCasova.Value = _honorarni.BrojCasovaMesecno;
            }
            else if(_stalni != null)
            {
                radioButtonStalni.Checked = true;
                
                textBoxJMBGMentora.Text = _stalni.Mentor?.JMBG;
                checkBoxMentor.Checked = _stalni.StatusMentora;
                string[] radnoVreme = _stalni.RadnoVreme.Split('-');
                string radnoVremeOd = radnoVreme[0].Trim();
                string radnoVremeDo = radnoVreme[1].Trim();
                pickerRadnoVremeOd.Value = DateTime.ParseExact(radnoVremeOd, "HH:mm", null);
                pickerRadnoVremeDo.Value = DateTime.ParseExact(radnoVremeDo, "HH:mm", null);
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

        private void buttonIzmeniNastavnika_Click(object sender, EventArgs e)
        {
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
                if (pickerRadnoVremeDo.Value < pickerRadnoVremeOd.Value || pickerRadnoVremeOd.Value.ToString("HH:mm") == pickerRadnoVremeDo.Value.ToString("HH:mm"))
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

            DTOManager.IzmeniOsobu(osoba);
            DTOManager.IzmeniNastavnika(nastavnik, _nastavnik.Id);

            if (radioButtonHonorarni.Checked)
            {
                var honorarni = new HonorarniBasic
                {
                    BrojUgovora = textBoxBrojUgovora.Text,
                    BrojCasovaMesecno = (int)numericUpDownBrojCasova.Value,
                    TrajanjeUgovora = PickerTrajanjeUgovora.Value
                };

                if (_stalni != null)
                {
                    DTOManager.ObrisiStalnogNastavnika(_stalni.Id);
                    DTOManager.SacuvajHonorarnogNastavnika(honorarni, _nastavnik.Id);
                }
                else
                {
                    DTOManager.IzmeniHonorarnogNastavnika(honorarni, _honorarni.Id);
                }
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
                if (_honorarni != null)
                {
                    DTOManager.ObrisiHonorarnogNastavnika(_honorarni.Id);
                    DTOManager.SacuvajStalnog(stalni, _nastavnik.Id, mentorJMBG);
                }
                else
                {
                    DTOManager.IzmeniStalnog(stalni, _stalni.Id, mentorJMBG);
                }
            }
            MessageBox.Show("Nastavnik uspesno izmenjen!");
            _globalForm.PrikaziNastavnikeUDataGrid();
            Close();
        }
    }
}

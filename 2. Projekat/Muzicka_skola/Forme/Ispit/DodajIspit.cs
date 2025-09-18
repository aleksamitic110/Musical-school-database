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

namespace Muzicka_skola.Forme.Ispit
{
    public partial class DodajIspit : Form
    {


        private GlobalForm _globalForm;
        public DodajIspit(GlobalForm globalForm)
        {
            InitializeComponent();
            ClearAll();
            UcitajKurseve();
            UcitajNastavnike();
            _globalForm = globalForm;
        }

        public void UcitajKurseve() {
            
            comboBoxKursevi.DataSource = DTOManager.vratiSveKurseve();
            comboBoxKursevi.DisplayMember = "Naziv";   
            comboBoxKursevi.ValueMember = "Id";
        }
        public void UcitajNastavnike() {
            comboBoxNastavnici.DataSource = DTOManager.PrikaziSveNastavnike();
            comboBoxNastavnici.DisplayMember = "Ime";
            comboBoxNastavnici.ValueMember = "Id";
        }

        public void ClearAll()
        {
            comboBoxKursevi.Items.Clear();
            comboBoxNastavnici.Items.Clear();
        }

        private void buttonDodajNastavnika_Click(object sender, EventArgs e)
        {
            NastavnikDTO input = ((NastavnikDTO)comboBoxNastavnici.SelectedItem);
            if (listBoxDodatiNastavnici.Items.Count >= 3)
            {
                MessageBox.Show("Moguce je dodati najvise 3 nastavnika");
                return;
            }

            foreach (var item in listBoxDodatiNastavnici.Items)
            {
                var dto = (NastavnikDTO)item;
                if (dto.Id == input.Id)
                {
                    MessageBox.Show("Taj nastavnik je vec dodat");
                    return;
                }
            }

            listBoxDodatiNastavnici.Items.Add(input);
            listBoxDodatiNastavnici.DisplayMember = "Ime";
            listBoxDodatiNastavnici.ValueMember = "Id";
        }

        private void buttonObrisiNastavnikaIzListbox_Click(object sender, EventArgs e)
        {
            if (listBoxDodatiNastavnici.SelectedItem != null)
            {
                listBoxDodatiNastavnici.Items.Remove(listBoxDodatiNastavnici.SelectedItem);
            }
            else
            {
                MessageBox.Show("Izaberi nastavnika za brisanje");
            }
        }

        private void buttonDodajIspit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxID.Text) || listBoxDodatiNastavnici.Items.Count == 0 || comboBoxKursevi.SelectedIndex == -1)
            {
                MessageBox.Show("Nisu sva polja popunjena");
                return;
            }
            if(dateTimePicker1.Value.Date < DateTime.Today)
            {
                MessageBox.Show("Datum nije validan");
                return;
            }
            string kursId = ((KursDTO)comboBoxKursevi.SelectedItem).Id;
            IspitBasic ispt = new IspitBasic();
            ispt.Id = textBoxID.Text;
            ispt.Datum = dateTimePicker1.Value.Date;

            foreach (var item in listBoxDodatiNastavnici.Items)
            {
                var dto = (NastavnikDTO)item;
                ispt.NastavnikIds.Add(dto.Id);
            }
            if (DTOManager.DodajIspit(ispt, kursId))
            {
                IspitUspesnoDodat();
            }
        }

        private void IspitUspesnoDodat()
        {
            MessageBox.Show("Ispit uspesno dodat!");
            _globalForm.PrikaziIspiteUDataGrid();
            Close();
        }
    }
}

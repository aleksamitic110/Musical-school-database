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

namespace Muzicka_skola.Forme.Ispit
{
    public partial class IzmeniIspit : Form
    {
        private GlobalForm _globalForm;
        private IspitDTO _ispit;
        public IzmeniIspit(GlobalForm globalForm, IspitDTO ispit)
        {
            InitializeComponent();
            _globalForm = globalForm;
            _ispit = ispit;
            UcitajPodatke();
        }

        public void UcitajPodatke() {
            dateTimePicker1.Value = _ispit.Datum;
            UcitajKomisiju();
            UcitajNastavnike();
        }
        public void UcitajNastavnike()
        {
            comboBoxNastavnici.DataSource = DTOManager.PrikaziSveNastavnike();
            comboBoxNastavnici.DisplayMember = "Ime";
            comboBoxNastavnici.ValueMember = "Id";
        }

        public void UcitajKomisiju() {
            List<NastavnikDTO> nastavnici = DTOManager.VratiKomisiju(_ispit.Id);
            foreach (NastavnikDTO nast in nastavnici) {
                listBoxDodatiNastavnici.Items.Add(nast);
            }
            listBoxDodatiNastavnici.DisplayMember = "Ime";
            listBoxDodatiNastavnici.ValueMember = "Id";
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

        private void buttonIzmeniIspit_Click(object sender, EventArgs e)
        {
            if (listBoxDodatiNastavnici.Items.Count == 0)
            {
                MessageBox.Show("Nisu sva polja popunjena");
                return;
            }
            if (dateTimePicker1.Value.Date < DateTime.Today)
            {
                MessageBox.Show("Datum nije validan");
                return;
            }
            IspitBasic ispt = new IspitBasic();
            ispt.Datum = dateTimePicker1.Value.Date;
            ispt.Id = _ispit.Id;

            foreach (var item in listBoxDodatiNastavnici.Items)
            {
                var dto = (NastavnikDTO)item;
                ispt.NastavnikIds.Add(dto.Id);
            }
            if (DTOManager.IzmeniIspit(ispt))
            {
                IspitUspesnoIzmenjen();
            }
        }

        private void IspitUspesnoIzmenjen()
        {
            MessageBox.Show("Ispit uspesno izmenjen!");
            _globalForm.PrikaziIspiteUDataGrid();
            Close();
        }
    }
}

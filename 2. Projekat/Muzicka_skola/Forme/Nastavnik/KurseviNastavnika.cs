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
    public partial class KurseviNastavnika : Form
    {
        private int _nastavnikId;
        public KurseviNastavnika(int nastavnikId)
        {
            InitializeComponent();
            _nastavnikId = nastavnikId;
            UcitajKurseve();
        }
        private void UcitajKurseve()
        {
            dataGridView1.DataSource = DTOManager.UcitajKurseveKojeNastavnikDrzi(_nastavnikId);
            HideId();
            buttonPrikaziIspite.Enabled = true;
            buttonPrikazPolaznika.Enabled = true;
        }

        private void buttonPrikazPolaznika_Click(object sender, EventArgs e)
        {
            var selectedRow = dataGridView1.CurrentRow;
            if (selectedRow != null)
            {
                string kursId = (string)selectedRow.Cells["Id"].Value;
                dataGridView1.DataSource = DTOManager.PolazniciKojiSuPolozili(kursId);
                buttonPrikaziIspite.Enabled = false;
            }
            else
            {
                MessageBox.Show("Kurs nije izabran");
            }
        }

        private void buttonPrikaziKurseve_Click(object sender, EventArgs e)
        {
            UcitajKurseve();
        }

        private void buttonPrikaziIspite_Click(object sender, EventArgs e)
        {
            var selectedRow = dataGridView1.CurrentRow;
            if (selectedRow != null)
            {
                string kursId = (string)selectedRow.Cells["Id"].Value;
                dataGridView1.DataSource = DTOManager.IspitiKojiPredstoje(kursId);
                buttonPrikazPolaznika.Enabled = false;
            }
            else
            {
                MessageBox.Show("Kurs nije izabran");
            }
        }

        private void HideId()
        {
            dataGridView1.Columns["Id"].Visible = false;
        }
    }
}

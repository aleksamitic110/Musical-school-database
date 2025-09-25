using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using Muzicka_skola.Entiteti;

namespace Muzicka_skola.Forme.Kursevi
{
    partial class ListaPolazinka : Form
    {
        private GlobalForm _globalForm;
        private KursDTO Kurs;
        public ListaPolazinka(GlobalForm globalForm, KursDTO kurs)
        {
            InitializeComponent();
            _globalForm = globalForm;
            Kurs = kurs;
            loadDataGrid();
        }

        public void loadDataGrid()
        {
            this.dataGridView1.DataSource = DTOManager.vratiPolaznikeBezKursa(Kurs);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    if (row.Cells[1].Value != null)
                    {
                        PolaznikDTO selectedPolaznik = row.DataBoundItem as PolaznikDTO;
                        DTOManager.dodajPolaznikaNaKurs(selectedPolaznik, Kurs);
                    }
                }

                MessageBox.Show("Uspesno");
                _globalForm.prikaziPodKurs();
                Close();
            }
            else
            {
                MessageBox.Show("Selektuj red!");
            }
        }
    }
}

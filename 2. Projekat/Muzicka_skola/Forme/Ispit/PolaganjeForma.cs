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
    public partial class PolaganjeForma : Form
    {
        private string IspitId;
        public PolaganjeForma(string ispitId)
        {
            InitializeComponent();
            IspitId = ispitId;
            UcitajPolaznike();

        }
        private void UcitajPolaznike() {
            List<PolaznikDTO> polaznici = DTOManager.vratiPolaznikeKojiNePolazuIspit(IspitId);
            dataGridView1.DataSource = polaznici;
            dataGridView1.Columns["Id"].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<int> polaznikIds = new List<int>();
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                int polaznikId = (int)row.Cells["Id"].Value;
                polaznikIds.Add(polaznikId);
            }
            if (DTOManager.DodajPolaganje(polaznikIds, IspitId)) {
                MessageBox.Show("Polaznici dodati!");
                Close();
            }
        }
    }
}

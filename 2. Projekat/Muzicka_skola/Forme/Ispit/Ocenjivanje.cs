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
   
    public partial class Ocenjivanje : Form
    {
        private string IspitId;
        public Ocenjivanje(string ispitId)
        {
            InitializeComponent();
            IspitId = ispitId;
            UcitajPolaznike();
        }

        public void UcitajPolaznike()
        {
            List<PolaganjeDTO> polaznici = DTOManager.VratiPolaznikeKojiSuPolagaliIspit(IspitId);
            datagrd.DataSource = polaznici;
            datagrd.Columns["Id"].Visible = false;
        }



        private void buttonOceni_Click(object sender, EventArgs e)
        {
            var selectedRow = datagrd.CurrentRow;
            if (selectedRow != null)
            {
                int polaganjeId = (int)selectedRow.Cells["Id"].Value;
                OceniPolaznika ocenjivanjeForm = new OceniPolaznika(this,polaganjeId);
                ocenjivanjeForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Izaberi polaznika");
            }
        }
    }

}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Muzicka_skola.Forme.Polaznici
{
    public partial class OdabirPostojecegStaratelja: Form
    {
        public OdabirPostojecegStaratelja()
        {
            InitializeComponent();
			this.dataGridViewOdaberiStaratelja.DataSource = DTOManager.VratiStaratelje();
		}

		private void buttonOdaberiStaratelja_Click(object sender, EventArgs e)
		{
			var selectedRow = dataGridViewOdaberiStaratelja.CurrentRow;
			if (selectedRow != null)
			{
				// Pretpostavimo da kolona sa ID-jem ima naziv "Id"
				int starateljId = (int)selectedRow.Cells["Id"].Value;

				// Sada možeš da koristiš starateljId kako treba
				MessageBox.Show($"Izabrani staratelj ima ID: {starateljId}");
			}
			else
			{
				MessageBox.Show("Nije izabrana nijedna vrsta.");
			}
		}
	}
}

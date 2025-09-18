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
		public int SelektovaniStarateljId { get; private set; }
		public string SelektovaniStarateljImePrezime { get; private set; }

		public OdabirPostojecegStaratelja()
        {
            InitializeComponent();

			SelektovaniStarateljId = -1;
			SelektovaniStarateljImePrezime = string.Empty;

			this.dataGridViewOdaberiStaratelja.DataSource = DTOManager.VratiStaratelje();
			this.dataGridViewOdaberiStaratelja.Columns["Deca"].Visible = false;

			//Za izgled datagridview
			this.dataGridViewOdaberiStaratelja.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewOdaberiStaratelja.MultiSelect = false;
			this.dataGridViewOdaberiStaratelja.ReadOnly = true;
			this.dataGridViewOdaberiStaratelja.AllowUserToAddRows = false;
		}

		private void buttonOdaberiStaratelja_Click(object sender, EventArgs e)
		{
			if (dataGridViewOdaberiStaratelja.SelectedRows.Count > 0)
			{
				DataGridViewRow selectedRow = dataGridViewOdaberiStaratelja.SelectedRows[0];

			
				int id = Convert.ToInt32(selectedRow.Cells["Id"].Value);
				string ime = selectedRow.Cells["Ime"].Value.ToString();
				string prezime = selectedRow.Cells["Prezime"].Value.ToString();

				
				this.SelektovaniStarateljId = id;
				this.SelektovaniStarateljImePrezime = $"{ime} {prezime}";

				
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
			else
			{
				MessageBox.Show("Niste odabrali nijednog staratelja.");
			}
		}
	}
}

using FluentNHibernate.Conventions.AcceptanceCriteria;
using Muzicka_skola.Entiteti;
using Muzicka_skola.Forme.Nastavnik;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Muzicka_skola.Forme
{
    public partial class GlobalForm: Form
    {
       
        private Tip trenutniTip;

        public GlobalForm()
        {
            InitializeComponent();
        }

		public GlobalForm(Tip tip)
		{
			InitializeComponent();
		}

		private void Ucitaj(Tip tip)
		{
			this.panelDodatneFunkcije.Controls.Clear();
			this.panelDodatniFilteri.Controls.Clear();
			this.panelStandardniFilteri.Controls.Clear();


			switch (tip)
			{
				
				case Tip.Polaznici:
					PreurediPrikazPolaznici();
					break;

				case Tip.Nastavnici:
					PreurediPrikazNastavnici();
					break;

				case Tip.Kursevi:
					PreurediPrikazKursevi();
					break;
				case Tip.Ispiti:
					PreurediPrikazIspiti();
					break;
			}
		}



		#region Preuredjivanje_Prikaza
		private void PreurediPrikazPolaznici() {
			this.panelDodatneFunkcije.Controls.Add(new Label() { Text = "Polaznik" });
			this.panelStandardniFilteri.Controls.Add(new Label() { Text = "Filteri za polaznike" });
			this.panelDodatniFilteri.Controls.Add(new Label() { Text = "Dodatni Filteri za polaznike" , Size = new Size(200, 200) });
		}

		private void PreurediPrikazNastavnici() {
			UcitajCeoPrikazNastavnika();
        }

		private void PreurediPrikazKursevi()
		{
			this.panelDodatneFunkcije.Controls.Add(new Label() { Text = "Kurs" });
			this.panelStandardniFilteri.Controls.Add(new Label() { Text = "Filteri za kurseve" });
			this.panelDodatniFilteri.Controls.Add(new Label() { Text = "Dodatni Filteri za kurseve", Size = new Size(200, 200) });
		}

		private void PreurediPrikazIspiti() {
			this.panelDodatneFunkcije.Controls.Add(new Label() { Text = "Dodatne funkcije za ispit" });
			this.panelStandardniFilteri.Controls.Add(new Label() { Text = "Filteri za ispite" });
			this.panelDodatniFilteri.Controls.Add(new Label() { Text = "Dodatni Filteri za ispite" , Size = new Size(200, 200) });
		}
		#endregion

		#region Main_Page_Buttons
		private void buttunPolaznici_Click(object sender, EventArgs e)
		{
			trenutniTip = Tip.Polaznici;
			Ucitaj(Tip.Polaznici);
		}

		private void buttonNastavnici_Click(object sender, EventArgs e)
		{
            trenutniTip = Tip.Nastavnici;
            Ucitaj(Tip.Nastavnici);
		}

		private void buttonKursevi_Click(object sender, EventArgs e)
		{

			Ucitaj(Tip.Kursevi);
		}

		private void buttonIspiti_Click(object sender, EventArgs e)
		{
			Ucitaj(Tip.Ispiti);
		}
		#endregion

		#region Panel_Standardne_Funkcije_Buttons
		private void buttonAdd_Click(object sender, EventArgs e)
        {
            switch (trenutniTip)
            {
                case Tip.Polaznici:
                    break;

                case Tip.Nastavnici:
					DodajNastavnik dodajNastavnikForm = new DodajNastavnik(this);
					dodajNastavnikForm.ShowDialog();
                    break;

                case Tip.Kursevi:
                    break;
                case Tip.Ispiti:
                    break;
            }
        }


		private void buttonUpdate_Click(object sender, EventArgs e)
		{
			switch (trenutniTip)
			{
				case Tip.Polaznici:
					break;

				case Tip.Nastavnici:
					var selectedRow = dataGridViewPrikazPodataka.CurrentRow;
                    
					if(selectedRow != null)
					{
                        NastavnikDTO selectedNastavnik = selectedRow.DataBoundItem as NastavnikDTO;
                        IzmeniNastavnik izmeniNastavnikForm = new IzmeniNastavnik(this, selectedNastavnik);
                        izmeniNastavnikForm.ShowDialog();
                    }
					else
					{
                        MessageBox.Show("Izaberi nastavnika za izmenu");
                    }
					break;

				case Tip.Kursevi:
					break;
				case Tip.Ispiti:
					break;
			}
		}

		private void buttonDelete_Click(object sender, EventArgs e)
		{
			switch (trenutniTip)
			{
				case Tip.Polaznici:
					break;

				case Tip.Nastavnici:
					ObrisiIzabranogNastavnika();
					break;

				case Tip.Kursevi:
					break;
				case Tip.Ispiti:
					break;
			}
		}
		#endregion



		#region Polaznici

		#endregion


		#region Kursevi

		#endregion


		#region Ispiti

		#endregion


		#region Nastavnici
		private void NastavniciRadioButton_CheckedChanged(object sender, EventArgs e)
        {
			if (radioButtonSviNastavnici.Checked)
			{
                PrikaziNastavnikeUDataGrid();
            }
            else if (radioButtonHonorarni.Checked)
			{
				PrikaziHonorarneNastavnikeUDataGrid();
            }
			else if (radioButtonStalni.Checked)
			{
				PrikaziStalneNastavnikeUDataGrid();
            }
        }
		private void ObrisiIzabranogNastavnika()
		{
			var selectedRow = dataGridViewPrikazPodataka.CurrentRow;
            if (selectedRow != null)
            {
				int nastavnikId = (int)selectedRow.Cells["Id"].Value;
                DTOManager.ObrisiNastavnika(nastavnikId);
				MessageBox.Show("Nastavnik uspesno obrisan!");
                PrikaziNastavnikeUDataGrid();
            }
            else
            {
                MessageBox.Show("Izaberi nastavnika za brisanje");
            }
        }
		private void UcitajCeoPrikazNastavnika()
		{
            panelDodatneFunkcije.Controls.Add(panelDodatneFunkcijeNastavnik);
            panelDodatneFunkcijeNastavnik.Show();
            panelDodatneFunkcijeNastavnik.BringToFront();
			PrikaziNastavnikeUDataGrid();
        }
		public void PrikaziNastavnikeUDataGrid()
		{
			radioButtonSviNastavnici.Checked = true;
			ClearDataGrid();
            dataGridViewPrikazPodataka.DataSource = DTOManager.PrikaziSveNastavnike();
			HideId();
			OrderColumns();
        }
        private void PrikaziHonorarneNastavnikeUDataGrid()
        {
            ClearDataGrid();
            dataGridViewPrikazPodataka.DataSource = DTOManager.PrikaziSveHonorarneNastavnike();
            HideId();
            OrderColumns();
        }
        private void PrikaziStalneNastavnikeUDataGrid()
        {
            ClearDataGrid();
            dataGridViewPrikazPodataka.DataSource = DTOManager.PrikaziSveStalneNastavnike();
            HideId();
            OrderColumns();
        }
		private void HideId()
		{
            dataGridViewPrikazPodataka.Columns["Id"].Visible = false;
        }
		private void ClearDataGrid()
		{
            dataGridViewPrikazPodataka.DataSource = null;
            dataGridViewPrikazPodataka.AllowUserToOrderColumns = true;
        }
		private void OrderColumns()
		{
            dataGridViewPrikazPodataka.Columns["Ime"].DisplayIndex = 0;
            dataGridViewPrikazPodataka.Columns["Prezime"].DisplayIndex = 1;
            dataGridViewPrikazPodataka.Columns["JMBG"].DisplayIndex = 2;
        }
        #endregion

    }
}

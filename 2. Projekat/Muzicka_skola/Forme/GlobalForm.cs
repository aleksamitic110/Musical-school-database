using FluentNHibernate.Conventions.AcceptanceCriteria;
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
			
			this.dataGridViewPrikazPodataka.DataSource = DTOManager.vratiPolaznike();
		}

		private void PreurediPrikazNastavnici() {
			this.panelDodatneFunkcije.Controls.Add(panelDodatneFunkcijeNastavnik);
			panelDodatneFunkcijeNastavnik.Show();
			panelDodatneFunkcijeNastavnik.BringToFront();
            this.dataGridViewPrikazPodataka.DataSource = DTOManager.vratiSveNastavnike();
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
					AddNastavnik addNastavnikForm = new AddNastavnik();
					addNastavnikForm.Show();
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
                this.dataGridViewPrikazPodataka.DataSource = DTOManager.vratiSveNastavnike();
            }
            else if (radioButtonHonorarni.Checked)
			{
                this.dataGridViewPrikazPodataka.DataSource = DTOManager.vratiSveHonorarneNastavnike();
            }
			else if (radioButtonStalni.Checked)
			{
                this.dataGridViewPrikazPodataka.DataSource = DTOManager.vratiSveStalneNastavnike();
            }
        }
		#endregion

	}
}

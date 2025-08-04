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



		/* Ovde preurediti panele: 
			panelPrikaz (samo ucitati odgovarajuce elemente iz baze panelPrikaz.dataGridViewPrikaz)
			panelFilteri sadrzi dva panela (panelStandardniFilteri - oni po atributima, i on se menja, i panelDodatniFilteri takodje se menja na osnovu tipa)
			panelFunkcije sadrzi dva panela (panelStandardneFunkcije - Nikad se ne menja to su add, delete, modify i panelDodatneFunkcije menja se po promeni tipa)
			Dugme filtriraj ce da pokrece funkciju Filtriraj(Svi podaci potrebni za precizno filtriranje) tako da se njegova implementacija nikad ne menja
		*/
		private void PreurediPrikazPolaznici() {
			this.panelDodatneFunkcije.Controls.Add(new Label() { Text = "Polaznik" });
			this.panelStandardniFilteri.Controls.Add(new Label() { Text = "Filteri za polaznike" });
			this.panelDodatniFilteri.Controls.Add(new Label() { Text = "Dodatni Filteri za polaznike" , Size = new Size(200, 200) });
		}

		private void PreurediPrikazNastavnici() {
			//this.panelDodatneFunkcije.Controls.Add(new Label() { Text = "Nastavnik" });
			//this.panelStandardniFilteri.Controls.Add(new Label() { Text = "Filteri za nastavnike" });
			//this.panelDodatniFilteri.Controls.Add(new Label() { Text = "Dodatni Filteri za nastavnike", Size = new Size(200, 200) });
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

        private void AddFunkcija_Click(object sender, EventArgs e)
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
    }
}

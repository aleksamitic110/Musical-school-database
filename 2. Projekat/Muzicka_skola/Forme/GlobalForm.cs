using FluentNHibernate.Conventions.AcceptanceCriteria;
using Muzicka_skola.Entiteti;
using Muzicka_skola.Forme.Ispit;
using Muzicka_skola.Forme.Kursevi;
using Muzicka_skola.Forme.Nastavnik;
using Muzicka_skola.Forme.Polaznici;
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
		private char selektovanTipKursa; 
		//Da ne pravim radio dugmice stavio sam da updatujem ovo

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

			this.panelDodatneFunkcije.Controls.Add(panelDodatneFunkcijePolaznik);
			panelDodatneFunkcijeNastavnik.Show();
			panelDodatneFunkcijeNastavnik.BringToFront();
			this.dataGridViewPrikazPodataka.DataSource = DTOManager.vratiPolaznike();

			UcitajCeoPrikazPolaznika();
		}

		private void PreurediPrikazNastavnici() {
			
			this.panelDodatneFunkcije.Controls.Add(panelDodatneFunkcijeNastavnik);
			panelDodatneFunkcijeNastavnik.Show();
			panelDodatneFunkcijeNastavnik.BringToFront();
			
			UcitajCeoPrikazNastavnika();
       
		}

		private void PreurediPrikazKursevi()
		{
			//this.panelDodatneFunkcije.Controls.Add(new Label() { Text = "Kurs" });
			//this.panelStandardniFilteri.Controls.Add(new Label() { Text = "Filteri za kurseve" });
			//this.panelDodatniFilteri.Controls.Add(new Label() { Text = "Dodatni Filteri za kurseve", Size = new Size(200, 200) });

			this.dataGridViewPrikazPodataka.DataSource = DTOManager.vratiSveKurseve();
			panelDodatneFunkcije.Controls.Add(panelKursevi);
			panelKursevi.Show();
			panelKursevi.BringToFront();


		}

		private void PreurediPrikazIspiti() {
            this.panelDodatneFunkcije.Controls.Add(panelDodatneFunkcijeIspit);
            panelDodatneFunkcijeIspit.Show();
            panelDodatneFunkcijeIspit.BringToFront();
            PrikaziIspiteUDataGrid();

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
			trenutniTip = Tip.Kursevi;
			selektovanTipKursa = 'D';
			Ucitaj(Tip.Kursevi);

            var filijale = DTOManager.vratiSveFilijale(); // returns list of DTOs
            comboBoxFilijalaID.DataSource = filijale;
            comboBoxFilijalaID.DisplayMember = "Id"; // what user sees
            comboBoxFilijalaID.ValueMember = "Id";      // actual value stored
        }

		private void buttonIspiti_Click(object sender, EventArgs e)
		{
            trenutniTip = Tip.Ispiti;
            Ucitaj(Tip.Ispiti);
		}


		#endregion

		#region Panel_Standardne_Funkcije_Buttons
		private void buttonAdd_Click(object sender, EventArgs e)
        {
            switch (trenutniTip)
            {
                case Tip.Polaznici:
					AddPolaznik dodajPolaznika = new AddPolaznik(this);
					dodajPolaznika.Show();
					break;

                case Tip.Nastavnici:
					DodajNastavnik dodajNastavnikForm = new DodajNastavnik(this);
					dodajNastavnikForm.ShowDialog();
                    break;

                case Tip.Kursevi:
					DodajKurs dodajKursForm = new DodajKurs(this);
					dodajKursForm.ShowDialog();
                    break;

                case Tip.Ispiti:
                    DodajIspit dodajIspitForm = new DodajIspit(this);
                    dodajIspitForm.ShowDialog();
                    break;
            }
        }


		private void buttonUpdate_Click(object sender, EventArgs e)
		{

			switch (trenutniTip)
			{
				case Tip.Polaznici:
					var selectedRowP = dataGridViewPrikazPodataka.CurrentRow;

					if (selectedRowP != null)
					{
						if (!radioButtonStaratelji.Checked)
						{
							PolaznikDTO selectedPolaznik = selectedRowP.DataBoundItem as PolaznikDTO;
							using (IzmeniPolaznik izmeniPolaznikForm = new IzmeniPolaznik(selectedPolaznik.Id))
							{
								if (izmeniPolaznikForm.ShowDialog() == DialogResult.OK)
								{
									if (radioButtonDeca.Checked)
										PrikaziDecuPolaznikeUDataGrid();
									else if (radioButtonOdrasli.Checked)
										PrikaziOdraslePolaznikeUDataGrid();
									else if (radioButtonSviPolaznici.Checked)
										PrikaziPolaznikeUDataGrid();
									else if (radioButtonStaratelji.Checked)
										PrikaziStarateljeUDataGrid();
								}
							}
						}
						else{
							int starateljId = Convert.ToInt32(selectedRowP.Cells["Id"].Value);
							using (IzmenaStaratelja formaIzmena = new IzmenaStaratelja(starateljId))
							{
								if (formaIzmena.ShowDialog() == DialogResult.OK)
								{
									PrikaziStarateljeUDataGrid(); 
								}
							}
						}
					}
					else
					{
						MessageBox.Show("Izaberi nastavnika za izmenu");
					}
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
                    var selectedRowK = dataGridViewPrikazPodataka.CurrentRow;

                    if (selectedRowK != null)
                    {
                        KursDTO selectedKurs = selectedRowK.DataBoundItem as KursDTO;
                        UpdateKurs updateKursForm = new UpdateKurs(this, selectedKurs);
                        updateKursForm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Izaberi kurs za izmenu");
                    }
                    break;
				case Tip.Ispiti:
                    var selectedRowI = dataGridViewPrikazPodataka.CurrentRow;

                    if (selectedRowI != null)
                    {
                        IspitDTO selectedIspit = selectedRowI.DataBoundItem as IspitDTO;
                        IzmeniIspit izmeniIspitForm = new IzmeniIspit(this, selectedIspit);
                        izmeniIspitForm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Izaberi ispit za izmenu");
                    }
                    break;
			}
		}

		private void buttonDelete_Click(object sender, EventArgs e)
		{
			switch (trenutniTip)
			{
				case Tip.Polaznici:
					ObrisiIzabranogPolaznika();
					break;

				case Tip.Nastavnici:
					ObrisiIzabranogNastavnika();
					break;

				case Tip.Kursevi:
					obrisiIzabranKurs();
					break;
				case Tip.Ispiti:
                    ObrisiIzabraniIspit();
                    break;
			}
		}
		#endregion



		#region Polaznici
		private void PolazniciRadioButton_CheckedChanged(object sender, EventArgs e)
		{


			if (radioButtonSviPolaznici.Checked)
			{
				PrikaziPolaznikeUDataGrid();
				buttonPrikaziDecuStaratelja.Hide();
                buttonPrikaziKursevePolaznika.Show();
            }
			else if (radioButtonOdrasli.Checked)
			{
				PrikaziOdraslePolaznikeUDataGrid();
				buttonPrikaziDecuStaratelja.Hide();
                buttonPrikaziKursevePolaznika.Show();
            }
			else if (radioButtonDeca.Checked)
			{
				PrikaziDecuPolaznikeUDataGrid();
				buttonPrikaziDecuStaratelja.Hide();
                buttonPrikaziKursevePolaznika.Show();
            }
			else if (radioButtonStaratelji.Checked)
			{
				PrikaziStarateljeUDataGrid();
				buttonPrikaziDecuStaratelja.Show();
				buttonPrikaziKursevePolaznika.Hide();
			}

		}

		private void buttonPrikaziDecuStaratelja_Click(object sender, EventArgs e)
		{
			if (dataGridViewPrikazPodataka.SelectedRows.Count > 0)
			{
				// Uzimamo selektovani red
				DataGridViewRow selectedRow = dataGridViewPrikazPodataka.SelectedRows[0];

				// Izvlačimo ID staratelja iz ćelije. Proveri da li se kolona zove "Id".
				int starateljId = Convert.ToInt32(selectedRow.Cells["Id"].Value);

				// Kreiramo instancu naše nove forme i prosleđujemo joj ID
				using (PrikazDeceStaratelja formaZaDecu = new PrikazDeceStaratelja(starateljId))
				{
					formaZaDecu.ShowDialog();
				}
			}
			else
			{
				MessageBox.Show("Molimo vas, prvo odaberite staratelja.");
			}
		}


		private void ObrisiIzabranogPolaznika()
		{
			if (dataGridViewPrikazPodataka.SelectedRows.Count == 0)
			{
				MessageBox.Show("Molimo vas, odaberite polaznika kojeg želite da obrišete.");
				return;
			}

			if (radioButtonStaratelji.Checked) {
				MessageBox.Show("Staratelj se briše automatksi onda kada vise nema dece");
				return;
			}

			// Uzimamo ID iz selektovanog reda. Proveri da li se kolona zaista zove "Id".
			int polaznikId = Convert.ToInt32(dataGridViewPrikazPodataka.SelectedRows[0].Cells["Id"].Value);

			// Dijaloh za potvrdu - ovo je OBAVEZNO da se ne bi slučajno obrisali podaci!
			string ime = dataGridViewPrikazPodataka.SelectedRows[0].Cells["Ime"].Value.ToString();
			string prezime = dataGridViewPrikazPodataka.SelectedRows[0].Cells["Prezime"].Value.ToString();

			DialogResult result = MessageBox.Show($"Da li ste sigurni da želite da obrišete polaznika: {ime} {prezime}?",
													"Potvrda brisanja",
													MessageBoxButtons.YesNo,
													MessageBoxIcon.Warning);

			if (result == DialogResult.Yes)
			{
				DTOManager.ObrisiPolaznika(polaznikId);
				MessageBox.Show("Polaznik je uspešno obrisan.");

				// Ponovo učitaj podatke da se promena vidi u tabeli
				// Pretpostavljam da se funkcija za prikaz zove ovako:
				PrikaziPolaznikeUDataGrid();
			}
		}

		private void buttonPrikaziKursevePolaznika_Click(object sender, EventArgs e)
		{
			// Proveravamo da li je korisnik uopšte selektovao nekog polaznika
			if (dataGridViewPrikazPodataka.SelectedRows.Count == 0)
			{
				MessageBox.Show("Molimo vas, prvo odaberite polaznika.");
				return;
			}

			// Uzimamo selektovani red
			DataGridViewRow selectedRow = dataGridViewPrikazPodataka.SelectedRows[0];

			// Izvlačimo ID polaznika, kao i ime i prezime za naslov prozora
			int polaznikId = Convert.ToInt32(selectedRow.Cells["Id"].Value);
			string ime = selectedRow.Cells["Ime"].Value.ToString();
			string prezime = selectedRow.Cells["Prezime"].Value.ToString();
			string imePrezime = $"{ime} {prezime}";

			// Kreiramo instancu naše nove forme i prosleđujemo joj podatke
			using (PrikazKursevaPolaznika formaKursevi = new PrikazKursevaPolaznika(polaznikId, imePrezime))
			{
				// Prikazujemo formu kao dijalog
				formaKursevi.ShowDialog();
			}
		}

		public void PrikaziStarateljeUDataGrid()
		{
			radioButtonStaratelji.Checked = true;
			ClearDataGrid();
			dataGridViewPrikazPodataka.DataSource = DTOManager.VratiStaratelje();
			dataGridViewPrikazPodataka.Columns["Deca"].Visible = false;
			HideId();
			OrderColumns();
		}

		public void PrikaziOdraslePolaznikeUDataGrid()
		{
			radioButtonOdrasli.Checked = true;
			ClearDataGrid();
			dataGridViewPrikazPodataka.DataSource = DTOManager.PrikaziOdrasle();
			HideId();
			OrderColumns();
		}
		private void PrikaziDecuPolaznikeUDataGrid()
		{
			ClearDataGrid();
			dataGridViewPrikazPodataka.DataSource = DTOManager.VratiDecu();
			HideId();
			OrderColumns();
		}

		public void PrikaziPolaznikeUDataGrid()
		{
			radioButtonSviPolaznici.Checked = true;  
			ClearDataGrid();
			dataGridViewPrikazPodataka.DataSource = DTOManager.vratiPolaznike();
			HideId();
			OrderColumns();
		}


		private void UcitajCeoPrikazPolaznika()
		{
			panelDodatneFunkcije.Controls.Add(panelDodatneFunkcijePolaznik);
			panelDodatneFunkcijeNastavnik.Show();
			panelDodatneFunkcijeNastavnik.BringToFront();
			PrikaziPolaznikeUDataGrid();
		}
		#endregion


		#region Kursevi
		private void obrisiIzabranKurs()
		{
            var selectedRow = dataGridViewPrikazPodataka.CurrentRow;
            if (selectedRow != null)
            {
                string kursId = (string)selectedRow.Cells["Id"].Value;
                DTOManager.obrisiKurs(kursId);
				prikaziPodKurs();
                
            }
            else
            {
                MessageBox.Show("Selektuj Kurs");
            }
        }

        private void prikaziInstrumentalni_Click(object sender, EventArgs e)
        {
			selektovanTipKursa = 'I';
			prikaziPodKurs();
        }

        private void prikaziTeorijski_Click(object sender, EventArgs e)
        {
			selektovanTipKursa = 'T';
            prikaziPodKurs();
        }

        private void prikaziVokalni_Click(object sender, EventArgs e)
        {
            selektovanTipKursa = 'V';
            prikaziPodKurs();
        }

		public void prikaziPodKurs()
		{
			ClearDataGrid();
			switch (selektovanTipKursa)
			{
				case 'D':
                    this.dataGridViewPrikazPodataka.DataSource = DTOManager.vratiSveKurseve();
                    break;

                case 'T':
                    this.dataGridViewPrikazPodataka.DataSource = DTOManager.vratiTeorijski();
                    break;

                case 'V':
                    this.dataGridViewPrikazPodataka.DataSource = DTOManager.vratiVokalni();
                    break;

                case 'I':
                    this.dataGridViewPrikazPodataka.DataSource = DTOManager.vratiInstrumentalni();
                    break;
            }
		}

        private void prikaziPolaznikeKursa_Click(object sender, EventArgs e)
        {
            var selectedRow = dataGridViewPrikazPodataka.CurrentRow;
            string kursId = (string)selectedRow.Cells["Id"].Value;
			this.dataGridViewPrikazPodataka.DataSource = DTOManager.nadjiPolaznikeZaKursDTO(kursId);
        }
        private void zakaziCas_Click(object sender, EventArgs e)
        {
            var selectedRowK = dataGridViewPrikazPodataka.CurrentRow;

            if (selectedRowK != null)
            {
                KursDTO selectedKurs = selectedRowK.DataBoundItem as KursDTO;
                DodajCas dodajCasForm = new DodajCas(this, selectedKurs);
                dodajCasForm.ShowDialog();
            }
        }
        private void prikaziFilijalu_Click(object sender, EventArgs e)
        {
            var selectedRow = dataGridViewPrikazPodataka.CurrentRow;
			if (selectedRow != null && selektovanTipKursa == 'D')
			{
				string filijalaId = (string)selectedRow.Cells["Filijala"].Value;
				this.dataGridViewPrikazPodataka.DataSource = new List<FilijalaDTO> { DTOManager.nadjiFilijaluDTO(filijalaId) };
            }
            else
            {
                MessageBox.Show("Selektuj Kurs");
            }
        }
        private void prikaziKursPoFilijali_Click(object sender, EventArgs e)
        {
			//Prikazuje sve kurseve vezane za filijalu iz comboboxa
			this.dataGridViewPrikazPodataka.DataSource = DTOManager.vratiKursPoFilijali((string)comboBoxFilijalaID.SelectedValue);
			selektovanTipKursa = 'D';
        }
        #endregion


        #region Ispiti
        public void PrikaziIspiteUDataGrid()
        {
            ClearDataGrid();
            dataGridViewPrikazPodataka.DataSource = DTOManager.PrikaziSveIspite();
            HideKursId();
            HideProsecnaOcena();
        }

        private void ObrisiIzabraniIspit()
        {
            var selectedRow = dataGridViewPrikazPodataka.CurrentRow;
            if (selectedRow != null)
            {
                string ispitId = (string)selectedRow.Cells["Id"].Value;
                DTOManager.ObrisiIspit(ispitId);
                MessageBox.Show("Ispit uspesno obrisan!");
                PrikaziIspiteUDataGrid();
            }
            else
            {
                MessageBox.Show("Izaberi ispit za brisanje");
            }
        }

        private void HideKursId()
        {
            dataGridViewPrikazPodataka.Columns["KursId"].Visible = false;
        }

        private void HideProsecnaOcena() {
            dataGridViewPrikazPodataka.Columns["ProsecnaOcena"].Visible = false;
        }

        private void ShowProsecnaOcena()
        {
            dataGridViewPrikazPodataka.Columns["ProsecnaOcena"].Visible = true;
        }

        private void ispitOcenjivanjeButton_Click(object sender, EventArgs e)
        {
            var selectedRow = dataGridViewPrikazPodataka.CurrentRow;
            if (selectedRow != null)
            {
                string ispitId = (string)selectedRow.Cells["Id"].Value;
              
                    Ocenjivanje ocenjivanjeForm = new Ocenjivanje(ispitId);
                    ocenjivanjeForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Izaberi ispit za ocenjivanje");
            }
        }

        private void sortirajIspiteButton_Click(object sender, EventArgs e)
        {
            ClearDataGrid();
            dataGridViewPrikazPodataka.DataSource = DTOManager.PrikaziIspitePoProsecnojOceni();
            HideKursId();
            ShowProsecnaOcena();
        }


        private void buttonPolaganje_Click(object sender, EventArgs e)
        {
            var selectedRow = dataGridViewPrikazPodataka.CurrentRow;
            if (selectedRow != null)
            {
                string ispitId = (string)selectedRow.Cells["Id"].Value;

                PolaganjeForma polaganjeForm = new PolaganjeForma(ispitId);
                polaganjeForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Izaberi ispit");
            }
        }

        #endregion


        #region Nastavnici
        private void NastavniciRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            panelMentorButtons.Visible = radioButtonStalni.Checked;

            if (radioButtonSviNastavnici.Checked)
			{

                PrikaziNastavnikeUDataGrid();
                button1.Hide();
                button2.Hide();
            }
            else if (radioButtonHonorarni.Checked)
			{
				PrikaziHonorarneNastavnikeUDataGrid();
                button1.Hide();
                button2.Hide();
            }
			else if (radioButtonStalni.Checked)
			{
				PrikaziStalneNastavnikeUDataGrid();
				button1.Show();
                button2.Show();
            }
        }



		private void ObrisiIzabranogNastavnika()
		{
			var selectedRow = dataGridViewPrikazPodataka.CurrentRow;
            if (selectedRow != null)
            {
				int nastavnikId = (int)selectedRow.Cells["Id"].Value;
                DTOManager.ObrisiNastavnika(nastavnikId);
                DTOManager.IzmeniStatusMentora();
                MessageBox.Show("Nastavnik uspesno obrisan!");
                PrikaziNastavnikeUDataGrid();
            }
            else
            {
                MessageBox.Show("Izaberi nastavnika za brisanje");
            }
        }

        private void buttonPrikaziMentora_Click(object sender, EventArgs e)
        {
            var selectedRow = dataGridViewPrikazPodataka.CurrentRow;
            if (selectedRow != null)
            {
                int nastavnikId = (int)selectedRow.Cells["Id"].Value;
                List<NastavnikDTO> nastavnici = DTOManager.PrikaziMentora(nastavnikId);
				if(nastavnici.Count > 0)
				{
                    PrikazNastavnika prikazNastavnika = new PrikazNastavnika(nastavnici);
                    prikazNastavnika.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Nastavnik nije izabran");
            }
        }


        private void buttonPrikaziKomeJeMentor_Click(object sender, EventArgs e)
        {
            var selectedRow = dataGridViewPrikazPodataka.CurrentRow;
            if (selectedRow != null)
            {
                string nastavnikJMBG= (string)selectedRow.Cells["JMBG"].Value;
                List<NastavnikDTO> nastavnici = DTOManager.PrikaziKomeJeMentor(nastavnikJMBG);
                if (nastavnici.Count > 0)
                {
                    PrikazNastavnika prikazNastavnika = new PrikazNastavnika(nastavnici);
                    prikazNastavnika.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Nastavnik nije izabran");
            }
        }


        private void buttonPrikaziNadgledaniIspiti_Click(object sender, EventArgs e)
        {
            var selectedRow = dataGridViewPrikazPodataka.CurrentRow;
            if (selectedRow != null)
            {
                int nastavnikId = (int)selectedRow.Cells["Id"].Value;
                List<NastavnikIspitDto> ispiti = DTOManager.PrikaziNadgledaneIspite(nastavnikId);
                if(ispiti.Count > 0)
                {
                    PrikazIspita prikazIspita = new PrikazIspita(ispiti);
                    prikazIspita.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Nije ucestvovao u nadgledanju nijednog ispita");
                }
            }
            else
            {
                MessageBox.Show("Nastavnik nije izabran");
            }
        }


        private void buttonKurseviNastavnika_Click(object sender, EventArgs e)
        {
            var selectedRow = dataGridViewPrikazPodataka.CurrentRow;
            if (selectedRow != null)
            {
                int nastavnikId = (int)selectedRow.Cells["Id"].Value;
                KurseviNastavnika kurseviNastavnika = new KurseviNastavnika(nastavnikId);
                kurseviNastavnika.ShowDialog();
            }
            else
            {
                MessageBox.Show("Nastavnik nije izabran");
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

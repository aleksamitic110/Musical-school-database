using Muzicka_skola.Entiteti;
using Muzicka_skola.Forme.Polaznici;
using NHibernate;
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
    public partial class AddPolaznik: Form
    {
		private GlobalForm _globalForm;
		private int starateljId;
        public AddPolaznik(GlobalForm globalForm)
        {
            InitializeComponent();
			this._globalForm = globalForm;
			panelDodatneInformacijeDete.Enabled = false;
			panelDodatneInformacijeOdrasli.Enabled = true;
        }


		private void RadioButtons_CheckedChanged(object sender, EventArgs e)
		{

			if (radioButtonDete.Checked)
			{
				panelDodatneInformacijeDete.Enabled = true;
				panelDodatneInformacijeOdrasli.Enabled = false;

			}
			else if (radioButtonOdrasli.Checked)
			{
				panelDodatneInformacijeDete.Enabled = false;
				panelDodatneInformacijeOdrasli.Enabled = true;
			}

			
		}
		private void buttonDodajBroj_Click(object sender, EventArgs e)
		{
			string input = textBoxBrojTelefona.Text.Trim();
			if (listBoxDodatiBrojevi.Items.Count >= 3)
			{
				MessageBox.Show("Moguce je upisati najvise 3 broja");
				return;
			}
			if (!textBoxBrojTelefona.Text.All(char.IsDigit) || string.IsNullOrEmpty(input))
			{
				MessageBox.Show("Broj telefona nije validan");
				return;
			}

			foreach (var item in listBoxDodatiBrojevi.Items)
			{
				if (item.ToString() == input)
				{
					MessageBox.Show("Taj broj telefona je već dodat");
					return;
				}
			}

			listBoxDodatiBrojevi.Items.Add(input);
			textBoxBrojTelefona.Clear();
		}
		private void buttonObrisiBroj_Click(object sender, EventArgs e)
		{
			if (listBoxDodatiBrojevi.SelectedItem != null)
			{
				listBoxDodatiBrojevi.Items.Remove(listBoxDodatiBrojevi.SelectedItem);
			}
			else
			{
				MessageBox.Show("Izaberi broj za brisanje");
			}
		}

		private void buttonDodajPolaznika_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(textBoxJMBG.Text) || string.IsNullOrWhiteSpace(textBoxIme.Text)
			   || string.IsNullOrWhiteSpace(textBoxPrezime.Text) || string.IsNullOrWhiteSpace(textBoxAdresa.Text)
			   || string.IsNullOrWhiteSpace(textBoxMail.Text) || listBoxDodatiBrojevi.Items.Count == 0
			   || string.IsNullOrWhiteSpace(textBoxZanimanje.Text))
			{
				MessageBox.Show("Nisu sva polja popunjena");
				return;
			}

			
				
			if (radioButtonOdrasli.Checked)
			{
				if (string.IsNullOrEmpty(textBoxZanimanje.Text))
				{
					MessageBox.Show("Nisu sva polja popunjena za odraslog polaznika radnika");
					return;
				}
			}
			if (!textBoxJMBG.Text.All(char.IsDigit))
			{
				MessageBox.Show("JMBG nije validan");
				return;
			}

			OsobaBasic osoba = new OsobaBasic
			{
				JMBG = textBoxJMBG.Text,
				Ime = textBoxIme.Text,
				Prezime = textBoxPrezime.Text,
				Adresa = textBoxAdresa.Text,
				Mail = textBoxMail.Text
			};

			foreach (var item in listBoxDodatiBrojevi.Items)
				osoba.Telefoni.Add(new TelefonBasic { BrojTelefona = item.ToString() });
			PolaznikBasic polaznik = new PolaznikBasic {};

			if (radioButtonOdrasli.Checked)
			{
				var odrasli = new OdrasliBasic { Zanimanje = this.textBoxZanimanje.Text};

				if (DTOManager.SacuvajOdraslogPolaznika(odrasli, osoba, polaznik))
				{
					PolaznikUspesnoDodat();
				}
			}
			else if (radioButtonDete.Checked)
			{
				using (ISession session = DataLayer.GetSession())
				{
					Staratelj staratelj = session.Get<Staratelj>(this.starateljId);

					if (staratelj != null)
					{
						// staratelj pronađen, koristi ga
					}
					else
					{
						// staratelj sa tim ID-jem ne postoji
					}
				}

				//TODO: Pokupiti vrednosti vezane za dete DatumRodjenja i BrojDosijea
				var dete = new DeteBasic
				{
					DatumRodjenja = this.dateTimePickerDatumRodjenjaDeteta.Value,
					BrojDosijea = this.textBoxBrojDosijeaDeteta.ToString(),
					Staratelj = 
				};

				if (DTOManager.SacuvajDete(dete, this.starateljId, polaznik, osoba) != -1)
				{
					PolaznikUspesnoDodat();
				}
			}
		}
		private void PolaznikUspesnoDodat()
		{
			MessageBox.Show("Polaznik uspesno dodat!");
			_globalForm.PrikaziPolaznikeUDataGrid();
			Close();
		}

		private void buttonIzaberiPostojecegStaratelja_Click(object sender, EventArgs e)
		{
			OdabirPostojecegStaratelja viewStaratelj = new OdabirPostojecegStaratelja();
			viewStaratelj.Show();
		}
	}
}

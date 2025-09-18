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

namespace Muzicka_skola.Forme.Polaznici
{
    public partial class IzmeniPolaznik: Form
    {

		private int polaznikId;
		private int starateljId;


		public IzmeniPolaznik(int id)
		{
			InitializeComponent();
			this.polaznikId = id;

			// Odmah pozivamo metodu za popunjavanje forme
			UcitajPodatkePolaznika();
		}

		private void UcitajPodatkePolaznika()
		{
			// Pozivamo metodu iz DTOManager-a koja vraća SVE detalje
			PolaznikDTO podaci = DTOManager.VratiDetaljePolaznika(this.polaznikId);

			if (podaci == null)
			{
				MessageBox.Show("Nije moguće učitati podatke za izabranog polaznika.");
				this.Close();
				return;
			}

			// Popunjavanje osnovnih podataka
			textBoxJMBG.Text = podaci.JMBG;
			textBoxJMBG.ReadOnly = true; // JMBG se ne sme menjati
			textBoxIme.Text = podaci.Ime;
			textBoxPrezime.Text = podaci.Prezime;
			textBoxAdresa.Text = podaci.Adresa;
			textBoxMail.Text = podaci.Mail;

			// Popunjavanje liste telefona
			listBoxDodatiBrojevi.Items.Clear();
			// Telefoni su spojeni sa ';', pa ih razdvajamo
			string[] telefoni = podaci.Telefoni.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
			foreach (var tel in telefoni)
			{
				listBoxDodatiBrojevi.Items.Add(tel.Trim());
			}

			// Provera tipa polaznika i popunjavanje specifičnih polja
			if (podaci is DeteDTO dete)
			{
				radioButtonDete.Checked = true;

				dateTimePickerDatumRodjenjaDeteta.Value = dete.DatumRodjenja;
				textBoxBrojDosijeaDeteta.Text = dete.BrojDosijea;

				// Čuvamo ID staratelja i prikazujemo njegove podatke
				this.starateljId = dete.Staratelj.Id;
				labelOdabraniStaratelj.Text = $"ID: {dete.Staratelj.Id}, Ime: {dete.Staratelj.Ime} {dete.Staratelj.Prezime}";
			}
			else if (podaci is OdrasliDTO odrasli)
			{
				radioButtonOdrasli.Checked = true;

				textBoxZanimanje.Text = odrasli.Zanimanje;
			}

			// Pozivamo event handler da bi se omogućili/onemogućili pravi paneli
			RadioButtons_CheckedChanged(null, null);
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

		private void buttonIzaberiPostojecegStaratelja_Click(object sender, EventArgs e)
		{
			using (OdabirPostojecegStaratelja viewStaratelj = new OdabirPostojecegStaratelja())
			{
				if (viewStaratelj.ShowDialog() == DialogResult.OK)
				{
					this.starateljId = viewStaratelj.SelektovaniStarateljId;
					this.labelOdabraniStaratelj.Text = viewStaratelj.SelektovaniStarateljImePrezime;
				}
			}
		}

		private void buttonDodajNovogStaratelja_Click(object sender, EventArgs e)
		{
			using (DodajStarateljaForm formaDodaj = new DodajStarateljaForm())
			{

				if (formaDodaj.ShowDialog() == DialogResult.OK)
				{


					int noviStarateljId = formaDodaj.NoviStarateljId;
					string imePrezime = formaDodaj.NoviStarateljImePrezime;

					this.starateljId = noviStarateljId;

					labelOdabraniStaratelj.Text = $"ID: {noviStarateljId}, Ime: {imePrezime}";
				}
			}
		}

		private void buttonIzmeniPolaznika_Click(object sender, EventArgs e)
		{
			PolaznikDTO podaciZaIzmenu;

			if (radioButtonDete.Checked)
			{
				// Validacija za dete
				if (this.starateljId == 0)
				{
					MessageBox.Show("Morate odabrati staratelja za dete.");
					return;
				}

				var dete = new DeteDTO
				{
					// Osnovni podaci
					Id = this.polaznikId,
					JMBG = textBoxJMBG.Text,
					Ime = textBoxIme.Text,
					Prezime = textBoxPrezime.Text,
					Adresa = textBoxAdresa.Text,
					Mail = textBoxMail.Text,
					Telefoni = string.Join(";", listBoxDodatiBrojevi.Items.Cast<string>()),

					// Specifični podaci za dete
					DatumRodjenja = dateTimePickerDatumRodjenjaDeteta.Value,
					BrojDosijea = textBoxBrojDosijeaDeteta.Text,
					Staratelj = new StarateljDTO { Id = this.starateljId } // Šaljemo samo ID novog (ili starog) staratelja
				};
				podaciZaIzmenu = dete;
			}
			else // Odrasli
			{
				var odrasli = new OdrasliDTO
				{
					// Osnovni podaci
					Id = this.polaznikId,
					JMBG = textBoxJMBG.Text,
					Ime = textBoxIme.Text,
					Prezime = textBoxPrezime.Text,
					Adresa = textBoxAdresa.Text,
					Mail = textBoxMail.Text,
					Telefoni = string.Join(";", listBoxDodatiBrojevi.Items.Cast<string>()),

					// Specifični podaci za odraslog
					Zanimanje = textBoxZanimanje.Text
				};
				podaciZaIzmenu = odrasli;
			}

			// Pozivamo metodu iz DTOManager-a
			if (DTOManager.IzmeniPolaznika(podaciZaIzmenu))
			{
				MessageBox.Show("Polaznik je uspešno izmenjen!");
				this.DialogResult = DialogResult.OK; // Signaliziramo glavnoj formi da je izmena uspela
				this.Close();
			}
		}
	}
}

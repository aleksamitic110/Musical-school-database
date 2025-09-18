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
    public partial class IzmenaStaratelja: Form
    {
		private int starateljId;

		public IzmenaStaratelja(int id)
		{
			InitializeComponent();
			this.starateljId = id;
			UcitajPodatkeStaratelja();
		}


		private void UcitajPodatkeStaratelja()
		{
			StarateljDTO podaci = DTOManager.VratiDetaljeStaratelja(this.starateljId);
			if (podaci == null)
			{
				MessageBox.Show("Nije moguće učitati podatke za izabranog staratelja.");
				this.Close();
				return;
			}

			// Popunjavanje forme
			textBoxJMBG.Text = podaci.JMBG;
			textBoxJMBG.ReadOnly = true; // JMBG se ne sme menjati
			textBoxIme.Text = podaci.Ime;
			textBoxPrezime.Text = podaci.Prezime;
			textBoxAdresa.Text = podaci.Adresa;
			textBoxMail.Text = podaci.Mail;

			// Popunjavanje telefona
			listBoxDodatiBrojevi.Items.Clear();
			string[] telefoni = podaci.Telefoni.Split(';');
			foreach (var tel in telefoni)
			{
				if (!string.IsNullOrWhiteSpace(tel))
					listBoxDodatiBrojevi.Items.Add(tel);
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

		private void buttonIzmeniStaratelja_Click(object sender, EventArgs e)
		{
			// Prikupljamo podatke sa forme
			StarateljDTO podaciZaIzmenu = new StarateljDTO
			{
				Id = this.starateljId,
				JMBG = textBoxJMBG.Text,
				Ime = textBoxIme.Text,
				Prezime = textBoxPrezime.Text,
				Adresa = textBoxAdresa.Text,
				Mail = textBoxMail.Text,
				Telefoni = string.Join(";", listBoxDodatiBrojevi.Items.Cast<string>())
			};

			// Pozivamo DTO Manager
			if (DTOManager.IzmeniStaratelja(podaciZaIzmenu))
			{
				MessageBox.Show("Staratelj je uspešno izmenjen!");
				this.DialogResult = DialogResult.OK; // Šaljemo signal uspeha
				this.Close();
			}
		}
	}
}

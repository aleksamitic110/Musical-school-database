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
    public partial class DodajStarateljaForm: Form
    {

		public int NoviStarateljId { get; private set; }
		public string NoviStarateljImePrezime { get; private set; }

		public DodajStarateljaForm()
        {
            InitializeComponent();
			this.NoviStarateljId = -1;
			this.NoviStarateljImePrezime = string.Empty;
		}

		private void buttonDodajStaratelja_Click(object sender, EventArgs e)
		{
		
			if (string.IsNullOrWhiteSpace(textBoxJMBG.Text) || string.IsNullOrWhiteSpace(textBoxIme.Text) ||
				string.IsNullOrWhiteSpace(textBoxPrezime.Text) || listBoxDodatiBrojevi.Items.Count == 0)
			{
				MessageBox.Show("Molimo vas, popunite sva obavezna polja (JMBG, Ime, Prezime, bar jedan telefon).");
				return;
			}


			OsobaBasic novaOsoba = new OsobaBasic
			{
				JMBG = textBoxJMBG.Text,
				Ime = textBoxIme.Text,
				Prezime = textBoxPrezime.Text,
				Adresa = textBoxAdresa.Text,
				Mail = textBoxMail.Text,
				Telefoni = new List<TelefonBasic>()
			};

			foreach (var item in listBoxDodatiBrojevi.Items)
			{
				novaOsoba.Telefoni.Add(new TelefonBasic { BrojTelefona = item.ToString() });
			}

			StarateljBasic noviStaratelj = new StarateljBasic();

		
			int noviId = DTOManager.SacuvajStaratelja(noviStaratelj, novaOsoba);

			if (noviId != -1) 
			{
				
				this.NoviStarateljId = noviId;
				this.NoviStarateljImePrezime = $"{novaOsoba.Ime} {novaOsoba.Prezime}";

				MessageBox.Show("Novi staratelj je uspešno dodat!");

			
				this.DialogResult = DialogResult.OK;
				this.Close(); 
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
	}
}


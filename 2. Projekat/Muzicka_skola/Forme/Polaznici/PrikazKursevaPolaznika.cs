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
    public partial class PrikazKursevaPolaznika: Form
    {
        public PrikazKursevaPolaznika(int polaznikId, string imePrezime)
        {
            InitializeComponent();
			this.Text = $"Kursevi koje pohađa: {imePrezime}";

			List<KursDTO> kursevi = DTOManager.VratiKurseveZaPolaznika(polaznikId);

			// Prikazujemo rezultate u tabeli
			dataGridViewKursevaPolaznika.DataSource = kursevi;

			// Opciono: Podesi tabelu da izgleda lepše
			dataGridViewKursevaPolaznika.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dataGridViewKursevaPolaznika.ReadOnly = true;
		}
    }
}

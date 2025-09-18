using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Muzicka_skola.Forme.Ispit
{
    public partial class OceniPolaznika : Form
    {
        private int _polaganjeId;
        private Ocenjivanje _ocenjivanje;
        public OceniPolaznika(Ocenjivanje ocenjivanje,int polaganjeId)
        {
            InitializeComponent();
            _polaganjeId = polaganjeId;
            _ocenjivanje = ocenjivanje;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int ocena = (int)numericUpDown1.Value;
            bool polozio = ocena > 5;
            if (DTOManager.OceniPolaganjePolaznika(_polaganjeId, polozio, ocena)) {
                PolaznikUspesnoOcenjen();
            }
        }

        private void PolaznikUspesnoOcenjen()
        {
            MessageBox.Show("Polaznik uspesno ocenjen!");
            _ocenjivanje.UcitajPolaznike();
            Close();
        }
    }
}

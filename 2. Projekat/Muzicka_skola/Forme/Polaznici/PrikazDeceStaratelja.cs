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
    public partial class PrikazDeceStaratelja: Form
    {
        public PrikazDeceStaratelja(int starateljId)
        {
            InitializeComponent();
			List<DeteDTO> deca = DTOManager.VratiDecuStaratelja(starateljId);

            // Prikaži dobijene podatke u DataGridView
            dataGridViewDecaStaratelja.DataSource = deca;
		}
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Muzicka_skola.Forme.Nastavnik
{
    public partial class PrikazNastavnika : Form
    {
        private List<NastavnikDTO> _nastavnici;
        public PrikazNastavnika(List<NastavnikDTO> nastavnici)
        {
            InitializeComponent();
            _nastavnici = nastavnici;
            UcitajNastavnika();
        }
        private void UcitajNastavnika() {
            dataGridView1.DataSource = _nastavnici;
            dataGridView1.Columns["Id"].Visible = false;
        }
    }
}

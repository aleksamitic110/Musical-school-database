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
    public partial class PrikazIspita : Form
    {
        private List<NastavnikIspitDto> _ispiti;
        public PrikazIspita(List<NastavnikIspitDto> ispiti)
        {
            InitializeComponent();
            _ispiti = ispiti;
            UcitajIspite();
        }
        private void UcitajIspite() {
            dataGridView1.DataSource = _ispiti;
        }


    }
}

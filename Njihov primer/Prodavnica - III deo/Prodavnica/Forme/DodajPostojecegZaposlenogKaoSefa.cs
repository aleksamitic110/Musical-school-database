using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Prodavnica
{
    public partial class DodajPostojecegZaposlenogKaoSefa : Form
    {
        ProdavnicaBasic prodavnica;
        public DodajPostojecegZaposlenogKaoSefa()
        {
            InitializeComponent();
        }
        public DodajPostojecegZaposlenogKaoSefa(ProdavnicaBasic p)
        {
            InitializeComponent();
            prodavnica = p;
        }

        private void DodajPostojecegZaposlenogKaoSefa_Load(object sender, EventArgs e)
        {
            popuniPodacima();
        }
        public void popuniPodacima()
        {
            List<SefBasic> listaSefova = DTOManager.vratiSveSefove();
            foreach(SefBasic s in listaSefova)
            {
                sefovi.Items.Add(s);
            }
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            SefBasic s = (SefBasic)sefovi.SelectedItem;
            SefujeBasic sefovanje = new SefujeBasic();
            sefovanje.DatumPostavljenja = datumPostavljenja.Value;
            sefovanje.Upravlja = prodavnica;
            sefovanje.Upravnik = s;
            DTOManager.dodajSefOdnos(sefovanje);
            MessageBox.Show("Uspesno ste dodali novog sefa prodavnice!");
            this.Close();

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Prodavnica.Forme
{
    public partial class DodajPostojecegZaposlenogForma : Form
    {
        ProdavnicaBasic prodavnica;
        RadnikBasic radnik;
        public DodajPostojecegZaposlenogForma()
        {
            InitializeComponent();
        }
        public DodajPostojecegZaposlenogForma(ProdavnicaBasic p)
        {
            InitializeComponent();
            prodavnica = p;
            popuniPodacima();
        }
        public void popuniPodacima()
        {
            List<RadnikBasic> radniciLista = DTOManager.vratiSveRadnike();
            foreach (RadnikBasic r in radniciLista)
                zaposleni.Items.Add(r);

        }

        private void DodajPostojecegZaposlenogForma_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            RadiUBasic radi = new RadiUBasic();
            radnik = (RadnikBasic)zaposleni.SelectedItem;
            radi.Id = new RadiUIdBasic();
            radi.Id.RadiUProdavnica = prodavnica;
            radi.Id.RadnikRadiU = radnik;
            radi.DatumOd = datumOd.Value;
            if (chbDatumDo.Checked == false)
                radi.DatumDo = DatumDo.Value;
            DTOManager.dodajRadniOdnos(radi);
            MessageBox.Show("Uspesno ste dodali novi radni odnos!");
            this.Close();


        }

        private void omoguciDatumDo(object sender, EventArgs e)
        {
            if (chbDatumDo.Checked == true)
                DatumDo.Enabled = false;
            else
                DatumDo.Enabled = true;
        }
    }
}

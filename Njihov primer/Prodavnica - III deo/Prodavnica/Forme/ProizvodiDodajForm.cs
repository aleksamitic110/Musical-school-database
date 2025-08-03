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
    public partial class ProizvodiDodajForm : Form
    {
        private OdeljenjeBasic odeljenje = new OdeljenjeBasic();
        private ProdavnicaBasic prodavnica = new ProdavnicaBasic();
        private ProizvodBasic proizvod = new ProizvodBasic();

        public ProizvodiDodajForm()
        {
            InitializeComponent();
        }

        private void ProizvodiDodajForm_Load(object sender, EventArgs e)
        {
            PopuniTabeluPodacima();
        }

        public void PopuniTabeluPodacima()
        {
            listaProdavnica.Items.Clear();
            List<ProdavnicaPregled> informacije = DTOManager.vratiSveProdavnice();
            foreach (ProdavnicaPregled p in informacije)
            {

                ListViewItem item = new ListViewItem(new string[] { p.Id.ToString(), p.Naziv, p.Adresa });
                listaProdavnica.Items.Add(item);
            }

            listaProdavnica.Refresh();
        }

        private void BtnNastavi_Click(object sender, EventArgs e)
        {
            if (listaProdavnica.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite prodavnicu u koju zelite da dodate proizvod!");
                return;
            }

            int idProdavnice = Int32.Parse(listaProdavnica.SelectedItems[0].SubItems[0].Text);
            prodavnica = DTOManager.vratiProdavnicu(idProdavnice);

            groupBox1.Enabled = true;
            cbxTip.Enabled = true;
            txbNaziv.Enabled = true;
            txbProizvodjac.Enabled = true;
            cbxOdeljenje.Enabled = true;
            btnSacuvaj.Enabled = true;
            btnNastavi.Enabled = false;
            cbxOdeljenje.Enabled = true;
        }

        // OVO TREBA DA SE IZMENI
        /*private void BtnSacuvaj_Click(object sender, EventArgs e)
        {
            proizvod.Tip = txbTip.Text;
            proizvod.Naziv = txbNaziv.Text;
            proizvod.Proizvodjac = txbProizvodjac.Text;
            
            string poruka = "Da li zelite da nastavite?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);
            if (result == DialogResult.OK)
            {
                DTOManager.dodajProizvod(proizvod);

                Close();
            }
            else
            {

            }
        }*/
    }
}

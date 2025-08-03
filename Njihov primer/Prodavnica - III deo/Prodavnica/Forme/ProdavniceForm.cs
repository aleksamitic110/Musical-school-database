using Prodavnica.Forme;
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
    public partial class ProdavniceForm : Form
    {
        public ProdavniceForm()
        {
            InitializeComponent();
        }

      

        private void ProdavniceForm_Load(object sender, EventArgs e)
        {
            popuniPodacima();
        }

        public void popuniPodacima()
        {
          

            listaProdavnica.Items.Clear();
            List<ProdavnicaPregled> podaci = DTOManager.vratiSveProdavnice();
          
       

            foreach (ProdavnicaPregled p in podaci)
            {
                ListViewItem item = new ListViewItem(new string[] { p.Id.ToString(), p.Naziv, p.Adresa, p.BrojTelefona, p.RadniDan, p.Subota, p.Nedelja });
                listaProdavnica.Items.Add(item);
                
            }

            
           
            listaProdavnica.Refresh();
        }

        private void btnDodajProdavnicu_Click(object sender, EventArgs e)
        {
            ProdavnicaDodajForm formaDodaj = new ProdavnicaDodajForm();
            formaDodaj.ShowDialog();
            this.popuniPodacima();
        }

        private void btnIzmeniProdavnicu_Click(object sender, EventArgs e)
        {
            if (listaProdavnica.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite prodavnicu cije podatke zelite da izmenite!");
                return;
            }

            int idProdavnice = Int32.Parse(listaProdavnica.SelectedItems[0].SubItems[0].Text);
            ProdavnicaBasic ob = DTOManager.vratiProdavnicu(idProdavnice);

            ProdavnicaUpdateForm formaUpdate = new ProdavnicaUpdateForm(ob);
            formaUpdate.ShowDialog();

            this.popuniPodacima();
        }

        private void btnObrisiProdavnicu_Click(object sender, EventArgs e)
        {
            if (listaProdavnica.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite prodavnicu koju zelite da obrisete!");
                return;
            }

            int idProdavnice = Int32.Parse(listaProdavnica.SelectedItems[0].SubItems[0].Text);
            string poruka = "Da li zelite da obrisete izabranu prodavnicu?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                DTOManager.obrisiProdavnicu(idProdavnice);
                MessageBox.Show("Brisanje prodavnice je uspesno obavljeno!");
                this.popuniPodacima();
            }
            else
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listaProdavnica.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite prodavnicu cija odeljenja do 5 god. zelite da vidite!");
                return;
            }

            int idProdavnice = Int32.Parse(listaProdavnica.SelectedItems[0].SubItems[0].Text);
            ProdavnicaBasic p = DTOManager.vratiProdavnicu(idProdavnice);
            OdeljenjeDo5Forma forma = new OdeljenjeDo5Forma(p);
            forma.ShowDialog();



        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listaProdavnica.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite prodavnicu cija odeljenja od 6 do 15 god. zelite da vidite!");
                return;
            }

            int idProdavnice = Int32.Parse(listaProdavnica.SelectedItems[0].SubItems[0].Text);
            ProdavnicaBasic p = DTOManager.vratiProdavnicu(idProdavnice);
            OdeljenjaOd6Do15Forma forma = new OdeljenjaOd6Do15Forma(p);
            forma.ShowDialog();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listaProdavnica.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite prodavnicu cija odeljenja za odrasle zelite da vidite!");
                return;
            }

            int idProdavnice = Int32.Parse(listaProdavnica.SelectedItems[0].SubItems[0].Text);
            ProdavnicaBasic p = DTOManager.vratiProdavnicu(idProdavnice);
            OdeljenjeOdrasliForma forma = new OdeljenjeOdrasliForma(p);
            forma.ShowDialog();

        }

        private void btnZaposleni_Click(object sender, EventArgs e)
        {
            if (listaProdavnica.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite prodavnicu cije zaposlene zelite da vidite!");
                return;
            }

            int idProdavnice = Int32.Parse(listaProdavnica.SelectedItems[0].SubItems[0].Text);
            ProdavnicaBasic p = DTOManager.vratiProdavnicu(idProdavnice);
            ZaposleniForma forma = new ZaposleniForma(p);
            forma.ShowDialog();
        }

        private void btnSefovi_Click(object sender, EventArgs e)
        {
            if (listaProdavnica.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite prodavnicu cije sefove zelite da vidite!");
                return;
            }

            int idProdavnice = Int32.Parse(listaProdavnica.SelectedItems[0].SubItems[0].Text);
            ProdavnicaBasic p = DTOManager.vratiProdavnicu(idProdavnice);
            SefoviForma forma = new SefoviForma(p);
            forma.ShowDialog();
        }
    }
}

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
    public partial class OdeljenjaOd6Do15Forma : Form
    {
        ProdavnicaBasic prodavnica;
        public OdeljenjaOd6Do15Forma()
        {
            InitializeComponent();
        }
        public OdeljenjaOd6Do15Forma(ProdavnicaBasic p)
        {
            InitializeComponent();
            prodavnica = p;
        }

        private void OdeljenjaOd6Do15Forma_Load(object sender, EventArgs e)
        {
            this.Text = "PRODAVNICA " + prodavnica.Naziv.ToUpper();
            popuniPodacima();
        }

       
        public void popuniPodacima()
        {

            odeljenja.Items.Clear();
            List<OdeljenjeOd6Do15Pregled> podaci = DTOManager.vratiOdeljenjaOd6Do15Prodavnice(prodavnica.Id);

            foreach (OdeljenjeOd6Do15Pregled p in podaci)
            {
                ListViewItem item = new ListViewItem(new string[] { p.OdeljenjeId.ToString(), p.Lokacija, p.BrojKasa.ToString(), p.InfoPult });
                odeljenja.Items.Add(item);

            }



            odeljenja.Refresh();
        }

      

        private void btnDodajOdeljenje_Click_1(object sender, EventArgs e)
        {
            DodajOdeljenjeOd6Do15Forma forma = new DodajOdeljenjeOd6Do15Forma(prodavnica);
            forma.ShowDialog();
            popuniPodacima();
        }

        private void btnIzmeniOdeljenje_Click_1(object sender, EventArgs e)
        {
            if (odeljenja.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite odeljenje cije podatke zelite da izmenite!");
                return;
            }

            int idOdeljenja = Int32.Parse(odeljenja.SelectedItems[0].SubItems[0].Text);
            OdeljenjeOd6Do15Basic odeljenje = DTOManager.vratiOdeljenjaOd6Do15(idOdeljenja);
            IzmeniOdeljenjeOd6Do15Forma forma = new IzmeniOdeljenjeOd6Do15Forma(odeljenje);
            forma.ShowDialog();
            popuniPodacima();
        }

        private void btnObrisiOdeljenje_Click_1(object sender, EventArgs e)
        {
            if (odeljenja.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite odeljenje koje zelite da obrisete!");
                return;
            }

            int idOdeljenja = Int32.Parse(odeljenja.SelectedItems[0].SubItems[0].Text);
            string poruka = "Da li zelite da obrisete izabrano odeljenje?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                DTOManager.obrisiOdeljenjeOd6Do15(idOdeljenja);
                MessageBox.Show("Brisanje odeljenja je uspesno obavljeno!");
                this.popuniPodacima();
            }
            else
            {

            }

        }

        private void btnPregledIgracaka_Click(object sender, EventArgs e)
        {
            if (odeljenja.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite odeljenje cije proizvode zelite da vidite!");
                return;
            }

            int idOdeljenja = Int32.Parse(odeljenja.SelectedItems[0].SubItems[0].Text);
            OdeljenjeOd6Do15Basic odeljenje = DTOManager.vratiOdeljenjaOd6Do15(idOdeljenja);
            PregledProizvodaOdeljenjaOd6Do15Form forma = new PregledProizvodaOdeljenjaOd6Do15Form(odeljenje);
            forma.ShowDialog();
            popuniPodacima();
        }
    }
}

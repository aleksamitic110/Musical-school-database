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
    public partial class OdeljenjeDo5Forma : Form
    {
        ProdavnicaBasic prodavnica;

        public OdeljenjeDo5Forma()
        {
            InitializeComponent();
        }

        public OdeljenjeDo5Forma(ProdavnicaBasic p)
        {
            InitializeComponent();
            prodavnica = p;
        }

        private void OdeljenjeDo5Forma_Load(object sender, EventArgs e)
        {
            this.Text = "PRODAVNICA " + prodavnica.Naziv.ToUpper();
            popuniPodacima();
        }

        public void popuniPodacima()
        {
            odeljenja.Items.Clear();
            List<OdeljenjeDo5Pregled> podaci = DTOManager.vratiOdeljenjaDo5Prodavnice(prodavnica.Id);

            foreach (OdeljenjeDo5Pregled p in podaci)
            {
                ListViewItem item = new ListViewItem(new string[] { p.OdeljenjeId.ToString(),p.Lokacija,p.BrojKasa.ToString(),p.InfoPult });
                odeljenja.Items.Add(item);
            }
            
            odeljenja.Refresh();
        }

        private void btnDodajOdeljenje_Click(object sender, EventArgs e)
        {
            DodajOdeljenjeDo5Forma forma = new DodajOdeljenjeDo5Forma(prodavnica);
            forma.ShowDialog();
            popuniPodacima();
        }

        private void btnIzmeniOdeljenje_Click(object sender, EventArgs e)
        {
            if (odeljenja.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite odeljenje cije podatke zelite da izmenite!");
                return;
            }

            int idOdeljenja = Int32.Parse(odeljenja.SelectedItems[0].SubItems[0].Text);
            OdeljenjeDo5Basic odeljenje = DTOManager.vratiOdeljenjaDo5(idOdeljenja);
            IzmeniOdeljenjeDo5Forma forma = new IzmeniOdeljenjeDo5Forma(odeljenje);
            forma.ShowDialog();
            popuniPodacima();
        }

        private void btnObrisiOdeljenje_Click(object sender, EventArgs e)
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
                DTOManager.obrisiOdeljenje(idOdeljenja);
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
            OdeljenjeDo5Basic odeljenje = DTOManager.vratiOdeljenjaDo5(idOdeljenja);
            PregledProizvodaOdeljenjaDo5Form forma = new PregledProizvodaOdeljenjaDo5Form(odeljenje);
            forma.ShowDialog();
            popuniPodacima();
        }
    }
}

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
    public partial class PregledProizvodaOdrasliForm : Form
    {
        OdeljenjeOdrasliBasic odeljenje;

        public PregledProizvodaOdrasliForm()
        {
            InitializeComponent();
        }

        public PregledProizvodaOdrasliForm(OdeljenjeOdrasliBasic o)
        {
            InitializeComponent();
            odeljenje = o;
        }

        private void PregledProizvodaOdrasliForm_Load(object sender, EventArgs e)
        {
            this.Text = "ODELJENJE ODRASLIH, MESTO " + odeljenje.Lokacija.ToUpper();
            popuniPodacima();
        }

        public void popuniPodacima()
        {
            proizvodi.Items.Clear();
            List<ProdajeSeBasic> podaci = DTOManager.vratiProizvodeOdeljenjaOdraslih(odeljenje.OdeljenjeId);

            foreach (ProdajeSeBasic p in podaci)
            {
                ListViewItem item = new ListViewItem(new string[] { p.ProdajeProzivod.BarKod.ToString(), p.ProdajeProzivod.Tip.ToString(),
                    p.ProdajeProzivod.Naziv.ToString(), p.ProdajeProzivod.Proizvodjac.ToString(), p.Id.ToString() });
                proizvodi.Items.Add(item);
            }

            proizvodi.Refresh();
        }

        private void btnDodajProizvod_Click(object sender, EventArgs e)
        {
            DodajProizvodOdrasliForma forma = new DodajProizvodOdrasliForma(odeljenje);
            forma.ShowDialog();
            popuniPodacima();
        }

        private void btnIzmeniProizvod_Click(object sender, EventArgs e)
        {
            if (proizvodi.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite igracku cije podatke zelite da izmenite!");
                return;
            }

            int idProizvoda = Int32.Parse(proizvodi.SelectedItems[0].SubItems[0].Text);
            String tipProizvoda = proizvodi.SelectedItems[0].SubItems[1].Text;

            if (tipProizvoda == "PUZZLE")
            {
                SlagalicaBasic r = DTOManager.vratiSlagalicu(idProizvoda);
                IzmeniProizvodSlagalicaForma forma = new IzmeniProizvodSlagalicaForma(r);
                forma.ShowDialog();
                popuniPodacima();
            }
        }

        private void btnObrisiProizvod_Click(object sender, EventArgs e)
        {
            if (proizvodi.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite igracku koju zelite da obrisete!");
                return;
            }

            int idProizvoda = Int32.Parse(proizvodi.SelectedItems[0].SubItems[4].Text);
            string poruka = "Da li zelite da obrisete izabranu igracku?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                DTOManager.obrisiProizvod(idProizvoda);
                MessageBox.Show("Brisanje igracke je uspesno obavljeno!");
                this.popuniPodacima();
            }
            else
            {

            }
        }
    }
}

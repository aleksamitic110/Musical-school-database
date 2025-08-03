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
    public partial class ProizvodiForm : Form
    {
        public ProizvodiForm()
        {
            InitializeComponent();
        }

        public int brojProizvoda = 0;

        private void ProizvodiForm_Load(object sender, EventArgs e)
        {
            popuniPodacima();
        }

        public void popuniPodacima()
        {
            brojProizvoda = 0;

            listaProizvoda.Items.Clear();
            List<ProizvodPregled> proizvodi = DTOManager.vratiSveProizvode();

            foreach (ProizvodPregled p in proizvodi)
            {
                ListViewItem item = new ListViewItem(new string[] { p.BarKod.ToString(), p.Tip, p.Naziv, p.Proizvodjac });
                listaProizvoda.Items.Add(item);
                this.brojProizvoda++;
            }

            txbBrojProizvoda.Text = this.brojProizvoda.ToString();
            listaProizvoda.Refresh();
        }

        private void btnDodajProizvod_Click(object sender, EventArgs e)
        {
            ProizvodiDodajForm formaDodaj = new ProizvodiDodajForm();
            formaDodaj.ShowDialog();
            this.popuniPodacima();
        }

        private void btnIzmeniProizvod_Click(object sender, EventArgs e)
        {
            if (listaProizvoda.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite proizvod cije podatke zelite da izmenite!");
                return;
            }

            /*int idProizvoda = Int32.Parse(listaProizvoda.SelectedItems[0].SubItems[0].Text);
            ProizvodBasic pb = DTOManager.vratiProizvod(idProizvoda);

            ProizvodiUpdateForm formaUpdate = new ProizvodiUpdateForm(pb);
            formaUpdate.ShowDialog();

            this.popuniPodacima();*/
        }

        private void btnObrisiProizvod_Click(object sender, EventArgs e)
        {
            if (listaProizvoda.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite radnika koga zelite da obrisete!");
                return;
            }

            int idProizvoda = Int32.Parse(listaProizvoda.SelectedItems[0].SubItems[0].Text);
            string poruka = "Da li zelite da obrisete izabrani proizvod?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            /*if (result == DialogResult.OK)
            {
                DTOManager.obrisiProizvod(idProizvoda);
                MessageBox.Show("Brisanje proizvoda je uspesno obavljeno!");
                this.popuniPodacima();
            }
            else
            {

            }*/
        }
    }
}

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
    public partial class SviProizvodiForma : Form
    {
        public SviProizvodiForma()
        {
            InitializeComponent();
        }

        public int brojProizvoda = 0;

        private void SviProizvodiForma_Load(object sender, EventArgs e)
        {
            popuniPodacima();
        }

        public void popuniPodacima()
        {
            this.brojProizvoda = 0;

            List<ProizvodBasic> listaProizvoda = DTOManager.vratiSveProizvodeBasic();
            this.igracke.Items.Clear();

            foreach (ProizvodBasic p in listaProizvoda)
            {
                ListViewItem item = new ListViewItem(new string[] { p.BarKod.ToString(), p.Tip, p.Naziv, p.Proizvodjac });
                this.igracke.Items.Add(item);
                this.brojProizvoda++;
            }

            txbBrojProizvoda.Text = this.brojProizvoda.ToString();
            this.igracke.Refresh();
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            if (igracke.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite igracku koju zelite da obrisete!");
                return;
            }

            int idProizvoda = Int32.Parse(igracke.SelectedItems[0].SubItems[0].Text);
            string poruka = "Da li zelite da obrisete izabranu igracku?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                DTOManager.obrisiIgrackuIzSistema(idProizvoda);
                MessageBox.Show("Brisanje igracke je uspesno obavljeno!");
                this.popuniPodacima();
            }
            else
            {

            }
        }
    }
}

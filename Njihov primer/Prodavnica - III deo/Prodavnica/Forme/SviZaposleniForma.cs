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
    public partial class SviZaposleniForma : Form
    {
        public SviZaposleniForma()
        {
            InitializeComponent();
        }

        public int brojZaposlenih = 0;

        private void SviZaposleniForma_Load(object sender, EventArgs e)
        {
            popuniPodacima();
        }

        public void popuniPodacima()
        {
            this.brojZaposlenih = 0;

            List<RadnikBasic> listaRadnika = DTOManager.vratiSveRadnike();
            String pom;
            this.zaposleni.Items.Clear();
            
            foreach (RadnikBasic r in listaRadnika)
            {
                if (r.Sef == true)
                    pom = "Da";
                else
                    pom = "Ne";
                ListViewItem item = new ListViewItem(new string[] { r.Jbr.ToString(), r.Mbr.ToString(), r.Ime, r.SrednjeSlovo.ToString(), r.Prezime, r.DatumRodjenja.ToShortDateString(), r.StrucnaSpema, pom });
                this.zaposleni.Items.Add(item);
                this.brojZaposlenih++;
            }

            txbBrojZaposlenih.Text = this.brojZaposlenih.ToString();
            this.zaposleni.Refresh();
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            if (zaposleni.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite zaposlenog koga zelite da obrisete!");
                return;
            }

            int idZaposleni = Int32.Parse(zaposleni.SelectedItems[0].SubItems[0].Text);
            string poruka = "Da li zelite da obrisete izabranog zaposlenog?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                DTOManager.obrisiRadnikaIzSistema(idZaposleni);
                MessageBox.Show("Brisanje zaposlenog je uspesno obavljeno!");
                this.popuniPodacima();
            }
            else
            {

            }
        }
    }
}

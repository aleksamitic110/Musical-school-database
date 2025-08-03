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
    public partial class ZaposleniForma : Form
    {
        ProdavnicaBasic prodavnica;
        public ZaposleniForma()
        {
            InitializeComponent();
        }
        public ZaposleniForma(ProdavnicaBasic p)
        {
            InitializeComponent();
            prodavnica = p;
        }

        private void ZaposleniForma_Load(object sender, EventArgs e)
        {
            this.Text = "PRODAVNICA " + prodavnica.Naziv.ToUpper();
            popuniPodacima();
        }

        public void popuniPodacima()
        {
            String pom;
            this.zaposleni.Items.Clear();
            List<RadnikPregled> radnici = DTOManager.vratiSveRadnikeProdavnice(prodavnica.Id);

            foreach (RadnikPregled r in radnici)
            {
                if (r.Sef == true)
                    pom = "Da";
                else
                    pom = "Ne";
                ListViewItem item = new ListViewItem(new string[] { r.Jbr.ToString(), r.Mbr.ToString(), r.Ime, r.SrednjeSlovo.ToString(), r.Prezime, r.DatumRodjenja.ToShortDateString(), r.StrucnaSpema, pom });
                this.zaposleni.Items.Add(item);
               
            }

            this.zaposleni.Refresh();
        }

        private void btnDodajZaposlenog_Click(object sender, EventArgs e)
        {
            DodajZaposlenogForma forma = new DodajZaposlenogForma(prodavnica);
            forma.ShowDialog();
            popuniPodacima();
        }

        private void btnObrisiZaposlenog_Click(object sender, EventArgs e)
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
                DTOManager.obrisiRadnika(idZaposleni);
                MessageBox.Show("Brisanje zaposlenog je uspesno obavljeno!");
                this.popuniPodacima();
            }
            else
            {

            }
        }

        private void btnIzmeniZaposlenog_Click(object sender, EventArgs e)
        {
            if (zaposleni.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite zaposlenog koga zelite da izmenite!");
                return;
            }

            int idZaposleni = Int32.Parse(zaposleni.SelectedItems[0].SubItems[0].Text);
            RadnikBasic r = DTOManager.vratiRadnika(idZaposleni);
            IzmeniZaposlenogForma forma = new IzmeniZaposlenogForma(r);
            forma.ShowDialog();
            popuniPodacima();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (zaposleni.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite zaposlenog cije podatke o radnom odnosu zelite da izmenite!");
                return;
            }

            int idZaposleni = Int32.Parse(zaposleni.SelectedItems[0].SubItems[0].Text);
            int idProdavnice = prodavnica.Id;
            List<RadiUBasic> rad = DTOManager.vratiRadniOdnos(idZaposleni, idProdavnice);
            RadiUBasic r = rad.First();
            IzmeniRadniOdnosForma forma = new IzmeniRadniOdnosForma(r);
            forma.ShowDialog();
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DodajPostojecegZaposlenogForma forma = new DodajPostojecegZaposlenogForma(prodavnica);
            forma.ShowDialog();
            popuniPodacima();
        }
    }
}

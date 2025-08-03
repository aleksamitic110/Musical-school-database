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
    public partial class SefoviForma : Form
    {
        ProdavnicaBasic prodavnica;

        public SefoviForma()
        {
            InitializeComponent();
        }
        
        public SefoviForma(ProdavnicaBasic p)
        {
            InitializeComponent();
            prodavnica = p;
        }

        private void SefoviForma_Load(object sender, EventArgs e)
        {
            this.Text = "PRODAVNICA " + prodavnica.Naziv.ToUpper();
            popuniPodacima();
        }

        public void popuniPodacima()
        {
            String pom;
            this.sefovi.Items.Clear();
            List<SefujeBasic> listaSefova = DTOManager.vratiSveSefoveProdavnice(prodavnica.Id);

            foreach (SefujeBasic r in listaSefova)
            {
                if (r.Upravnik.Sef == true)
                    pom = "Da";
                else
                    pom = "Ne";
                ListViewItem item = new ListViewItem(new string[] { r.Upravnik.Jbr.ToString(), r.Upravnik.Mbr.ToString(), r.Upravnik.Ime, r.Upravnik.SrednjeSlovo.ToString(),
                    r.Upravnik.Prezime, r.Upravnik.DatumRodjenja.ToShortDateString(), r.Upravnik.StrucnaSpema, pom,r.Id.ToString() });
                this.sefovi.Items.Add(item);
            }

            this.sefovi.Refresh();
        }

        private void btnDodajSefa_Click(object sender, EventArgs e)
        {
            DodajSefaForma forma = new DodajSefaForma(prodavnica);
            forma.ShowDialog();
            
            popuniPodacima();
        }

        private void btnObrisiSefa_Click(object sender, EventArgs e)
        {
            if (sefovi.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite sefa koga zelite da obrisete!");
                return;
            }

            int idSef = Int32.Parse(sefovi.SelectedItems[0].SubItems[8].Text);
            string poruka = "Da li zelite da obrisete izabranog sefa?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                DTOManager.obrisiSefa(idSef);
                MessageBox.Show("Brisanje sefa je uspesno obavljeno!");
                this.popuniPodacima();
            }
            else
            {

            }
        }

        private void btnIzmeniSefa_Click(object sender, EventArgs e)
        {
            if (sefovi.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite sefa koga zelite da izmenite!");
                return;
            }

            int idSefa = Int32.Parse(sefovi.SelectedItems[0].SubItems[0].Text);
            RadnikBasic r = DTOManager.vratiSefa(idSefa);
            IzmeniSefaForma forma = new IzmeniSefaForma(r);
            forma.ShowDialog();
            popuniPodacima();
        }

        private void btnDodajPostojeceg_Click(object sender, EventArgs e)
        {
           
        }

        private void sefovi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnDodajPostojeceg_Click_1(object sender, EventArgs e)
        {
           DodajPostojecegZaposlenogKaoSefa forma = new DodajPostojecegZaposlenogKaoSefa(prodavnica);
           forma.ShowDialog();
           popuniPodacima();
        }
    }
}

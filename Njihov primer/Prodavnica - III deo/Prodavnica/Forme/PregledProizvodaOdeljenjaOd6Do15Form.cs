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
    public partial class PregledProizvodaOdeljenjaOd6Do15Form : Form
    {
        OdeljenjeOd6Do15Basic odeljenje;

        public PregledProizvodaOdeljenjaOd6Do15Form()
        {
            InitializeComponent();
        }

        public PregledProizvodaOdeljenjaOd6Do15Form(OdeljenjeOd6Do15Basic o)
        {
            InitializeComponent();
            odeljenje = o;
        }

        private void PregledProizvodaOdeljenjaOd6Do15Form_Load(object sender, EventArgs e)
        {
            this.Text = "ODELJENJE OD 6 DO 15 GOD., MESTO " + odeljenje.Lokacija.ToUpper();
            popuniPodacima();
        }

        public void popuniPodacima()
        {
            proizvodi.Items.Clear();
            List<ProdajeSeBasic> podaci = DTOManager.vratiProizvodeOdeljenjaOd6Do15(odeljenje.OdeljenjeId);

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
            DodajProizvodOd6Do15Forma forma = new DodajProizvodOd6Do15Forma(odeljenje);
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

            if (tipProizvoda == "AUTOMOBILI")
            {
                AutomobilBasic r = DTOManager.vratiAutomobil(idProizvoda);
                IzmeniProizvodAutomobilForma forma = new IzmeniProizvodAutomobilForma(r);
                forma.ShowDialog();
                popuniPodacima();
            }
            else if(tipProizvoda == "VOJNICI")
            {
                VojnikBasic r = DTOManager.vratiVojnika(idProizvoda);
                IzmeniProizvodVojnikForma forma = new IzmeniProizvodVojnikForma(r);
                forma.ShowDialog();
                popuniPodacima();
            }
            else if (tipProizvoda == "LUTKE")
            {
                LutkaBasic r = DTOManager.vratiLutku(idProizvoda);
                IzmeniProizvodLutkaForma forma = new IzmeniProizvodLutkaForma(r);
                forma.ShowDialog();
                popuniPodacima();
            }
            else if (tipProizvoda == "DODACI ZA LUTKE")
            {
                DodatakZaLutkuBasic r = DTOManager.vratiDodatakZaLutku(idProizvoda);
                IzmeniProizvodDodatakZaLutkuForma forma = new IzmeniProizvodDodatakZaLutkuForma(r);
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

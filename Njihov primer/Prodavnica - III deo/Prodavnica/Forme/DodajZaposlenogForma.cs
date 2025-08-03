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
    public partial class DodajZaposlenogForma : Form
    {
        ProdavnicaBasic prodavnica;
        public DodajZaposlenogForma()
        {
            InitializeComponent();
        }

        public DodajZaposlenogForma(ProdavnicaBasic p)
        {
            InitializeComponent();
            prodavnica = p;
        }

        private void DodajZaposlenogForma_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            //Dodavanje Radnika
            RadnikBasic radnik = new RadnikBasic();
            radnik.Mbr = Int32.Parse(txbMbr.Text);
            radnik.Ime = txbIme.Text;
            radnik.SrednjeSlovo = Char.Parse(txbSrednjeSlovo.Text);
            radnik.Prezime = txbPrezime.Text;
            radnik.StrucnaSpema = txbStrucnaSprema.Text;
            radnik.DatumRodjenja = datumRodjenja.Value;
            radnik.Sef = false;

            DTOManager.dodajRadnika(radnik);

            //Dodavanje RadiU
            dodajRadniOdnos();

            MessageBox.Show("Uspesno ste dodali novog zaposlenog!");

            //Dodavanje Sefa
            /*if (chbSef.Checked == true)
            {
                SefujeBasic sefuje = new SefujeBasic();
                SefBasic s = new SefBasic();
                s.Mbr = Int32.Parse(txbMbr.Text);
                s.Ime = txbIme.Text;
                s.SrednjeSlovo = Char.Parse(txbSrednjeSlovo.Text);
                s.Prezime = txbPrezime.Text;
                s.StrucnaSpema = txbStrucnaSprema.Text;
                if (chbSef.Checked == true)
                    s.Sef = true;
                else
                    s.Sef = false;

                sefuje.DatumPostavljenja = DateTime.Now;
                sefuje.Upravnik = s;
                sefuje.Upravlja = prodavnica;
                //DTOManager.dodajSefa();
            }*/

        }
        public void dodajRadniOdnos()
        {
            RadiUBasic radi = new RadiUBasic();
            ProdavnicaBasic p = DTOManager.vratiProdavnicu(prodavnica.Id);
            List<RadnikBasic> radnici = DTOManager.vratiSveRadnike();
            RadnikBasic radnikPoslednjiDodat = radnici.OrderByDescending(item => item.Jbr).First();
            radi.Id = new RadiUIdBasic();
            radi.Id.RadiUProdavnica = p;
            radi.Id.RadnikRadiU = radnikPoslednjiDodat;
            radi.DatumOd = datumOd.Value;
            if (chbDatumDo.Checked == false)
                radi.DatumDo = DatumDo.Value;
            DTOManager.dodajRadniOdnos(radi);
            this.Close();
        }
        private void omoguciDatumDo(object sender, EventArgs e)
        {
            if (chbDatumDo.Checked == true)
                DatumDo.Enabled = true;
            else
                DatumDo.Enabled = false;
        }
    }
}

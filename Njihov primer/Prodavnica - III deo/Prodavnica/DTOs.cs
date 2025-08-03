using Prodavnica.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prodavnica
{

    #region Odeljenje
    public class OdeljenjeBasic
    {
        public int OdeljenjeId { get; set; }
        public string Lokacija { get; set; }
        public string NazivProdavnice { get; set; }
        public ProdavnicaBasic Prodavnica { get; set; }
        public int BrojProizvoda { get; set; }
        public int BrojKasa { get; set; }
        public string infoPult { get; set; }

        public OdeljenjeBasic(int odId, string lokacija, string nazivPr, int brojPr)
        {
            this.OdeljenjeId = odId;
            this.Lokacija = lokacija;
            this.NazivProdavnice = nazivPr;
            this.BrojProizvoda = brojPr;
        }
        public OdeljenjeBasic()
        {
           
        }
    }
    public class OdeljenjeDo5Basic : OdeljenjeBasic
    {
        public OdeljenjeDo5Basic()
        {

        }
        public OdeljenjeDo5Basic(int odId, string lokacija, string nazivPr, int brojPr) : base(odId, lokacija, nazivPr, brojPr)
        {
        }
    }

    public class OdeljenjeOd6Do15Basic: OdeljenjeBasic
    {
        public OdeljenjeOd6Do15Basic()
        {

        }
        public OdeljenjeOd6Do15Basic(int odId, string lokacija, string nazivPr, int brojPr) : base(odId, lokacija, nazivPr, brojPr)
        {
        }
    }

    public class OdeljenjeOdrasliBasic: OdeljenjeBasic
    {
        public OdeljenjeOdrasliBasic()
        {

        }
        public OdeljenjeOdrasliBasic(int odId, string lokacija, string nazivPr, int brojPr) : base(odId, lokacija, nazivPr, brojPr)
        {
        }
    }

    public class OdeljenjePregled
    {
        public int OdeljenjeId { get; set; }
        public string Lokacija { get; set; }
        public virtual int BrojKasa { get; set; }
        public virtual string InfoPult { get; set; }

        public OdeljenjePregled(int odId, string lokacija, int brojK, string infoP)
        {
            this.OdeljenjeId = odId;
            this.Lokacija = lokacija;
            this.BrojKasa = brojK;
            this.InfoPult = infoP;
        }

        public OdeljenjePregled()
        {
        }
       
    }
    public class OdeljenjeDo5Pregled : OdeljenjePregled
    {

        public OdeljenjeDo5Pregled(int odId, string lokacija, int brKasa, string infoPult) : base(odId, lokacija, brKasa, infoPult)
        {
        }
    }

    public class OdeljenjeOd6Do15Pregled : OdeljenjePregled
    {
        public OdeljenjeOd6Do15Pregled(int odId, string lokacija, int brKasa, string infoPult) : base(odId, lokacija, brKasa, infoPult)
        {
        }
    }

    public class OdeljenjeOdrasliPregled : OdeljenjePregled
    {
        public OdeljenjeOdrasliPregled(int odId, string lokacija, int brKasa, string infoPult) : base(odId, lokacija, brKasa, infoPult)
        {
        }
    }

    #endregion

    #region Prodavnica
    public class ProdavnicaPregled
    {
        public int Id;
        public string Naziv;
        public string Adresa;
        public string BrojTelefona;
        public string RadniDan;
        public string Subota;
        public string Nedelja;

        public ProdavnicaPregled()
        {

        }
        public ProdavnicaPregled(int id,string naziv,string adresa,string brTelefona,string radniDan,string subota,string nedelja)
        {
            this.Id = id;
            this.Naziv = naziv;
            this.Adresa = adresa;
            this.BrojTelefona = brTelefona;
            this.RadniDan = radniDan;
            this.Subota = subota;
            this.Nedelja = nedelja;
        }
    }

    public class ProdavnicaBasic
    {
        public int Id;
        public string Naziv;
        public string Adresa;
        public string BrojTelefona;
        public string RadniDan;
        public string Subota;
        public string Nedelja;

        public virtual IList<OdeljenjeBasic> Odeljenja { get; set; }

        public virtual IList<RadnikBasic> Radnici { get; set; }
        public virtual IList<SefujeBasic> SefujeSefovi { get; set; }

        public ProdavnicaBasic()
        {
            Odeljenja = new List<OdeljenjeBasic>();
            Radnici=new List<RadnikBasic>();
            SefujeSefovi=new List<SefujeBasic>();
        }
        public ProdavnicaBasic(int id, string naziv, string adresa, string brTelefona, string radniDan, string subota, string nedelja)
        {
            this.Id = id;
            this.Naziv = naziv;
            this.Adresa = adresa;
            this.BrojTelefona = brTelefona;
            this.RadniDan = radniDan;
            this.Subota = subota;
            this.Nedelja = nedelja;
        }
    }


    #endregion

    #region Radnik

    public class RadnikPregled
    {
        public int Jbr;
        public int Mbr;
        public string Ime;
        public char SrednjeSlovo;
        public string Prezime;
        public DateTime DatumRodjenja;
        public string StrucnaSpema;
        public bool Sef;

        public RadnikPregled()
        {

        }
        public RadnikPregled(int jbr,int mbr, string ime,char srednjeSlovo,string prezime,DateTime datumRodjenja,string strucnaSprema,bool sef)
        {
            this.Jbr = jbr;
            this.Mbr = mbr;
            this.Ime = ime;
            this.SrednjeSlovo = srednjeSlovo;
            this.Prezime = prezime;
            this.DatumRodjenja = datumRodjenja;
            this.StrucnaSpema = strucnaSprema;
            this.Sef = sef;
        }
    }

    public class RadnikBasic
    {
        public int Jbr;
        public int Mbr;
        public string Ime;
        public char SrednjeSlovo;
        public string Prezime;
        public DateTime DatumRodjenja;
        public string StrucnaSpema;
        public bool Sef;

        public  IList<RadiUBasic> RadiUProdavnice { get; set; }

        public RadnikBasic()
        {
            RadiUProdavnice=new List<RadiUBasic>();

        }
        public RadnikBasic(int jbr, int mbr, string ime, char srednjeSlovo, string prezime, DateTime datumRodjenja, string strucnaSprema, bool sef)
        {
            this.Jbr = jbr;
            this.Mbr = mbr;
            this.Ime = ime;
            this.SrednjeSlovo = srednjeSlovo;
            this.Prezime = prezime;
            this.DatumRodjenja = datumRodjenja;
            this.StrucnaSpema = strucnaSprema;
            this.Sef = sef;
        }
        public override string ToString()
        {
            return Ime + " " + SrednjeSlovo + " " + Prezime;
        }

    }

    public class SefPregled : RadnikPregled
    {

    }

    public class SefBasic:RadnikBasic
    {
        public  IList<SefujeBasic> SefujeProdavnice;

        
        public SefBasic()
        {
            SefujeProdavnice=new List<SefujeBasic>();
        }
        public SefBasic(int jbr, int mbr, string ime, char srednjeSlovo, string prezime, DateTime datumRodjenja, string strucnaSprema, bool sef)
        {
            this.Jbr = jbr;
            this.Mbr = mbr;
            this.Ime = ime;
            this.SrednjeSlovo = srednjeSlovo;
            this.Prezime = prezime;
            this.DatumRodjenja = datumRodjenja;
            this.StrucnaSpema = strucnaSprema;
            this.Sef = sef;
        }
        public override string ToString()
        {
            return this.Ime + " " + this.SrednjeSlovo + " " + this.Prezime;
        }
    }



    #endregion

    #region Sefuje
    public class SefujePregled
    {
        public int Id;
        public DateTime DatumPostavljenja;
        public SefBasic Upravnik;
        public ProdavnicaBasic Upravlja;

        public SefujePregled()
        {

        }
        public SefujePregled(int id,DateTime postavljenje, SefBasic upravnik,ProdavnicaBasic p)
        {
            this.Id = id;
            this.DatumPostavljenja = postavljenje;
            this.Upravnik = upravnik;
            this.Upravlja = p;
        }

    }

    public class SefujeBasic
    {
        public int Id;
        public DateTime DatumPostavljenja;
        public SefBasic Upravnik;
        public ProdavnicaBasic Upravlja;

        public SefujeBasic()
        {

        }
        public SefujeBasic(int id, DateTime postavljenje, SefBasic upravnik, ProdavnicaBasic p)
        {
            this.Id = id;
            this.DatumPostavljenja = postavljenje;
            this.Upravnik = upravnik;
            this.Upravlja = p;
        }

    }

    #endregion

    #region RadiU
    public class RadiUPregled
    {
        public RadiUId Id;
        public DateTime DatumOd;
        public DateTime? DatumDo;

        public RadiUPregled()
        {

        }

        public RadiUPregled(RadiUId id, DateTime datumOd, DateTime? datumDo)
        {
            this.Id = id;
            this.DatumOd = datumOd;
            this.DatumDo = datumDo;
        }
            
    }

    public class RadiUBasic
    {
        public RadiUIdBasic Id;
        public DateTime DatumOd;
        public DateTime? DatumDo;

        public RadiUBasic()
        {

        }

        public RadiUBasic(RadiUIdBasic id, DateTime datumOd, DateTime? datumDo)
        {
            this.Id = id;
            this.DatumOd = datumOd;
            this.DatumDo = datumDo;
        }

    }
    public class RadiUIdBasic
    {
        public  RadnikBasic RadnikRadiU { get; set; }
        public  ProdavnicaBasic RadiUProdavnica { get; set; }

        public RadiUIdBasic()
        {

        }

    }

    #endregion

    #region Proizvod
    public class ProizvodPregled
    {
        public int BarKod;
        public string Tip;
        public string Naziv;
        public string Proizvodjac;


        public ProizvodPregled()
        {

        }

        public ProizvodPregled(int barkod, string tip, string naziv, string proizvodjac)
        {
            this.BarKod = barkod;
            this.Tip = tip;
            this.Naziv = naziv;
            this.Proizvodjac = proizvodjac;
        }
    }
    public class ProizvodBasic
    {
        public int BarKod;
        public string Tip;
        public string Naziv;
        public string Proizvodjac;

        public IList<ProdajeSeBasic> ProdajeSeOdeljenja;

        public ProizvodBasic()
        {

        }

        public ProizvodBasic(int barkod, string tip, string naziv, string proizvodjac)
        {
            this.BarKod = barkod;
            this.Tip = tip;
            this.Naziv = naziv;
            this.Proizvodjac = proizvodjac;
        }

    }
    #endregion

    #region ProdajeSe
    public class ProdajeSePregled
    {
        public int Id;
        public ProizvodPregled ProdajeProzivod;
        public OdeljenjePregled ProdajeOdeljenje;

        public ProdajeSePregled()
        {

        }
        public ProdajeSePregled(int id, ProizvodPregled p, OdeljenjePregled o)
        {
            this.Id = id;
            this.ProdajeProzivod = p;
            this.ProdajeOdeljenje = o;
        }

    }

    public class ProdajeSeBasic
    {
        public int Id;
        public ProizvodBasic ProdajeProzivod;
        public OdeljenjeBasic ProdajeOdeljenje;

        public ProdajeSeBasic()
        {

        }
        public ProdajeSeBasic(int id, ProizvodBasic p, OdeljenjeBasic o)
        {
            this.Id = id;
            this.ProdajeProzivod = p;
            this.ProdajeOdeljenje = o;
        }
    }

    #endregion

    #region Vojnik
    public class VojnikPregled : ProizvodPregled
    {
        public string NazivSerije;
        public string Baterije;
        public string Metal;
        public string Plastika;

        public VojnikPregled()
        {

        }
        public VojnikPregled(int barkod, string tip, string naziv, 
            string proizvodjac,string nazivSerije,string baterije, string metal, string plastika):base(barkod,tip,naziv,proizvodjac)
        {
            this.NazivSerije = nazivSerije;
            this.Baterije = baterije;
            this.Metal = metal;
            this.Plastika = plastika;
        }
    }
    public class VojnikBasic : ProizvodBasic
    {
        public string NazivSerije;
        public string Baterije;
        public string Metal;
        public string Plastika;

        public VojnikBasic()
        {

        }
        public VojnikBasic(int barkod, string tip, string naziv,
            string proizvodjac, string nazivSerije, string baterije, string metal, string plastika) : base(barkod, tip, naziv, proizvodjac)
        {
            this.NazivSerije = nazivSerije;
            this.Baterije = baterije;
            this.Metal = metal;
            this.Plastika = plastika;
        }
    }


    #endregion

    #region Slagalica
    public class SlagalicaPregled : ProizvodPregled
    {
        public int BrojDelova;
        public string Turisticka;
        public string Umetnicka;
        public string Ilustracija;

        public SlagalicaPregled()
        {

        }

        public SlagalicaPregled(int barkod, string tip, string naziv,
            string proizvodjac, int brojDelova,string turisticka, string umetnicka,string ilustracija) : base(barkod, tip, naziv, proizvodjac)
        {
            this.BrojDelova = brojDelova;
            this.Turisticka = turisticka;
            this.Umetnicka = umetnicka;
            this.Ilustracija = ilustracija;
        }

    }

    public class SlagalicaBasic : ProizvodBasic
    {
        public int BrojDelova;
        public string Turisticka;
        public string Umetnicka;
        public string Ilustracija;

        public SlagalicaBasic()
        {

        }

        public SlagalicaBasic(int barkod, string tip, string naziv,
            string proizvodjac, int brojDelova, string turisticka, string umetnicka, string ilustracija) : base(barkod, tip, naziv, proizvodjac)
        {
            this.BrojDelova = brojDelova;
            this.Turisticka = turisticka;
            this.Umetnicka = umetnicka;
            this.Ilustracija = ilustracija;
        }

    }

    #endregion

    #region Lutka
    public class LutkaPregled : ProizvodPregled
    {
        public string Ime;
        public string Govori;
        public string OsetljivaDodir;

        public LutkaPregled()
        {

        }

        public LutkaPregled(int barkod, string tip, string naziv,
            string proizvodjac, string ime,string govori,string osetljiva) : base(barkod, tip, naziv, proizvodjac)
        {
            this.Ime = ime;
            this.Govori = govori;
            this.OsetljivaDodir = osetljiva;
        }
    }

    public class LutkaBasic : ProizvodBasic
    {
        public string Ime;
        public string Govori;
        public string OsetljivaDodir;

        public LutkaBasic()
        {

        }

        public LutkaBasic(int barkod, string tip, string naziv,
            string proizvodjac, string ime, string govori, string osetljiva) : base(barkod, tip, naziv, proizvodjac)
        {
            this.Ime = ime;
            this.Govori = govori;
            this.OsetljivaDodir = osetljiva;
        }
    }
    #endregion

    #region IgrackaPlastika 
    public class IgrackaPlastikaPregled : ProizvodPregled
    {
        public int Uzrast;
        public string Vodootporna;
        public string Lomljiva;

        public IgrackaPlastikaPregled()
        {

        }

        public IgrackaPlastikaPregled(int barkod, string tip, string naziv,
            string proizvodjac, int u, string vodootporna, string lomljiva) : base(barkod, tip, naziv, proizvodjac)
        {
            this.Uzrast = u;
            this.Vodootporna = vodootporna;
            this.Lomljiva = lomljiva;
        }
    }
    
    public class IgrackaPlastikaBasic : ProizvodBasic
    {
        public int Uzrast;
        public string Vodootporna;
        public string Lomljiva;

        public IgrackaPlastikaBasic()
        {

        }

        public IgrackaPlastikaBasic(int barkod, string tip, string naziv,
            string proizvodjac, int u, string vodootporna, string lomljiva) : base(barkod, tip, naziv, proizvodjac)
        {
            this.Uzrast = u;
            this.Vodootporna = vodootporna;
            this.Lomljiva = lomljiva;
        }
    }

    #endregion

    #region DodatakZaLutku
    public class DodatakZaLutkuPregled : ProizvodPregled
    {
        public string NazivDodatka;
        public string TipDodatka;

        public DodatakZaLutkuPregled()
        {

        }

        public DodatakZaLutkuPregled(int barkod, string tip, string naziv,
            string proizvodjac, string nazivDodatka, string tipDodatka) : base(barkod, tip, naziv, proizvodjac)
        {
            this.NazivDodatka = nazivDodatka;
            this.TipDodatka = tipDodatka;
        }
    }

    public class DodatakZaLutkuBasic : ProizvodBasic
    {
        public string NazivDodatka;
        public string TipDodatka;

        public DodatakZaLutkuBasic()
        {

        }

        public DodatakZaLutkuBasic(int barkod, string tip, string naziv,
            string proizvodjac, string nazivDodatka, string tipDodatka) : base(barkod, tip, naziv, proizvodjac)
        {
            this.NazivDodatka = nazivDodatka;
            this.TipDodatka = tipDodatka;
        }

    }

    #endregion

    #region Automobil
    public class AutomobilPregled : ProizvodPregled
    {
        public string NazivSerije;
        public string Baterije;

        public AutomobilPregled()
        {

        }
        public AutomobilPregled(int barkod, string tip, string naziv,
            string proizvodjac, string serija,string baterije) : base(barkod, tip, naziv, proizvodjac)
        {
            this.NazivSerije = serija;
            this.Baterije = baterije;
        }
    }

    public class AutomobilBasic : ProizvodBasic
    {
        public string NazivSerije;
        public string Baterije;

        public AutomobilBasic()
        {

        }
        public AutomobilBasic(int barkod, string tip, string naziv,
            string proizvodjac, string serija, string baterije) : base(barkod, tip, naziv, proizvodjac)
        {
            this.NazivSerije = serija;
            this.Baterije = baterije;
        }
    }


    #endregion
}

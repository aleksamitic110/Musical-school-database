using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.DTOs
{

    #region Filijala
    public class FilijalaDTO
    {
        public string Id { get; set; }
        public string Adresa { get; set; }
        public string RadnoVreme { get; set; }
        public string OpremljenostUcionica { get; set; }
        public int KapacitetFilijale { get; set; }
        public FilijalaDTO()
        {

        }
        public FilijalaDTO(string id, string adresa, string radnoVreme, string opremljenostUcionica, int kapacitetFilijale)
        {
            Id = id;
            Adresa = adresa;
            RadnoVreme = radnoVreme;
            OpremljenostUcionica = opremljenostUcionica;
            KapacitetFilijale = kapacitetFilijale;
        }
    }
    #endregion

    #region Ucionica
    public class UcionicaDTO
    {
        public string Id { get; set; }
        public string Oznaka { get; set; }
        public int KapacitetUcionice { get; set; }
        public string FilijalaId { get; set; }  

        public UcionicaDTO() { }

        public UcionicaDTO(string id, string oznaka, int kapacitetUcionice, string filijalaId)
        {
            Id = id;
            Oznaka = oznaka;
            KapacitetUcionice = kapacitetUcionice;
            FilijalaId = filijalaId;
        }
    }
	#endregion

	#region Kurs
	public class KursDTO
	{
		// Osnovni podaci
		public string Id { get; set; }
		public string Naziv { get; set; }
		public string Nivo { get; set; }
		public string TipNastave { get; set; }

		
		public string Filijala { get; set; } 
		public int Nastavnik { get; set; }  

		
		public string? Instrumenti { get; set; }
		public string? NazivPredmeta { get; set; }
		public string? TipPevanja { get; set; }

		public KursDTO() { }
	}

	#endregion

	
    #region Cas
    public class CasDTO
    {
        public string IdCasa { get; set; }
        public string IdKursa { get; set; }
        public string IdUcionice { get; set; }
        public DateTime Datum { get; set; }   // proper date type
        public string Vreme { get; set; }     // stored separately as string
        public string Lekcija { get; set; }

        public CasDTO() { }

        public CasDTO(string idCasa, string idKursa, string idUcionice, DateTime datum, string vreme, string lekcija)
        {
            IdCasa = idCasa;
            IdKursa = idKursa;
            IdUcionice = idUcionice;
            Datum = datum;
            Vreme = vreme;
            Lekcija = lekcija;
        }
    }
    #endregion

    #region Evidencija
    public class EvidencijaDTO
    {
		public int Id { get; set; }
		public int Ocena { get; set; }
		public bool Prisustvo { get; set; }

		public int PolaznikId { get; set; }
		public string CasId { get; set; }

		public EvidencijaDTO() { }

		public EvidencijaDTO(int id, int ocena, bool prisustvo, int polaznikId, string casId)
		{
			Id = id;
			Ocena = ocena;
			Prisustvo = prisustvo;
			PolaznikId = polaznikId;
			CasId = casId;
		}
	}
    #endregion

    #region Osoba
    public class OsobaDTO
    {

        public string JMBG { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Adresa { get; set; }
        public string Mail { get; set; }
        public string Telefoni { get; set; }

        public OsobaDTO(string JMBG, string ime, string prezime, string adresa, string mail, string telefoni)
        {
            this.JMBG = JMBG;
            Ime = ime;
            Prezime = prezime;
            Adresa = adresa;
            Mail = mail;
            Telefoni = telefoni;
        }
        public OsobaDTO() { }
    }
    public class OsobaBasic
    {
        public string JMBG { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Adresa { get; set; }
        public string Mail { get; set; }
        public IList<TelefonBasic> Telefoni { get; set; } = new List<TelefonBasic>();
    }

    #endregion

    #region Polaznik
    public class PolaznikDTO : OsobaDTO
    {
        public int Id { get; set; }
        public PolaznikDTO(int Id, string JMBG, string ime, string prezime, string adresa, string mail, string telefoni) : base(JMBG, ime, prezime, adresa, mail, telefoni)
        {
            this.Id = Id;
        }
        public PolaznikDTO() { }
    }


    public class PolaznikBasic
    {
        public int Id { get; set; }
        public virtual IList<Pohadja> Kursevi { get; set; } = new List<Pohadja>();
        public virtual IList<Evidencija> Prisustva { get; set; } = new List<Evidencija>();
        public virtual IList<Polaganje> Polaganja { get; set; } = new List<Polaganje>();

    }

    #endregion

    #region Staratelj
    public class StarateljDTO : OsobaDTO
    {
        public int Id { get; set; }
        public IList<Dete> Deca { get; set; }


        public StarateljDTO(int IdStaratelja, IList<Dete> deca, string jmbg, string ime, string prezime, string adresa, string mail, string telefoni)
        : base(jmbg, ime, prezime, adresa, mail, telefoni)
        {
            this.Id = IdStaratelja;
            this.Deca = deca;
        }

        public StarateljDTO()
        {
            Deca = new List<Dete>();
        }

        public override string ToString()
        {
            return $"{this.Id} - {this.Ime} {this.Prezime}";
        }
    }

        public class SacuvajStarateljaDTO
        {
        public StarateljBasic NoviStaratelj { get; set; }
        public OsobaBasic NovaOsoba { get; set; }
        }


public class StarateljBasic
    {
        public IList<Dete> Deca { get; set; }

        public StarateljBasic()
        {
            Deca = new List<Dete>();
        }
    }
    #endregion

    #region Nastavnik
    public class NastavnikDTO : OsobaDTO
    {
        public int Id { get; set; }
        public string StrucnaSprema { get; set; }
        public DateTime DatumZaposlenja { get; set; }
        public NastavnikDTO(string JMBG, string ime, string prezime, string adresa, string mail, string telefoni, int Id, string strucnaSprema, DateTime datumZaposlenja) : base(JMBG, ime, prezime, adresa, mail, telefoni)
        {
            this.Id = Id;
            this.StrucnaSprema = strucnaSprema;
            this.DatumZaposlenja = datumZaposlenja;

        }
        public NastavnikDTO() { }

    }

    public class NastavnikKursDto
    {
        public string Id { get; set; }
        public string Naziv { get; set; }
        public string Nivo { get; set; }
        public string TipNastave { get; set; }
        public string AdresaFilijale { get; set; }
        public string RadnoVremeFilijale { get; set; }
        public NastavnikKursDto() { }
        public NastavnikKursDto(string Id, string Naziv, string Nivo, string TipNastave, string Adresa, string radnoVreme)
        {
            this.Id = Id;
            this.Naziv = Naziv;
            this.Nivo = Nivo;
            this.TipNastave = TipNastave;
            this.AdresaFilijale = Adresa;
            this.RadnoVremeFilijale = radnoVreme;
        }
    }

    public class NastavnikPolaznikDto : OsobaDTO
    {
        public NastavnikPolaznikDto(string JMBG, string ime, string prezime, string adresa, string mail, string telefoni) : base(JMBG, ime, prezime, adresa, mail, telefoni)
        {

        }
        public NastavnikPolaznikDto() { }
    }
    public class NastavnikIspitDto
    {
        public string Id { get; set; }
        public string NazivKursa { get; set; }
        public DateTime Datum { get; set; }
        public NastavnikIspitDto(string Id, string nazivKursa, DateTime datum)
        {
            this.Id = Id;
            this.NazivKursa = nazivKursa;
            this.Datum = datum;
        }
        public NastavnikIspitDto() { }
    }


    public class NastavnikBasic
    {
        public string StrucnaSprema { get; set; }
        public DateTime DatumZaposlenja { get; set; }
    }

    #endregion

    #region Honorarni
    public class HonorarniDTO : NastavnikDTO
    {
        public string BrojUgovora { get; set; }
        public int BrojCasovaMesecno { get; set; }
        public DateTime TrajanjeUgovora { get; set; }

		public HonorarniDTO() { }
		public HonorarniDTO(string JMBG, string ime, string prezime, string adresa, string mail, string telefoni, int Id, string strucnaSprema, DateTime datumZaposlenja, string brojUgovora, int brojCasovaMesecno, DateTime trajanjeUgovora) : base(JMBG, ime, prezime, adresa, mail, telefoni, Id, strucnaSprema, datumZaposlenja)
        {
            BrojUgovora = brojUgovora;
            BrojCasovaMesecno = brojCasovaMesecno;
            TrajanjeUgovora = trajanjeUgovora;
        }
    }
    public class HonorarniBasic
    {
        public string BrojUgovora { get; set; }
        public int BrojCasovaMesecno { get; set; }
        public DateTime TrajanjeUgovora { get; set; }
    }
    #endregion

    #region Stalni
    public class StalniDTO : NastavnikDTO
    {
        public string RadnoVreme { get; set; }
        public bool StatusMentora { get; set; }
        public StalniDTO(string JMBG, string ime, string prezime, string adresa, string mail, string telefoni, int Id, string strucnaSprema, DateTime datumZaposlenja, string radnoVreme, bool statusMentora) : base(JMBG, ime, prezime, adresa, mail, telefoni, Id, strucnaSprema, datumZaposlenja)
        {
            RadnoVreme = radnoVreme;
            StatusMentora = statusMentora;
        }
    }

        public class SacuvajStalnogDTO
        {
    public StalniBasic NoviStalni { get; set; }
    public string MentorJMBG { get; set; }
    public OsobaBasic NovaOsoba { get; set; }
    public NastavnikBasic NoviNastavnik { get; set; }
        }

        public class IzmeniStalnogDTO
        {
    public StalniBasic NoviStalni { get; set; }
    public int StalniId { get; set; }
    public string MentorJMBG { get; set; }
    public OsobaBasic NovaOsoba { get; set; }
    public NastavnikBasic NoviNastavnik { get; set; }
    public int NastavnikId { get; set; }
        }

public class StalniBasic
    {
        public string RadnoVreme { get; set; }
    }

    #endregion

    #region Dete
    public class DeteDTO : PolaznikDTO
    {
        public int IdDeteta { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string BrojDosijea { get; set; }
        public StarateljDTO Staratelj { get; set; }

        public DeteDTO() { }
        public DeteDTO(int IdDeteta, StarateljDTO Staratelj, DateTime DatumRodjenja, string BrojDosijea, int Id, string JMBG, string ime, string prezime, string adresa, string mail, string telefoni)
        : base(Id, JMBG, ime, prezime, adresa, mail, telefoni)
        {
            this.IdDeteta = IdDeteta;
            this.DatumRodjenja = DatumRodjenja;
            this.BrojDosijea = BrojDosijea;
            this.Staratelj = Staratelj;
        }
    }

    public class SacuvajDeteDTO
    {
    public DeteBasic NovoDete { get; set; }
    public PolaznikBasic NoviPolaznik { get; set; }
    public OsobaBasic NovaOsoba { get; set; }
    }

public class DeteBasic
    {
        public int IdDeteta { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string BrojDosijea { get; set; }
        public StarateljBasic Staratelj { get; set; }

    }
        public class DeteUpdateRequest
    {
    public DeteDTO Dete { get; set; }
    public PolaznikBasic NoviPolaznik { get; set; }
    public OsobaBasic NovaOsoba { get; set; }
        }
#endregion

    #region Odrasli
    public class OdrasliDTO : PolaznikDTO
        {
            public String Zanimanje { get; set; }

            public OdrasliDTO() { }

            public OdrasliDTO(String Zanimanje, int Id, string JMBG, string ime, string prezime, string adresa, string mail, string telefoni)
            : base(Id, JMBG, ime, prezime, adresa, mail, telefoni)
            {
                this.Zanimanje = Zanimanje;
            }
        }

        public class OdrasliBasic
        {
            public String Zanimanje;
        }
        public class OdrasliUpdateRequest
        {
        public PolaznikBasic NoviPolaznik { get; set; }
        public OdrasliBasic NoviOdrasli { get; set; }
        public OsobaBasic NovaOsoba { get; set; }
        }
    #endregion

    #region Pohadja
    public class PohadjaDTO
        {
           public int ID { get; set; }
           public Polaznik Polaznik { get; set; }
           public Kurs Kurs { get; set; }
          public PohadjaDTO(int id, Polaznik polaznik, Kurs kurs) { 
            ID = id;
            Polaznik = polaznik;
            Kurs = kurs;   
        }

        }
        #endregion

    #region Polaganje
        public class PolaganjeDTO
        {
            public int Id { get; set; }
            public string JMBG { get; set; }
            public string Ime { get; set; }
            public string Prezime { get; set; }
            public string KursNaziv { get; set; }
            public DateTime Datum { get; set; }
            public int Ocena { get; set; }
            public bool Polozio { get; set; }

            public PolaganjeDTO(int id, string jmbg, string ime, string prezime, string kursNaziv, DateTime datum, int ocena, bool polozio)
            {
                Id = id;
                JMBG = jmbg;
                Ime = ime;
                Prezime = prezime;
                KursNaziv = kursNaziv;
                Datum = datum;
                Ocena = ocena;
                Polozio = polozio;
            }

        }

         public class DodajPolaganjeDTO
         {
        public List<int> PolaznikIds { get; set; }
        public string IspitId { get; set; }
         }
    #endregion

    #region Telefon
    public class TelefonDTO
        {

        }

        public class TelefonBasic
        {
            public string BrojTelefona { get; set; }
            public Osoba Osoba { get; set; }
        }

        #endregion

    #region Komisija
    public class KomisijaDTO
    {
		public int Id { get; set; }

	
		public int NastavnikId { get; set; }
		public string IspitId { get; set; }

	
		public string NastavnikImePrezime { get; set; }
		public string IspitKursNaziv { get; set; }

		public KomisijaDTO() { }
	}
    #endregion

    #region Ispit
        public class IspitDTO
        {
            public string Id { get; set; }
            public string KursId { get; set; }
            public string KursNaziv { get; set; }
            public DateTime Datum { get; set; }
            public string Komisija { get; set; }

            public double ProsecnaOcena { get; set; }

            public IspitDTO() { }

            public IspitDTO(string id, string kursId, string kursNaziv, DateTime datum, string komisija)
            {
                Id = id;
                KursId = kursId;
                KursNaziv = kursNaziv;
                Datum = datum;
                Komisija = komisija;
            }

            public IspitDTO(string id, string kursId, string kursNaziv, DateTime datum, string komisija, double prosecnaOcena)
            {
                Id = id;
                KursId = kursId;
                KursNaziv = kursNaziv;
                Datum = datum;
                Komisija = komisija;
                ProsecnaOcena = prosecnaOcena;
            }

        }

        public class IspitBasic
        {
            public string Id { get; set; }
            public DateTime Datum { get; set; }
		    public string KursId { get; set; }
		    public List<int> NastavnikIds { get; set; } = new List<int>();
        }
        #endregion
}

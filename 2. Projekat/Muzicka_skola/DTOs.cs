using Muzicka_skola.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muzicka_skola
{
	//Data transfer objects
	/*
         DTO su obicne klase koje se koriste za insertovanje i citanje podataka. U njih se smestaju podaci kad se procita i u njih 
            se smestaju podaci kad se iz baze cita.
    */

	#region Filijala
	public class FilijalaDTO
	{

	}
	#endregion

	#region Ucionica
	public class UcionicaDTO
	{

	}
	#endregion

	#region Kurs
	public class KursDTO
	{

	}
	#endregion

	#region KursInstrumentalni
	public class KursInstrumentalniDTO
	{

	}
	#endregion

	#region KursVokalni
	public class KursVokalniDTO
	{

	}
	#endregion

	#region KursTeorijski
	public class KursTeorijskiDTO
	{

	}
	#endregion

	#region Cas
	public class CasDTO{ 
    
    }
	#endregion

	#region Evidencija
	public class EvidencijaDTO
	{

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
	public class OsobaBasic {
        public string JMBG { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Adresa { get; set; }
        public string Mail { get; set; }
        public IList<TelefonBasic> Telefoni { get; set; } = new List<TelefonBasic>();
    }

	#endregion

	#region Polaznik
	public class PolaznikDTO
	{

	}
	#endregion

	#region Staratelj
	public class StarateljDTO
	{

	}
	#endregion

	#region Nastavnik
	public class NastavnikDTO : OsobaDTO
	{
		public int Id { get; set; }
        public string StrucnaSprema { get; set; }
        public DateTime DatumZaposlenja { get; set; }
        public NastavnikDTO(string JMBG, string ime, string prezime, string adresa, string mail, string telefoni, int Id, string strucnaSprema, DateTime datumZaposlenja) : base(JMBG,ime,prezime,adresa,mail,telefoni){ 
			this.Id = Id;
			this.StrucnaSprema = strucnaSprema;
			this.DatumZaposlenja = datumZaposlenja;
			
		}

	}
	public class NastavnikBasic {
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
		public HonorarniDTO(string JMBG, string ime, string prezime, string adresa, string mail, string telefoni, int Id, string strucnaSprema, DateTime datumZaposlenja, string brojUgovora, int brojCasovaMesecno, DateTime trajanjeUgovora) : base(JMBG, ime, prezime, adresa, mail, telefoni, Id, strucnaSprema, datumZaposlenja)
		{
			BrojUgovora = brojUgovora;
			BrojCasovaMesecno = brojCasovaMesecno;
			TrajanjeUgovora = trajanjeUgovora;
		}
    }
	public class HonorarniBasic {
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

	public class StalniBasic {
        public string RadnoVreme { get; set; }
        public bool StatusMentora { get; set; }
    }

	#endregion

	#region Dete
	public class DeteDTO
	{

	}
	#endregion

	#region Odrasli
	public class OdrasliDTO
	{

	}
	#endregion

	#region Pohadja
	public class PohadjaDTO
	{

	}
	#endregion

	#region Polaganje
	public class PolaganjeDTO
	{

	}
	#endregion

	#region Telefon
	public class TelefonDTO
	{

	}

	public class TelefonBasic {
        public string BrojTelefona { get; set; }
        public Osoba Osoba { get; set; }
    }

	#endregion

	#region Komisija
	public class KomisijaDTO
	{

	}
	#endregion

	#region Ispit
	public class IspitDTO
	{

	}
	#endregion

}

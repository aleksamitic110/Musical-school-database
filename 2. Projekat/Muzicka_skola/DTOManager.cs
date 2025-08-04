using FluentNHibernate.Testing.Values;
using Muzicka_skola.Entiteti;
using NHibernate;
using NHibernate.Dialect.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Muzicka_skola
{
    //Data transfer objects manager
	/*
		Ovde se pisu funkcije npr. DodajFilijalu(), ObrisiFilijalu(), FiltrirajPoGodinama()... samo primere dajem
		Kod njihovog primera moze da se vidi kako se zaista implementira i sta treba da vraca i sta treba da se kosristi za funkcije
	 */
    public class DTOManager
    {
		#region Filijala
		
		#endregion

		#region Ucionica
		
		#endregion

		#region Kurs
		
		#endregion

		#region KursInstrumentalni
		
		#endregion

		#region KursVokalni
		
		#endregion

		#region KursTeorijski
		
		#endregion

		#region Cas
		
		#endregion

		#region Evidencija
		
		#endregion

		#region Osoba

        public static string sacuvajOsobu(OsobaBasic novaOsoba)
        {
            string osobaJMBG = "";
            try
            {
                ISession session = DataLayer.GetSession();
                Osoba osoba = new Osoba {
                Adresa = novaOsoba.Adresa,
                Ime = novaOsoba.Ime,
                JMBG=novaOsoba.JMBG,
                Mail= novaOsoba.Mail,
                Prezime= novaOsoba.Prezime,
                };
                foreach (var item in novaOsoba.Telefoni)
                {
                    var telefon = new Telefon { BrojTelefona = item.BrojTelefona, Osoba = osoba };
                    osoba.Telefoni.Add(telefon);

                }
                session.Save(osoba);
                session.Flush();
                session.Close();
                osobaJMBG = osoba.JMBG;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.InnerException?.Message);
            }
            return osobaJMBG;
        }
		
		#endregion

		#region Polaznik
		
		#endregion

		#region Staratelj
		
		#endregion

		#region Nastavnik
		public static List<NastavnikDTO> vratiSveNastavnike()
		{
            List < NastavnikDTO > nastavnici = new List<NastavnikDTO> ();
            try
			{
                ISession session = DataLayer.GetSession();
				nastavnici = session.Query<Nastavnik>().Select(n => new NastavnikDTO(n.StrucnaSprema,
					n.DatumZaposlenja,
					n.Osoba.JMBG,
					n.Osoba.Ime,
					n.Osoba.Prezime,
					n.Osoba.Adresa,
					n.Osoba.Mail,
					string.Join(", ", n.Osoba.Telefoni.Select(t => t.BrojTelefona))
					)).ToList();
                session.Close();
            }
            catch (Exception ex)
            {
				MessageBox.Show(ex.Message);
            }
			return nastavnici;
        }

        public static int sacuvajNastavnika(NastavnikBasic noviNastavnik, string osobaJMBG)
        {
            int nastavnikId = 0;
            try
            {
                ISession session = DataLayer.GetSession();
                Nastavnik nastavnik = new Nastavnik
                {
                    DatumZaposlenja = noviNastavnik.DatumZaposlenja,
                    StrucnaSprema = noviNastavnik.StrucnaSprema,
                    Osoba = session.Load<Osoba>(osobaJMBG),
                };
                
                session.Save(nastavnik);
                session.Close();
                nastavnikId = nastavnik.Id;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return nastavnikId;
        }

        #endregion

        #region Honorarni

        public static List<HonorarniDTO> vratiSveHonorarneNastavnike()
        {
            List<HonorarniDTO> honorarniNastavnici = new List<HonorarniDTO>();
            try
            {
                ISession session = DataLayer.GetSession();
                honorarniNastavnici = session.Query<Honorarni>().Select(h => new HonorarniDTO(h.BrojUgovora,
					h.BrojCasovaMesecno,
					h.TrajanjeUgovora,
					h.Nastavnik.StrucnaSprema,
					h.Nastavnik.DatumZaposlenja,
                    h.Nastavnik.Osoba.JMBG,
                    h.Nastavnik.Osoba.Ime,
                    h.Nastavnik.Osoba.Prezime,
                    h.Nastavnik.Osoba.Adresa,
                    h.Nastavnik.Osoba.Mail,
                    string.Join(", ", h.Nastavnik.Osoba.Telefoni.Select(t => t.BrojTelefona))
                    )).ToList();
                session.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return honorarniNastavnici;
        }

        public static void sacuvajHonorarnogNastavnika(HonorarniBasic noviHonorarni, int nastavnikId)
        {
            try
            {
                ISession session = DataLayer.GetSession();
                Honorarni honorarni = new Honorarni
                {
                    BrojCasovaMesecno = noviHonorarni.BrojCasovaMesecno,
                    BrojUgovora = noviHonorarni.BrojUgovora,
                    TrajanjeUgovora = noviHonorarni.TrajanjeUgovora,
                    Nastavnik = session.Load<Nastavnik>(nastavnikId),
                };
                session.Save(honorarni);
                session.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Stalni
        public static List<StalniDTO> vratiSveStalneNastavnike()
        {
            List<StalniDTO> stalniNastavnci = new List<StalniDTO>();
            try
            {
                ISession session = DataLayer.GetSession();
                stalniNastavnci = session.Query<Stalni>().Select(s => new StalniDTO(s.RadnoVreme, s.StatusMentora,
                    s.Nastavnik.StrucnaSprema,
                    s.Nastavnik.DatumZaposlenja,
                    s.Nastavnik.Osoba.JMBG,
                    s.Nastavnik.Osoba.Ime,
                    s.Nastavnik.Osoba.Prezime,
                    s.Nastavnik.Osoba.Adresa,
                    s.Nastavnik.Osoba.Mail,
                    string.Join(", ", s.Nastavnik.Osoba.Telefoni.Select(t => t.BrojTelefona))
                    )).ToList();
                session.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return stalniNastavnci;
        }

        public static void sacuvajStalnog(StalniBasic noviStalni, int nastavnikId, string mentorJMBG)
        {
            try
            {
                ISession session = DataLayer.GetSession();
                Stalni stalni = new Stalni()
                {
                    RadnoVreme = noviStalni.RadnoVreme,
                    StatusMentora = noviStalni.StatusMentora,
                    Mentor = session.Load<Osoba>(mentorJMBG),
                    Nastavnik = session.Load<Nastavnik>(nastavnikId),
                };
                session.Save(stalni);
                session.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Dete

        #endregion

        #region Odrasli

        #endregion

        #region Pohadja

        #endregion

        #region Polaganje

        #endregion

        #region Telefon

        #endregion

        #region Komisija

        #endregion

        #region Ispit

        #endregion

    }
}

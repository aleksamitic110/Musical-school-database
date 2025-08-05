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
                Osoba osobaUBazi = session.Query<Osoba>().FirstOrDefault(o => o.JMBG == novaOsoba.JMBG);
                if (osobaUBazi != null) {
                    throw new Exception("Osoba sa tim JMBG-om vec postoji");
                }
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
                session.Close();
                osobaJMBG = osoba.JMBG;
            }
			catch (Exception ex)
			{
				StringBuilder sb = new StringBuilder();
				sb.AppendLine("Greška prilikom čuvanja osobe:");
				sb.AppendLine();

				int level = 0;
				Exception currentEx = ex;
				while (currentEx != null)
				{
					sb.AppendLine($"[Nivo {level}] {currentEx.GetType().FullName}");
					sb.AppendLine($"Poruka: {currentEx.Message}");
					sb.AppendLine("StackTrace:");
					sb.AppendLine(currentEx.StackTrace);
					sb.AppendLine(new string('-', 40));

					currentEx = currentEx.InnerException;
					level++;
				}

				MessageBox.Show(sb.ToString(), "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			return osobaJMBG;
        }

<<<<<<< HEAD
=======
        public static void IzmeniOsobu(OsobaBasic novaOsoba)
        {
            try
            {
                ISession session = DataLayer.GetSession();
                Osoba osoba = session.Load<Osoba>(novaOsoba.JMBG);
                osoba.Telefoni.Clear();
                session.Update(osoba);
                session.Flush();
                foreach (var item in novaOsoba.Telefoni)
                {
                    var telefon = new Telefon { BrojTelefona = item.BrojTelefona, Osoba = osoba };
                    osoba.Telefoni.Add(telefon);
                }
                osoba.Ime = novaOsoba.Ime;
                osoba.Prezime = novaOsoba.Prezime;
                osoba.Adresa = novaOsoba.Adresa;
                osoba.Mail = novaOsoba.Mail;
                session.Update(osoba);
                session.Flush();
                session.Close();
            }
            catch (Exception ex)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Greška prilikom čuvanja osobe:");
                sb.AppendLine();

                int level = 0;
                Exception currentEx = ex;
                while (currentEx != null)
                {
                    sb.AppendLine($"[Nivo {level}] {currentEx.GetType().FullName}");
                    sb.AppendLine($"Poruka: {currentEx.Message}");
                    sb.AppendLine("StackTrace:");
                    sb.AppendLine(currentEx.StackTrace);
                    sb.AppendLine(new string('-', 40));

                    currentEx = currentEx.InnerException;
                    level++;
                }

                MessageBox.Show(sb.ToString(), "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
		
>>>>>>> 7d351d84e72578343b643525acf0fd9d5df1226e
		#endregion

		#region Polaznik
		public static List<PolaznikDTO> vratiPolaznike()
		{
			List<PolaznikDTO> polaznici = new List<PolaznikDTO>();
			try
			{
				ISession session = DataLayer.GetSession();
				polaznici = session.Query<Polaznik>().Select(n => new PolaznikDTO(
                    n.Id,
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
			return polaznici;
		}

		#endregion

		#region Staratelj

		#endregion

		#region Nastavnik
		public static List<NastavnikDTO> PrikaziSveNastavnike()
		{
            List < NastavnikDTO > nastavnici = new List<NastavnikDTO> ();
            try
			{
                ISession session = DataLayer.GetSession();
				nastavnici = session.Query<Nastavnik>().Select(n => new NastavnikDTO(
                    n.Osoba.JMBG,
                    n.Osoba.Ime,
                    n.Osoba.Prezime,
                    n.Osoba.Adresa,
                    n.Osoba.Mail,
                    string.Join(",", n.Osoba.Telefoni.Select(t => t.BrojTelefona)),
                    n.Id,
                    n.StrucnaSprema,
                    n.DatumZaposlenja.Date
					)).ToList();
                session.Close();
            }
            catch (Exception ex)
            {
				MessageBox.Show(ex.Message);
            }
			return nastavnici;
        }

        public static int SacuvajNastavnika(NastavnikBasic noviNastavnik, string osobaJMBG)
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

        public static void ObrisiNastavnika(int nastavnikId)
        {
            try
            {
                ISession session = DataLayer.GetSession();
                var nastavnik = session.Load<Nastavnik>(nastavnikId);

                Honorarni honorarni = session.Query<Honorarni>().FirstOrDefault(h => h.Nastavnik.Id == nastavnikId);
                if (honorarni != null)
                    session.Delete(honorarni);

                Stalni stalni = session.Query<Stalni>().FirstOrDefault(s => s.Nastavnik.Id == nastavnikId);
                if (stalni != null)
                    session.Delete(stalni);

                session.Delete(nastavnik);

                Osoba osoba = session.Query<Osoba>().FirstOrDefault(s => s.JMBG == nastavnik.Osoba.JMBG);
                foreach (var telefon in osoba.Telefoni.ToList())
                {
                    session.Delete(telefon);
                }
                session.Delete(osoba);
                session.Flush();
                session.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška prilikom brisanja: " + ex.Message);
            }
        }

        public static void IzmeniNastavnika(NastavnikBasic noviNastavnik, int nastavnikId)
        {
            try
            {
                ISession session = DataLayer.GetSession();
                Nastavnik nastavnik = session.Load<Nastavnik>(nastavnikId);
                nastavnik.StrucnaSprema = noviNastavnik.StrucnaSprema;
                nastavnik.DatumZaposlenja = noviNastavnik.DatumZaposlenja;
                session.Update(nastavnik);
                session.Flush();
                session.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška prilikom brisanja: " + ex.Message);
            }
        }

        #endregion

        #region Honorarni

        public static List<HonorarniDTO> PrikaziSveHonorarneNastavnike()
        {
            List<HonorarniDTO> honorarniNastavnici = new List<HonorarniDTO>();
            try
            {
                ISession session = DataLayer.GetSession();
                honorarniNastavnici = session.Query<Honorarni>().Select(h => new HonorarniDTO(
                    h.Nastavnik.Osoba.JMBG,
                    h.Nastavnik.Osoba.Ime,
                    h.Nastavnik.Osoba.Prezime,
                    h.Nastavnik.Osoba.Adresa,
                    h.Nastavnik.Osoba.Mail,
                    string.Join(", ", h.Nastavnik.Osoba.Telefoni.Select(t => t.BrojTelefona)),
                     h.Nastavnik.Id,
                     h.Nastavnik.StrucnaSprema,
                     h.Nastavnik.DatumZaposlenja.Date,
                    h.BrojUgovora,
					h.BrojCasovaMesecno,
					h.TrajanjeUgovora.Date
                    )).ToList();
                session.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return honorarniNastavnici;
        }

        public static void SacuvajHonorarnogNastavnika(HonorarniBasic noviHonorarni, int nastavnikId)
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

        public static Honorarni NadjiHonorarnog(int nastavnikId)
        {
            Honorarni honorarni = null;
            try
            {
                ISession session = DataLayer.GetSession();
                honorarni = session.Query<Honorarni>().FirstOrDefault(h => h.Nastavnik.Id == nastavnikId);
                session.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return honorarni;
        }

        public static void ObrisiHonorarnogNastavnika(int honorarniId)
        {
            try
            {
                ISession session = DataLayer.GetSession();
                Honorarni honorarni = session.Load<Honorarni>(honorarniId);
                if (honorarni != null)
                    session.Delete(honorarni);
                session.Flush();
                session.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void IzmeniHonorarnogNastavnika(HonorarniBasic noviHonorarni, int honorarniId)
        {
            try
            {
                ISession session = DataLayer.GetSession();
                Honorarni honorarni = session.Load<Honorarni>(honorarniId);
                honorarni.BrojCasovaMesecno = noviHonorarni.BrojCasovaMesecno;
                honorarni.BrojUgovora = noviHonorarni.BrojUgovora;
                honorarni.TrajanjeUgovora = noviHonorarni.TrajanjeUgovora;
                session.Update(honorarni);
                session.Flush();
                session.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Stalni
        public static List<StalniDTO> PrikaziSveStalneNastavnike()
        {
            List<StalniDTO> stalniNastavnci = new List<StalniDTO>();
            try
            {
                ISession session = DataLayer.GetSession();
                stalniNastavnci = session.Query<Stalni>().Select(s => new StalniDTO(
                     s.Nastavnik.Osoba.JMBG,
                    s.Nastavnik.Osoba.Ime,
                    s.Nastavnik.Osoba.Prezime,
                    s.Nastavnik.Osoba.Adresa,
                    s.Nastavnik.Osoba.Mail,
                    string.Join(", ", s.Nastavnik.Osoba.Telefoni.Select(t => t.BrojTelefona)),
                    s.Nastavnik.Id,
                    s.Nastavnik.StrucnaSprema,
                    s.Nastavnik.DatumZaposlenja.Date,
                     s.RadnoVreme, 
                     s.StatusMentora
                    )).ToList();
                session.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return stalniNastavnci;
        }

        public static void SacuvajStalnog(StalniBasic noviStalni, int nastavnikId, string mentorJMBG)
        {
            try
            {
                ISession session = DataLayer.GetSession();
                Osoba mentor = session.Query<Osoba>().FirstOrDefault(o => o.JMBG == mentorJMBG);
                if (!string.IsNullOrEmpty(mentorJMBG) && mentor == null)
                {
                    throw new Exception("Mentor sa tim JMBG-om ne postoji");
                }
                Stalni stalni = new Stalni()
                {
                    RadnoVreme = noviStalni.RadnoVreme,
                    StatusMentora = noviStalni.StatusMentora,
                    Mentor = mentor,
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

        public static void IzmeniStalnog(StalniBasic noviStalni, int stalniId, string mentorJMBG)
        {
            try
            {
                ISession session = DataLayer.GetSession();
                Osoba mentor = session.Query<Osoba>().FirstOrDefault(o => o.JMBG == mentorJMBG);
                if (!string.IsNullOrEmpty(mentorJMBG) && mentor == null)
                {
                    throw new Exception("Mentor sa tim JMBG-om ne postoji");
                }
                Stalni stalni = session.Load<Stalni>(stalniId);
                stalni.RadnoVreme = noviStalni.RadnoVreme;
                stalni.StatusMentora = noviStalni.StatusMentora;
                stalni.Mentor = mentor;
                session.Update(stalni);
                session.Flush();
                session.Close();
            }
            catch (Exception ex)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Greška prilikom čuvanja osobe:");
                sb.AppendLine();

                int level = 0;
                Exception currentEx = ex;
                while (currentEx != null)
                {
                    sb.AppendLine($"[Nivo {level}] {currentEx.GetType().FullName}");
                    sb.AppendLine($"Poruka: {currentEx.Message}");
                    sb.AppendLine("StackTrace:");
                    sb.AppendLine(currentEx.StackTrace);
                    sb.AppendLine(new string('-', 40));

                    currentEx = currentEx.InnerException;
                    level++;
                }

                MessageBox.Show(sb.ToString(), "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static Stalni NadjiStalnog(int nastavnikId)
        {
            Stalni stalni = null;
            try
            {
                ISession session = DataLayer.GetSession();
                stalni = session.Query<Stalni>().FirstOrDefault(h => h.Nastavnik.Id == nastavnikId);
                session.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return stalni;
        }

        public static void ObrisiStalnogNastavnika(int stalniId)
        {
            try
            {
                ISession session = DataLayer.GetSession();
                Stalni stalni = session.Load<Stalni>(stalniId);
                if (stalni != null)
                    session.Delete(stalni);
                session.Flush();
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

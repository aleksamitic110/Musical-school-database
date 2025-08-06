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

        public static List<NastavnikDTO> PrikaziMentora(int nastavnikId)
        {
            List<NastavnikDTO> nastavnikMentor = new List<NastavnikDTO>();
            try
            {
                ISession session = DataLayer.GetSession();
                Stalni stalniNastavnik = session.Query<Stalni>().FirstOrDefault(s => s.Nastavnik.Id == nastavnikId);
                if(stalniNastavnik.Mentor == null)
                {
                    throw new Exception("Nastavnik nema mentora");
                }
                Osoba mentor = stalniNastavnik.Mentor;
                nastavnikMentor.Add(new NastavnikDTO
                {
                    JMBG = mentor.JMBG,
                    Ime = mentor.Ime,
                    Prezime = mentor.Prezime,
                    Adresa = mentor.Adresa,
                    Mail = mentor.Mail,
                    Telefoni = string.Join(", ", mentor.Telefoni.Select(t => t.BrojTelefona)),
                    DatumZaposlenja = stalniNastavnik.Nastavnik.DatumZaposlenja,
                    StrucnaSprema = stalniNastavnik.Nastavnik.StrucnaSprema
                });
                session.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return nastavnikMentor;
        }

        public static List<NastavnikDTO> PrikaziKomeJeMentor(string nastavnikJMBG)
        {
            List<NastavnikDTO> nastavniciKomeJeMentor = new List<NastavnikDTO>();
            try
            {
                ISession session = DataLayer.GetSession();
                List<Stalni> mentirani = session.Query<Stalni>()
                    .Where(s => s.Mentor.JMBG == nastavnikJMBG)
                    .ToList();
                if (!mentirani.Any())
                {
                    throw new Exception("Nastavnik nije mentor");
                }
                    foreach (var m in mentirani)
                {
                    var o = m.Nastavnik.Osoba;

                    nastavniciKomeJeMentor.Add(new NastavnikDTO
                    {
                        JMBG = o.JMBG,
                        Ime = o.Ime,
                        Prezime = o.Prezime,
                        Adresa = o.Adresa,
                        Mail = o.Mail,
                        Telefoni = string.Join(", ", o.Telefoni.Select(t => t.BrojTelefona)),
                        DatumZaposlenja = m.Nastavnik.DatumZaposlenja,
                        StrucnaSprema = m.Nastavnik.StrucnaSprema
                    });
                }
                session.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return nastavniciKomeJeMentor;
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
                {
                    var stalniKojimaJeMentor = session.Query<Stalni>()
                        .Where(s => s.Mentor.JMBG == nastavnik.Osoba.JMBG)
                        .ToList();
                    foreach (var s in stalniKojimaJeMentor)
                    {
                        s.Mentor = null;
                        session.Update(s);
                    }
                    session.Delete(stalni);
                }

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

        public static List<NastavnikIspitDto> PrikaziNadgledaneIspite(int nastavnikId)
        {
            List<NastavnikIspitDto> nadgledaniIspiti = new List<NastavnikIspitDto>();
            try
            {
                ISession session = DataLayer.GetSession();
                Nastavnik nastavnik = session.Load<Nastavnik>(nastavnikId);
                List<Ispit> ispiti = session.Query<Komisija>()
                 .Where(k => k.Nastavnik == nastavnik)
                 .Select(k => k.Ispit)
                 .ToList();
                foreach (Ispit isp in ispiti)
                {

                    nadgledaniIspiti.Add(new NastavnikIspitDto(isp.Id, isp.Kurs.Naziv, isp.Datum));
                }
                session.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška prilikom brisanja: " + ex.Message);
            }
            return nadgledaniIspiti;
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

        public static List<NastavnikKursDto> UcitajKurseveKojeNastavnikDrzi(int nastavnikId)
        {
            List<NastavnikKursDto> kursevi = new List<NastavnikKursDto>();
            try
            {
                ISession session = DataLayer.GetSession();
                var nastavnik = session.Load<Nastavnik>(nastavnikId);
                foreach (var kurs in nastavnik.Kursevi)
                {
                    kursevi.Add(new NastavnikKursDto(kurs.Id, kurs.Naziv, kurs.Nivo, kurs.TipNastave, kurs.Filijala.Adresa, kurs.Filijala.RadnoVreme));
                }
                session.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška prilikom brisanja: " + ex.Message);
            }
            return kursevi;
        }

        public static List<NastavnikPolaznikDto> PolazniciKojiSuPolozili(string kursId)
        {
            List<NastavnikPolaznikDto> polaznici = new List<NastavnikPolaznikDto>();
            try
            {
                ISession session = DataLayer.GetSession();
                List<Osoba> polozili = session.Query<Polaganje>()
                 .Where(p => p.Ispit.Kurs.Id == kursId && p.Polozio == true)
                 .Select(p => p.Polaznik.Osoba)
                 .ToList();
                
                foreach (var polaznik in polozili)
                {
                    polaznici.Add(new NastavnikPolaznikDto(polaznik.JMBG, polaznik.Ime, polaznik.Prezime, polaznik.Adresa, polaznik.Mail,
                        string.Join(",", polaznik.Telefoni.Select(t => t.BrojTelefona))
                       ));
                }
                session.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška prilikom brisanja: " + ex.Message);
            }
            return polaznici;
        }

        public static List<NastavnikIspitDto> IspitiKojiPredstoje(string kursId)
        {
            List<NastavnikIspitDto> ispiti = new List<NastavnikIspitDto>();
            try
            {
                ISession session = DataLayer.GetSession();
                List<Ispit> predstojeci = session.Query<Ispit>().Where(i => i.Kurs.Id == kursId && i.Datum > DateTime.Now).ToList();

                foreach (var isp in predstojeci)
                {
                    ispiti.Add(new NastavnikIspitDto(isp.Id, isp.Kurs.Naziv, isp.Datum));
                }
                session.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška prilikom brisanja: " + ex.Message);
            }
            return ispiti;
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

        public static bool SacuvajHonorarnogNastavnika(HonorarniBasic noviHonorarni, OsobaBasic novaOsoba, NastavnikBasic noviNastavnik)
        {
            try
            {
                ISession session = DataLayer.GetSession();
                Osoba osobaUBazi = session.Query<Osoba>().FirstOrDefault(o => o.JMBG == novaOsoba.JMBG);
                if (osobaUBazi != null)
                {
                    throw new Exception("Osoba sa tim JMBG-om vec postoji");
                }
                Osoba osoba = new Osoba
                {
                    Adresa = novaOsoba.Adresa,
                    Ime = novaOsoba.Ime,
                    JMBG = novaOsoba.JMBG,
                    Mail = novaOsoba.Mail,
                    Prezime = novaOsoba.Prezime,
                };
                foreach (var item in novaOsoba.Telefoni)
                {
                    var telefon = new Telefon { BrojTelefona = item.BrojTelefona, Osoba = osoba };
                    osoba.Telefoni.Add(telefon);
                }
                Nastavnik nastavnik = new Nastavnik
                {
                    DatumZaposlenja = noviNastavnik.DatumZaposlenja,
                    StrucnaSprema = noviNastavnik.StrucnaSprema,
                    Osoba = osoba,
                };
                Honorarni honorarni = new Honorarni
                {
                    BrojCasovaMesecno = noviHonorarni.BrojCasovaMesecno,
                    BrojUgovora = noviHonorarni.BrojUgovora,
                    TrajanjeUgovora = noviHonorarni.TrajanjeUgovora,
                    Nastavnik = nastavnik,
                };
                session.Save(osoba);
                session.Save(nastavnik);
                session.Save(honorarni);

                session.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
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

        public static bool IzmeniHonorarnogNastavnika(HonorarniBasic noviHonorarni, int honorarniId, OsobaBasic novaOsoba, NastavnikBasic noviNastavnik, int nastavnikId)
        {
            try
            {
                ISession session = DataLayer.GetSession();
                Osoba osoba = session.Load<Osoba>(novaOsoba.JMBG);
                Nastavnik nastavnik = session.Load<Nastavnik>(nastavnikId);
                Honorarni honorarni = session.Load<Honorarni>(honorarniId);

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

                nastavnik.StrucnaSprema = noviNastavnik.StrucnaSprema;
                nastavnik.DatumZaposlenja = noviNastavnik.DatumZaposlenja;

                honorarni.BrojCasovaMesecno = noviHonorarni.BrojCasovaMesecno;
                honorarni.BrojUgovora = noviHonorarni.BrojUgovora;
                honorarni.TrajanjeUgovora = noviHonorarni.TrajanjeUgovora;

                session.Update(osoba);
                session.Update(nastavnik);
                session.Update(honorarni);
                session.Flush();
                session.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
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

        public static bool SacuvajStalnog(StalniBasic noviStalni, string mentorJMBG, OsobaBasic novaOsoba, NastavnikBasic noviNastavnik)
        {
            try
            {
                ISession session = DataLayer.GetSession();
                Osoba osobaUBazi = session.Query<Osoba>().FirstOrDefault(o => o.JMBG == novaOsoba.JMBG);
                Stalni mentor = session.Query<Stalni>().FirstOrDefault(s => s.Nastavnik.Osoba.JMBG == mentorJMBG);
                if (osobaUBazi != null)
                {
                    throw new Exception("Osoba sa tim JMBG-om vec postoji");
                }
                if (!string.IsNullOrEmpty(mentorJMBG) && mentor == null)
                {
                    throw new Exception("Mentor sa tim JMBG-om ne postoji");
                }
                Osoba osoba = new Osoba
                {
                    Adresa = novaOsoba.Adresa,
                    Ime = novaOsoba.Ime,
                    JMBG = novaOsoba.JMBG,
                    Mail = novaOsoba.Mail,
                    Prezime = novaOsoba.Prezime,
                };
                foreach (var item in novaOsoba.Telefoni)
                {
                    var telefon = new Telefon { BrojTelefona = item.BrojTelefona, Osoba = osoba };
                    osoba.Telefoni.Add(telefon);
                }
                Nastavnik nastavnik = new Nastavnik
                {
                    DatumZaposlenja = noviNastavnik.DatumZaposlenja,
                    StrucnaSprema = noviNastavnik.StrucnaSprema,
                    Osoba = osoba,
                };
                Stalni stalni = new Stalni()
                {
                    RadnoVreme = noviStalni.RadnoVreme,
                    Mentor = mentor?.Nastavnik.Osoba,
                    Nastavnik = nastavnik,
                };
                session.Save(osoba);
                session.Save(nastavnik);
                session.Save(stalni);
                session.Flush();
                session.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }

        public static bool IzmeniStalnog(StalniBasic noviStalni, int stalniId, string mentorJMBG, OsobaBasic novaOsoba, NastavnikBasic noviNastavnik, int nastavnikId)
        {
            try
            {
                ISession session = DataLayer.GetSession();
                Osoba osoba = session.Load<Osoba>(novaOsoba.JMBG);
                Stalni mentor = session.Query<Stalni>().FirstOrDefault(s => s.Nastavnik.Osoba.JMBG == mentorJMBG);
                Nastavnik nastavnik = session.Load<Nastavnik>(nastavnikId);
                Stalni stalni = session.Load<Stalni>(stalniId);
                if (!string.IsNullOrEmpty(mentorJMBG) && mentor == null)
                {
                    throw new Exception("Mentor sa tim JMBG-om ne postoji");
                }

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

                nastavnik.StrucnaSprema = noviNastavnik.StrucnaSprema;
                nastavnik.DatumZaposlenja = noviNastavnik.DatumZaposlenja;

                stalni.RadnoVreme = noviStalni.RadnoVreme;
                stalni.Mentor = mentor?.Nastavnik.Osoba;
                session.Update(osoba);
                session.Update(nastavnik);
                session.Update(stalni);
                session.Flush();
                session.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }

        public static void IzmeniStatusMentora()
        {
            try
            {
                ISession session = DataLayer.GetSession();
                var sviStalni = session.Query<Stalni>().ToList();

                var mentori = sviStalni
                    .Where(s => s.Mentor != null)
                    .Select(s => s.Mentor.JMBG)
                    .Distinct()
                    .ToList();

                foreach (var nastavnik in sviStalni)
                {
                    if (mentori.Contains(nastavnik.Nastavnik.Osoba.JMBG))
                    {
                        nastavnik.StatusMentora = true;
                    }
                    else
                    {
                        nastavnik.StatusMentora = false;
                    }
                    session.Update(nastavnik);
                }
                session.Flush();
                session.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

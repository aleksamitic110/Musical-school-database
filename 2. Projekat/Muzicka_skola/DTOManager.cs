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
        public static List<FilijalaDTO> vratiSveFilijale()
        {
            List<FilijalaDTO> filijale = new List<FilijalaDTO>();
            try
            {
                ISession session = DataLayer.GetSession();

                filijale = session.Query<Filijala>().Select(f => new FilijalaDTO(
                    f.Id,
                    f.Adresa,
                    f.RadnoVreme,
                    f.OpremljenostUcionica,
                    f.KapacitetFilijale
                )).ToList();

                session.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return filijale;
        }

        public static Filijala nadjiFilijalu(string fId)
        {
            Filijala f = new Filijala();
            try
            {
                ISession session = DataLayer.GetSession();
                f = session.Query<Filijala>().FirstOrDefault(k => k.Id == fId);
                session.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                f = null;
            }

            return f;
        }
        public static FilijalaDTO nadjiFilijaluDTO(string fId)
        {
            Filijala f = nadjiFilijalu(fId);
            FilijalaDTO fDTO = new FilijalaDTO(
                f.Id,f.Adresa,f.RadnoVreme,f.OpremljenostUcionica,f.KapacitetFilijale);
            return fDTO;
        }
        #endregion

        #region Ucionica
        public static Ucionica nadjiUcionicu(string uId)
        {
            Ucionica u = new Ucionica();
            try
            {
                ISession session = DataLayer.GetSession();
                u = session.Query<Ucionica>().FirstOrDefault(k => k.Id == uId);
                session.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                u = null;
            }
            return u;
        }

        public static List<UcionicaDTO> vratiSveUcionice()
        {
            List<UcionicaDTO> ucionice = new List<UcionicaDTO>();
            try
            {
                ISession session = DataLayer.GetSession();

                ucionice = session.Query<Ucionica>().Select(k => new UcionicaDTO(
                    k.Id, k.Oznaka, k.KapacitetUcionice, k.Filijala.Id
                )).ToList();

                session.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return ucionice;
        }
        #endregion

        #region Kurs
        public static List<KursDTO> vratiSveKurseve()
        {
            List<KursDTO> kursevi = new List<KursDTO>();
            try
            {
                ISession session = DataLayer.GetSession();

                kursevi = session.Query<Kurs>().Select(k => new KursDTO(
                    k.Id,
                    k.Naziv,
                    k.Nivo,
                    k.TipNastave,
                    k.Filijala.Id,
                    k.Nastavnik.Id
                )).ToList();

                session.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return kursevi;
        }

        public static Kurs nadjiKurs(string idKurs) 
        {
            Kurs kursD = new Kurs();
            try
            {
                ISession session = DataLayer.GetSession();
                kursD = session.Query<Kurs>().FirstOrDefault(k => k.Id == idKurs);
                session.Close();
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                kursD = null;
            }

            return kursD;
        }

        public static void updateKurs(KursDTO k)
        {
            try
            {
                ISession session = DataLayer.GetSession();
                var kurs = session.Get<Kurs>(k.Id);
                if (kurs == null)
                {
                    MessageBox.Show("Kurs not found!");
                    return;
                }

                // Update common fields
                kurs.Naziv = k.Naziv;
                kurs.Nivo = k.Nivo;
                kurs.TipNastave = k.TipNastave;
                kurs.Filijala = nadjiFilijalu(k.Filijala);
                kurs.Nastavnik = nadjiNastavnika(k.Nastavnik);

                // Update subtype-specific fields
                switch (kurs)
                {
                    case KursInstrumentalni ki when k is KursInstrumentalniDTO dtoI:
                        ki.Instrumenti = dtoI.Instrumenti;
                        break;
                    case KursTeorijski kt when k is KursTeorijskiDTO dtoT:
                        kt.NazivPredmeta = dtoT.NazivPredmeta;
                        break;
                    case KursVokalni kv when k is KursVokalniDTO dtoV:
                        kv.TipPevanja = dtoV.TipPevanja;
                        break;
                }
                session.Update(kurs);
                session.Flush();
                session.Close();
                MessageBox.Show("Uspesno!");
            }
            catch (Exception ex)
            {
                string errorMessage = "Došlo je do greške:\n\n";

                // Glavna poruka
                errorMessage += "Exception: " + ex.Message + "\n";

                // Ako postoji inner exception, idi rekurzivno kroz sve unutrašnje
                Exception inner = ex.InnerException;
                while (inner != null)
                {
                    errorMessage += "\nInner Exception: " + inner.Message + "\n";
                    inner = inner.InnerException;
                }

                // Ako želiš i stack trace za debug
                errorMessage += "\nStackTrace:\n" + ex.StackTrace;

                MessageBox.Show(errorMessage, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void addKurs(KursDTO k)
        {
            try
            {
                ISession session = DataLayer.GetSession();
                Nastavnik n = nadjiNastavnika(k.Nastavnik);
                Kurs kurs;

                switch (k)
                {
                    case KursInstrumentalniDTO dto:
                        kurs = new KursInstrumentalni
                        {
                            Id = dto.Id,
                            Naziv = dto.Naziv,
                            Nivo = dto.Nivo,
                            TipNastave = dto.TipNastave,
                            Filijala = nadjiFilijalu(dto.Filijala),
                            Nastavnik = n,
                            Instrumenti = dto.Instrumenti
                        };
                        break;

                    case KursTeorijskiDTO dto:
                        kurs = new KursTeorijski
                        {
                            Id = dto.Id,
                            Naziv = dto.Naziv,
                            Nivo = dto.Nivo,
                            TipNastave = dto.TipNastave,
                            Filijala = nadjiFilijalu(dto.Filijala),
                            Nastavnik = n,
                            NazivPredmeta = dto.NazivPredmeta
                        };
                        break;

                    case KursVokalniDTO dto:
                        kurs = new KursVokalni
                        {
                            Id = dto.Id,
                            Naziv = dto.Naziv,
                            Nivo = dto.Nivo,
                            TipNastave = dto.TipNastave,
                            Filijala = nadjiFilijalu(dto.Filijala),
                            Nastavnik = n,
                            TipPevanja = dto.TipPevanja
                        };
                        break;

                    default:
                        kurs = new Kurs
                        {
                            Id = k.Id,
                            Naziv = k.Naziv,
                            Nivo = k.Nivo,
                            TipNastave = k.TipNastave,
                            Filijala = nadjiFilijalu(k.Filijala),
                            Nastavnik = n
                        };
                        break;
                }

                session.Save(kurs);
                session.Flush();
                session.Close();
                MessageBox.Show("Uspesno!");
            }
            catch (Exception ex)
            {
                string errorMessage = "Došlo je do greške:\n\n";

                // Glavna poruka
                errorMessage += "Exception: " + ex.Message + "\n";

                // Ako postoji inner exception, idi rekurzivno kroz sve unutrašnje
                Exception inner = ex.InnerException;
                while (inner != null)
                {
                    errorMessage += "\nInner Exception: " + inner.Message + "\n";
                    inner = inner.InnerException;
                }

                // Ako želiš i stack trace za debug
                errorMessage += "\nStackTrace:\n" + ex.StackTrace;

                MessageBox.Show(errorMessage, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void obrisiKurs(string idKurs)
        {
            try { 
            ISession session = DataLayer.GetSession();
            var kurs = session.Load<Kurs>(idKurs);
            KursTeorijski kursT = session.Query<KursTeorijski>().FirstOrDefault(k => k.Id == idKurs);
            KursInstrumentalni kursI = session.Query<KursInstrumentalni>().FirstOrDefault(k => k.Id == idKurs);
            KursVokalni kursV = session.Query<KursVokalni>().FirstOrDefault(k => k.Id == idKurs);

            if (kursI !=null)
                session.Delete(kursI);

            
            if (kursV != null)
                session.Delete(kursV);

            
            if (kursT != null)
                session.Delete(kursT);



            MessageBox.Show("Kurs je izbrisan.");
            session.Flush();
            session.Close();
            }
            catch (Exception ex)
            {
                string errorMessage = "Došlo je do greške:\n\n";

                // Glavna poruka
                errorMessage += "Exception: " + ex.Message + "\n";

                // Ako postoji inner exception, idi rekurzivno kroz sve unutrašnje
                Exception inner = ex.InnerException;
                while (inner != null)
                {
                    errorMessage += "\nInner Exception: " + inner.Message + "\n";
                    inner = inner.InnerException;
                }

                // Ako želiš i stack trace za debug
                errorMessage += "\nStackTrace:\n" + ex.StackTrace;

                MessageBox.Show(errorMessage, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static List<KursDTO> vratiKursPoFilijali(string filijalaId)
        {
            List<KursDTO> kursevi = new List<KursDTO>();
            try
            {
                ISession session = DataLayer.GetSession();

                kursevi = session.Query<Kurs>()
                    .Where(k => k.Filijala.Id == filijalaId)
                    .Select(k => new KursDTO(
                        k.Id,
                        k.Naziv,
                        k.Nivo,
                        k.TipNastave,
                        k.Filijala.Id,
                        k.Nastavnik.Id
                    ))
                    .ToList();

                session.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return kursevi;
        }

        public static List<PolaznikDTO> nadjiPolaznikeZaKursDTO(string kursId)
        {
            using (ISession session = DataLayer.GetSession())
            {
                var polaznici = session.Query<Pohadja>()
                                       .Where(p => p.Kurs.Id == kursId)
                                       .Select(p => new PolaznikDTO(
                                           p.Polaznik.Id,
                                           p.Polaznik.Osoba.JMBG,
                                           p.Polaznik.Osoba.Ime,
                                           p.Polaznik.Osoba.Prezime,
                                           p.Polaznik.Osoba.Adresa,
                                           p.Polaznik.Osoba.Mail,
                                           string.Join(", ", p.Polaznik.Osoba.Telefoni.Select(t => t.BrojTelefona))
                                        )).ToList();
                                      
                return polaznici;
            }
        }


        #endregion

        #region KursInstrumentalni
        public static List<KursInstrumentalniDTO> vratiInstrumentalni()
        {
            List<KursInstrumentalniDTO> kursevi = new List<KursInstrumentalniDTO>();
            try
            {
                ISession session = DataLayer.GetSession();

                kursevi = session.Query<KursInstrumentalni>().Select(k => new KursInstrumentalniDTO(
                    k.Id,
                    k.Naziv,
                    k.Nivo,
                    k.TipNastave,
                    k.Filijala.Id,
                    k.Nastavnik.Id,
                    k.Instrumenti
                )).ToList();

                session.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return kursevi;
        }

        public static KursInstrumentalni nadjiKursI(string idKurs)
        {
            try
            {
                ISession session = DataLayer.GetSession();
                KursInstrumentalni kursD = session.Query<KursInstrumentalni>()
                                             .FirstOrDefault(k => k.Id == idKurs);

                // If kursD is null, it was not found
                return kursD;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        #endregion

        #region KursVokalni
        public static List<KursVokalniDTO> vratiVokalni()
        {
            List<KursVokalniDTO> kursevi = new List<KursVokalniDTO>();
            try
            {
                ISession session = DataLayer.GetSession();

                kursevi = session.Query<KursVokalni>().Select(k => new KursVokalniDTO(
                    k.Id,
                    k.Naziv,
                    k.Nivo,
                    k.TipNastave,
                    k.Filijala.Id,
                    k.Nastavnik.Id,
                    k.TipPevanja
                )).ToList();

                session.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return kursevi;
        }

        public static KursVokalni nadjiKursV(string idKurs)
        {
            try
            {
                ISession session = DataLayer.GetSession();
                KursVokalni kursD = session.Query<KursVokalni>()
                                             .FirstOrDefault(k => k.Id == idKurs);

                // If kursD is null, it was not found
                return kursD;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        #endregion

        #region KursTeorijski
        public static List<KursTeorijskiDTO> vratiTeorijski()
        {
            List<KursTeorijskiDTO> kursevi = new List<KursTeorijskiDTO>();
            try
            {
                ISession session = DataLayer.GetSession();

                kursevi = session.Query<KursTeorijski>().Select(k => new KursTeorijskiDTO(
                    k.Id,
                    k.Naziv,
                    k.Nivo,
                    k.TipNastave,
                    k.Filijala.Id,
                    k.Nastavnik.Id,
                    k.NazivPredmeta
                )).ToList();

                session.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return kursevi;
        }

        public static KursTeorijski nadjiKursT(string idKurs)
        {
            try
            {
                ISession session = DataLayer.GetSession();
                KursTeorijski kursD = session.Query<KursTeorijski>()
                                             .FirstOrDefault(k => k.Id == idKurs);

                // If kursD is null, it was not found
                return kursD;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        #endregion

        #region Cas
        public static List<CasDTO> vratiSveCasove()
        {
            List<CasDTO> casovi = new List<CasDTO>();
            try
            {
                ISession session = DataLayer.GetSession();

                casovi = session.Query<Cas>().Select(k => new CasDTO(
                    k.Id,k.Kurs.Id,k.Ucionica.Id,k.Datum,k.Vreme,k.Lekcija
                )).ToList();

                session.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return casovi;
        }

        public static Cas nadjiCas(string uId)
        {
            Cas c = new Cas();
            try
            {
                ISession session = DataLayer.GetSession();
                c = session.Query<Cas>().FirstOrDefault(k => k.Id == uId);
                session.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                c = null;
            }

            return c;
        }

        public static void addCas(CasDTO c)
        {
            try
            {
                ISession session = DataLayer.GetSession();
                Kurs kurs = nadjiKurs(c.IdKursa);
                Ucionica ucionica = nadjiUcionicu(c.IdUcionice);

                Cas cas = new Cas
                {
                    Id = c.IdCasa,
                    Datum = c.Datum,
                    Vreme = c.Vreme,
                    Lekcija = c.Lekcija,
                    Kurs = kurs,
                    Ucionica = ucionica
                };

                session.Save(cas);
                session.Flush();
                session.Close();
                MessageBox.Show("Uspesno!");
            }
            catch (Exception ex)
            {
                string errorMessage = "Došlo je do greške:\n\n";

                // Glavna poruka
                errorMessage += "Exception: " + ex.Message + "\n";

                // Ako postoji inner exception, idi rekurzivno kroz sve unutrašnje
                Exception inner = ex.InnerException;
                while (inner != null)
                {
                    errorMessage += "\nInner Exception: " + inner.Message + "\n";
                    inner = inner.InnerException;
                }

                // Ako želiš i stack trace za debug
                errorMessage += "\nStackTrace:\n" + ex.StackTrace;

                MessageBox.Show(errorMessage, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
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
        //cao lux ovde da ti doda pronadjiNastavnika kako bi mogo da nadjem taj objekat
        public static Nastavnik nadjiNastavnika(int nId)
        {
            Nastavnik nast = new Nastavnik();
            try
            {
                ISession session = DataLayer.GetSession();
                nast = session.Query<Nastavnik>().FirstOrDefault(k => k.Id == nId);
                session.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                nast = null;
            }

            return nast;
        }


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

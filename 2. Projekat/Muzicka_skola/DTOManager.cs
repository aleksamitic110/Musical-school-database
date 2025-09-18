using FluentNHibernate.Conventions.AcceptanceCriteria;
using FluentNHibernate.Testing.Values;
using Muzicka_skola.Entiteti;
using NHibernate;
using NHibernate.Dialect.Schema;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

		public static void ObrisiPolaznika(int polaznikId)
		{
			int? starateljIdZaProveru = null;

			// ----- DEO 1: Brisanje polaznika (Ovaj deo radi i ostaje isti) -----
			// Uspešno briše Dete, Polaznika i Osobu koja je vezana SAMO za polaznika.
			using (ISession session = DataLayer.GetSession())
			using (ITransaction transaction = session.BeginTransaction())
			{
				try
				{
					var polaznik = session.Get<Polaznik>(polaznikId);
					if (polaznik != null)
					{
						var pohadjanja = session.Query<Pohadja>().Where(p => p.Polaznik.Id == polaznikId).ToList();
						foreach (var p in pohadjanja) { session.Delete(p); }

						var polaganja = session.Query<Polaganje>().Where(p => p.Polaznik.Id == polaznikId).ToList();
						foreach (var p in polaganja) { session.Delete(p); }

						var odrasli = session.Query<Odrasli>().FirstOrDefault(o => o.Polaznik.Id == polaznikId);
						if (odrasli != null) { session.Delete(odrasli); }

						var dete = session.Query<Dete>().FirstOrDefault(d => d.Polaznik.Id == polaznikId);
						if (dete != null)
						{
							// Sačuvamo ID staratelja za proveru u drugom delu
							starateljIdZaProveru = dete.Staratelj.Id;
							session.Delete(dete);
						}

						// Brišemo polaznika
						session.Delete(polaznik);

						// Brišemo OSOBU koja je vezana za polaznika
						var osoba = polaznik.Osoba;
						if (osoba != null)
						{
							foreach (var telefon in osoba.Telefoni.ToList()) { session.Delete(telefon); }
							session.Delete(osoba);
						}

						transaction.Commit();
					}
				}
				catch (Exception ex)
				{
					transaction?.Rollback();
					string errorMessage = "Greška prilikom brisanja polaznika (Deo 1): " + ex.Message;
					if (ex.InnerException != null) { errorMessage += "\n\nInner Exception: " + ex.InnerException.Message; }
					MessageBox.Show(errorMessage);
					return;
				}
			}

			// ----- DEO 2: Čišćenje "uloge" staratelja (ISPRAVNA LOGIKA) -----
			if (starateljIdZaProveru.HasValue)
			{
				try
				{
					using (ISession session2 = DataLayer.GetSession())
					using (ITransaction transaction2 = session2.BeginTransaction())
					{
						int id = starateljIdZaProveru.Value;
						// Proveravamo da li staratelj ima još dece
						var brojPreostaleDece = session2.Query<Dete>().Count(d => d.Staratelj.Id == id);

						if (brojPreostaleDece == 0)
						{
							// Ako nema više dece, brišemo SAMO zapis iz tabele STARATELJ.
							var starateljZaBrisanje = session2.Get<Staratelj>(id);
							if (starateljZaBrisanje != null)
							{
								session2.Delete(starateljZaBrisanje);
							}
						}
						transaction2.Commit();
					}
				}
				catch (Exception ex)
				{
					string errorMessage = "Greška prilikom čišćenja uloge staratelja (Deo 2): " + ex.Message;
					if (ex.InnerException != null) { errorMessage += "\n\nInner Exception: " + ex.InnerException.Message; }
					MessageBox.Show(errorMessage);
				}
			}
		}
		public static List<KursDTO> VratiKurseveZaPolaznika(int polaznikId)
		{
			List<KursDTO> kursevi = new List<KursDTO>();
			try
			{
				using (ISession session = DataLayer.GetSession())
				{
					kursevi = session.Query<Pohadja>()
						.Where(pohadja => pohadja.Polaznik.Id == polaznikId)
						.Select(pohadja => pohadja.Kurs)

						.Select(kurs => new KursDTO
						{
							Id = kurs.Id,
							Naziv = kurs.Naziv,
							Nivo = kurs.Nivo,
							TipNastave = kurs.TipNastave,
							Filijala = kurs.Filijala.Id,
							Nastavnik = kurs.Nastavnik.Id
						})
						.ToList();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Greška prilikom vraćanja kurseva za polaznika: " + ex.Message);
			}
			return kursevi;
		}

		public static PolaznikDTO VratiDetaljePolaznika(int polaznikId)
		{
			try
			{
				using (ISession session = DataLayer.GetSession())
				{
					// Prvo proveravamo da li je polaznik Dete
					var dete = session.Query<Dete>().FirstOrDefault(d => d.Polaznik.Id == polaznikId);
					if (dete != null)
					{
						// Ako jeste, kreiramo i popunjavamo DeteDTO
						var deteDTO = new DeteDTO
						{
							Id = dete.Polaznik.Id,
							JMBG = dete.Polaznik.Osoba.JMBG,
							Ime = dete.Polaznik.Osoba.Ime,
							Prezime = dete.Polaznik.Osoba.Prezime,
							Adresa = dete.Polaznik.Osoba.Adresa,
							Mail = dete.Polaznik.Osoba.Mail,
							Telefoni = string.Join(";", dete.Polaznik.Osoba.Telefoni.Select(t => t.BrojTelefona)),

							IdDeteta = dete.Id,
							DatumRodjenja = dete.DatumRodjenja,
							BrojDosijea = dete.BrojDosijea,
							Staratelj = new StarateljDTO
							{
								Id = dete.Staratelj.Id,
								Ime = dete.Staratelj.Osoba.Ime,
								Prezime = dete.Staratelj.Osoba.Prezime
							}
						};
						return deteDTO;
					}

					// Ako nije Dete, proveravamo da li je Odrasli
					var odrasli = session.Query<Odrasli>().FirstOrDefault(o => o.Polaznik.Id == polaznikId);
					if (odrasli != null)
					{
						// Ako jeste, kreiramo i popunjavamo OdrasliDTO
						var odrasliDTO = new OdrasliDTO
						{
							Id = odrasli.Polaznik.Id,
							JMBG = odrasli.Polaznik.Osoba.JMBG,
							Ime = odrasli.Polaznik.Osoba.Ime,
							Prezime = odrasli.Polaznik.Osoba.Prezime,
							Adresa = odrasli.Polaznik.Osoba.Adresa,
							Mail = odrasli.Polaznik.Osoba.Mail,
							Telefoni = string.Join(";", odrasli.Polaznik.Osoba.Telefoni.Select(t => t.BrojTelefona)),

							Zanimanje = odrasli.Zanimanje
						};
						return odrasliDTO;
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Greška prilikom učitavanja detalja polaznika: " + ex.Message);
			}
			return null;
		}

		public static bool IzmeniPolaznika(PolaznikDTO podaci)
		{
			try
			{
				using (ISession session = DataLayer.GetSession())
				using (ITransaction transaction = session.BeginTransaction())
				{
					var polaznikIzBaze = session.Get<Polaznik>(podaci.Id);
					var osobaIzBaze = session.Get<Osoba>(podaci.JMBG);

					if (polaznikIzBaze == null || osobaIzBaze == null)
					{
						MessageBox.Show("Polaznik ili osoba nisu pronađeni u bazi.");
						return false;
					}

					osobaIzBaze.Ime = podaci.Ime;
					osobaIzBaze.Prezime = podaci.Prezime;
					osobaIzBaze.Adresa = podaci.Adresa;
					osobaIzBaze.Mail = podaci.Mail;

					osobaIzBaze.Telefoni.Clear();
					session.Flush();
					string[] noviTelefoni = podaci.Telefoni.Split(';');
					foreach (var broj in noviTelefoni)
					{
						if (!string.IsNullOrWhiteSpace(broj))
						{
							osobaIzBaze.Telefoni.Add(new Telefon { BrojTelefona = broj, Osoba = osobaIzBaze });
						}
					}

					if (podaci is DeteDTO detePodaci)
					{
						var deteIzBaze = session.Query<Dete>().FirstOrDefault(d => d.Polaznik.Id == podaci.Id);
						deteIzBaze.DatumRodjenja = detePodaci.DatumRodjenja;
						deteIzBaze.BrojDosijea = detePodaci.BrojDosijea;

						if (deteIzBaze.Staratelj.Id != detePodaci.Staratelj.Id)
						{
							deteIzBaze.Staratelj = session.Load<Staratelj>(detePodaci.Staratelj.Id);
						}
						session.Update(deteIzBaze);
					}
					else if (podaci is OdrasliDTO odrasliPodaci)
					{
						var odrasliIzBaze = session.Query<Odrasli>().FirstOrDefault(o => o.Polaznik.Id == podaci.Id);
						odrasliIzBaze.Zanimanje = odrasliPodaci.Zanimanje;
						session.Update(odrasliIzBaze);
					}

					session.Update(osobaIzBaze);
					transaction.Commit();
					return true;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Greška prilikom izmene polaznika: " + ex.Message);
				return false;
			}
		}

		#endregion

		#region Staratelj
		public static List<StarateljDTO> VratiStaratelje()
		{
			List<StarateljDTO> staratelji = new List<StarateljDTO>();

			try
			{
				ISession session = DataLayer.GetSession();

				staratelji = session.Query<Staratelj>()
					.Select(s => new StarateljDTO(
						s.Id,
						s.Deca.ToList(), // IList<Dete> → List<Dete>
						s.Osoba.JMBG,
						s.Osoba.Ime,
						s.Osoba.Prezime,
						s.Osoba.Adresa,
						s.Osoba.Mail,
						string.Join(", ", s.Osoba.Telefoni.Select(t => t.BrojTelefona))
					))
					.ToList();

				session.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

			return staratelji;
		}

		public static int SacuvajStaratelja(StarateljBasic noviStaratelj, OsobaBasic novaOsoba)
		{
			try
			{
				using (ISession session = DataLayer.GetSession())
				{
					// Provera da li osoba već postoji po JMBG
					Osoba osobaUBazi = session.Query<Osoba>().FirstOrDefault(o => o.JMBG == novaOsoba.JMBG);
					if (osobaUBazi != null)
					{
						MessageBox.Show("ERROR: Osoba sa tim JMBG-om već postoji");
						return -1;
					}

					// Kreiranje novog entiteta Osoba i popunjavanje telefona
					Osoba osoba = new Osoba
					{
						JMBG = novaOsoba.JMBG,
						Ime = novaOsoba.Ime,
						Prezime = novaOsoba.Prezime,
						Adresa = novaOsoba.Adresa,
						Mail = novaOsoba.Mail,
						Telefoni = new List<Telefon>()
					};

					foreach (var telefonBasic in novaOsoba.Telefoni)
					{
						var telefon = new Telefon
						{
							BrojTelefona = telefonBasic.BrojTelefona,
							Osoba = osoba
						};
						osoba.Telefoni.Add(telefon);
					}

					// Kreiranje staratelja i povezivanje sa osobom
					Staratelj staratelj = new Staratelj
					{
						Osoba = osoba,
						Deca = new List<Dete>()
					};

					session.Save(osoba);
					session.Save(staratelj);

					session.Flush();

					return staratelj.Id;  // vraćamo id kreiranog staratelja
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return -1;
			}
		}

		public static StarateljDTO VratiDetaljeStaratelja(int starateljId)
		{
			StarateljDTO staratelj = null;
			try
			{
				using (ISession session = DataLayer.GetSession())
				{
					staratelj = session.Query<Staratelj>()
						.Where(s => s.Id == starateljId)
						.Select(s => new StarateljDTO
						{
							Id = s.Id,
							JMBG = s.Osoba.JMBG,
							Ime = s.Osoba.Ime,
							Prezime = s.Osoba.Prezime,
							Adresa = s.Osoba.Adresa,
							Mail = s.Osoba.Mail,
							Telefoni = string.Join(";", s.Osoba.Telefoni.Select(t => t.BrojTelefona))
						})
						.FirstOrDefault();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Greška prilikom učitavanja detalja staratelja: " + ex.Message);
			}
			return staratelj;
		}

		public static bool IzmeniStaratelja(StarateljDTO podaci)
		{
			try
			{
				using (ISession session = DataLayer.GetSession())
				using (ITransaction transaction = session.BeginTransaction())
				{
					// Učitavamo Osobu koju menjamo (JMBG je ključ)
					var osobaIzBaze = session.Get<Osoba>(podaci.JMBG);

					if (osobaIzBaze == null)
					{
						MessageBox.Show("Osoba nije pronađena u bazi.");
						return false;
					}

					// Ažuriramo podatke
					osobaIzBaze.Ime = podaci.Ime;
					osobaIzBaze.Prezime = podaci.Prezime;
					osobaIzBaze.Adresa = podaci.Adresa;
					osobaIzBaze.Mail = podaci.Mail;

					// Ažuriramo telefone (brisanje starih, dodavanje novih)
					osobaIzBaze.Telefoni.Clear();
					session.Flush(); // Odmah primeni brisanje
					string[] noviTelefoni = podaci.Telefoni.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
					foreach (var broj in noviTelefoni)
					{
						osobaIzBaze.Telefoni.Add(new Telefon { BrojTelefona = broj.Trim(), Osoba = osobaIzBaze });
					}

					session.Update(osobaIzBaze);
					transaction.Commit();
					return true;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Greška prilikom izmene staratelja: " + ex.Message);
				return false;
			}
		}

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
		public static List<DeteDTO> VratiDecu()
		{
			List<DeteDTO> decaDTO = new List<DeteDTO>();
			try
			{
				using (ISession s = DataLayer.GetSession())
				{
					decaDTO = s.Query<Dete>()
								 .Select(dete => new DeteDTO
								 {
									 // Podaci o detetu kao polazniku
									 Id = dete.Polaznik.Id,
									 JMBG = dete.Polaznik.Osoba.JMBG,
									 Ime = dete.Polaznik.Osoba.Ime,
									 Prezime = dete.Polaznik.Osoba.Prezime,
									 Adresa = dete.Polaznik.Osoba.Adresa,
									 Mail = dete.Polaznik.Osoba.Mail,
									 Telefoni = string.Join(", ", dete.Polaznik.Osoba.Telefoni.Select(t => t.BrojTelefona)),

									 // Specifični podaci za Dete
									 IdDeteta = dete.Id,
									 DatumRodjenja = dete.DatumRodjenja,
									 BrojDosijea = dete.BrojDosijea,

									 // Kreiramo i popunjavamo StarateljDTO 
									 Staratelj = new StarateljDTO
									 {
										 Id = dete.Staratelj.Id,
										 Ime = dete.Staratelj.Osoba.Ime, 
										 Prezime = dete.Staratelj.Osoba.Prezime
									 }
								 }).ToList();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Greška prilikom vraćanja dece: " + ex.Message);
			}

			return decaDTO;
		}
		public static int SacuvajDete(DeteBasic novoDete, int starateljId, PolaznikBasic noviPolaznik, OsobaBasic novaOsoba)
		{
			try
			{
				using (ISession session = DataLayer.GetSession())
				{
					// Pronađi postojeći staratelj u bazi po ID-u
					Staratelj starateljUBazi = session.Get<Staratelj>(starateljId);
					if (starateljUBazi == null)
					{
						MessageBox.Show("Staratelj sa datim ID-jem ne postoji.");
						return -1;
					}

					// Provera da li osoba sa JMBG već postoji (polaznik i dete koriste Osoba)
					Osoba osobaUBazi = session.Query<Osoba>().FirstOrDefault(o => o.JMBG == novaOsoba.JMBG);
					if (osobaUBazi != null)
					{
						MessageBox.Show("Osoba sa tim JMBG-om već postoji");
						return -1;
					}

					// Kreiraj novu Osobu za dete (nasleđuje Polaznika i Osobu)
					Osoba osoba = new Osoba
					{
						JMBG = novaOsoba.JMBG,
						Ime = novaOsoba.Ime,
						Prezime = novaOsoba.Prezime,
						Adresa = novaOsoba.Adresa,
						Mail = novaOsoba.Mail,
						Telefoni = new List<Telefon>()
					};

					foreach (var telefonBasic in novaOsoba.Telefoni)
					{
						var telefon = new Telefon
						{
							BrojTelefona = telefonBasic.BrojTelefona,
							Osoba = osoba
						};
						osoba.Telefoni.Add(telefon);
					}

					// Kreiraj Polaznika i poveži sa Osobom
					Polaznik polaznik = new Polaznik
					{
						Osoba = osoba
					};

					// Kreiraj Dete i poveži sa Polaznikom i Starateljem
					Dete dete = new Dete
					{
						DatumRodjenja = novoDete.DatumRodjenja,
						BrojDosijea = novoDete.BrojDosijea,
						Polaznik = polaznik,
						Staratelj = starateljUBazi
					};

					session.Save(osoba);
					session.Save(polaznik);
					session.Save(dete);

					session.Flush();

					return dete.Id;  // vraćamo id kreiranog deteta
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return -1;
			}
		}
		public static List<DeteDTO> VratiDecuStaratelja(int starateljId)
		{
			List<DeteDTO> decaStaratelja = new List<DeteDTO>();
			try
			{
				using (ISession session = DataLayer.GetSession())
				{
					decaStaratelja = session.Query<Dete>()
						// 1. Filtriramo decu da pripadaju samo staratelju sa datim ID-jem
						.Where(dete => dete.Staratelj.Id == starateljId)

						// 2. Popunjavamo DeteDTO na isti način kao u VratiDecu metodi
						.Select(dete => new DeteDTO
						{
							// Podaci o detetu
							Id = dete.Polaznik.Id,
							JMBG = dete.Polaznik.Osoba.JMBG,
							Ime = dete.Polaznik.Osoba.Ime,
							Prezime = dete.Polaznik.Osoba.Prezime,
							Adresa = dete.Polaznik.Osoba.Adresa,
							Mail = dete.Polaznik.Osoba.Mail,
							Telefoni = string.Join(", ", dete.Polaznik.Osoba.Telefoni.Select(t => t.BrojTelefona)),
							IdDeteta = dete.Id,
							DatumRodjenja = dete.DatumRodjenja,
							BrojDosijea = dete.BrojDosijea,

							// ---> KLJUČNA IZMENA: Dodajemo i podatke o staratelju <---
							// Iako je to uvek isti staratelj, popunjavamo objekat
							// da bi prikaz u tabeli bio isti kao na glavnom ekranu.
							Staratelj = new StarateljDTO
							{
								Id = dete.Staratelj.Id,
								Ime = dete.Staratelj.Osoba.Ime,
								Prezime = dete.Staratelj.Osoba.Prezime
							}
						})
						.ToList();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

			return decaStaratelja;
		}
		#endregion

		#region Odrasli
		public static List<OdrasliDTO> PrikaziOdrasle()
		{
			List<OdrasliDTO> odrasliPolaznici = new List<OdrasliDTO>();
			try
			{
				ISession session = DataLayer.GetSession();
				odrasliPolaznici = session.Query<Odrasli>().Select(h => new OdrasliDTO(
					h.Zanimanje,
					h.Polaznik.Id,
					h.Polaznik.Osoba.JMBG,
					h.Polaznik.Osoba.Ime,
					h.Polaznik.Osoba.Prezime,
					h.Polaznik.Osoba.Adresa,
					h.Polaznik.Osoba.Mail,
					string.Join(", ", h.Polaznik.Osoba.Telefoni.Select(t => t.BrojTelefona))
					)).ToList();
				session.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			return odrasliPolaznici;
		}
		/*
        public static List<OdrasliDTO> PrikaziDecu()
		{
			List<DeteDTO> odrasliPolaznici = new List<DeteDTO>();
			try
			{
				ISession session = DataLayer.GetSession();
				odrasliPolaznici = session.Query<Dete>().Select(h => new DeteDTO(
					h.Polaznik.Id,
					h.Polaznik.Osoba.JMBG,
					h.Polaznik.Osoba.Ime,
					h.Polaznik.Osoba.Prezime,
					h.Polaznik.Osoba.Adresa,
					h.Polaznik.Osoba.Mail,
					string.Join(", ", h.Polaznik.Osoba.Telefoni.Select(t => t.BrojTelefona))

					)).ToList();
				session.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			return odrasliPolaznici;
		}
        */
		public static bool SacuvajOdraslogPolaznika(OdrasliBasic noviOdrasli, OsobaBasic novaOsoba, PolaznikBasic noviPolaznik)
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
				Polaznik polaznik = new Polaznik
				{
					Osoba = osoba
				};
				Odrasli odrasli = new Odrasli
				{
					Polaznik = polaznik,
					Zanimanje = noviOdrasli.Zanimanje
				};
				session.Save(osoba);
				session.Save(polaznik);
				session.Save(odrasli);

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

		#region Pohadja

		#endregion

        #region Polaganje
        public static List<PolaganjeDTO> VratiPolaznikeKojiSuPolagaliIspit(string ispitId)
        {
            List<PolaganjeDTO> polaznici = new List<PolaganjeDTO>();
            try
            {
                ISession session = DataLayer.GetSession();
                polaznici = session.Query<Polaganje>().Where(po => po.Ispit.Id == ispitId && po.Ocena == 0).Select(po => new PolaganjeDTO(po.Id,po.Polaznik.Osoba.JMBG, po.Polaznik.Osoba.Ime, po.Polaznik.Osoba.Prezime, po.Ispit.Kurs.Naziv, po.Ispit.Datum, po.Ocena, po.Polozio )).ToList();
                session.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return polaznici;
        }

        public static bool OceniPolaganjePolaznika(int polaganjeId, bool polozio, int ocena) {
            
            try
            {
                ISession session = DataLayer.GetSession();
                var polaganje = session.Load<Polaganje>(polaganjeId);
                if(polaganje == null)
                {
                    return false;
                }
                polaganje.Polozio = polozio;
                polaganje.Ocena = ocena;
                session.Update(polaganje);
                session.Flush();
                session.Close();
                return true;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            return false;
        }

        public static bool DodajPolaganje(List<int> polaznikIds, string ispitId)
        {

            try
            {
                ISession session = DataLayer.GetSession();
                Ispit ispit = session.Load<Ispit>(ispitId);
                if (ispit == null)
                {
                    return false;
                }
                foreach (int polaznikId in polaznikIds)
                {
                    Polaznik pol = session.Load<Polaznik>(polaznikId);
                    Polaganje polaganje = new Polaganje
                    {
                        Polaznik = pol,
                        Ispit = ispit
                    };
                    ispit.Polaganja.Add(polaganje);
                }
                session.Update(ispit);
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

		#region Telefon

		#endregion

        #region Komisija
        public static List<NastavnikDTO> VratiKomisiju(string ispitId)
        {
            List<NastavnikDTO> nastavnici = new List<NastavnikDTO>();
            try
            {
                ISession session = DataLayer.GetSession();
                var ispit = session.Get<Ispit>(ispitId);
                if (ispit != null)
                {
                    nastavnici = ispit.Komisija
                                      .Select(k => new NastavnikDTO(k.Nastavnik.Osoba.JMBG, k.Nastavnik.Osoba.Ime, k.Nastavnik.Osoba.Prezime, k.Nastavnik.Osoba.Adresa, k.Nastavnik.Osoba.Mail, string.Join(",", k.Nastavnik.Osoba.Telefoni.Select(t => t.BrojTelefona)), k.Nastavnik.Id, k.Nastavnik.StrucnaSprema, k.Nastavnik.DatumZaposlenja))
                                      .ToList();
                }
                session.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return nastavnici;
        }
        #endregion

		#region Ispit

        public static List<IspitDTO> PrikaziSveIspite()
        {
            List<IspitDTO> ispiti = new List<IspitDTO>();
            try
            {
                ISession session = DataLayer.GetSession();
                ispiti = session.Query<Ispit>().Select(isp => new IspitDTO(isp.Id, 
                    isp.Kurs.Id, 
                    isp.Kurs.Naziv, 
                    isp.Datum, 
                    string.Join(",", isp.Komisija.Select(k => k.Nastavnik.Osoba.Ime).ToList()))).ToList();
                session.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ispiti;
        }

        public static List<IspitDTO> PrikaziIspitePoProsecnojOceni() {
            List<IspitDTO> ispiti = new List<IspitDTO>();
            try
            {
                ISession session = DataLayer.GetSession();
                ispiti = session.Query<Ispit>()
                    .ToList()
                    .Select(isp => new IspitDTO(
                    isp.Id,
                    isp.Kurs.Id,
                    isp.Kurs.Naziv,
                    isp.Datum,
                    string.Join(",", isp.Komisija.Select(k => k.Nastavnik.Osoba.Ime).ToList()),
                    isp.Polaganja.Where(p => p.Polozio).Any()
                    ? isp.Polaganja.Where(p => p.Polozio).Average(p => p.Ocena)
                    : 0
                    ))
                    .ToList();
                session.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ispiti;
        }

        public static bool DodajIspit(IspitBasic noviIspit,string kursId)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                var kurs = session.Load<Kurs>(kursId);
                if (kurs == null)
                {
                    MessageBox.Show("Kurs nije pronađen!");
                    return false;
                }

                Ispit ispit = new Ispit
                {
                    Id = noviIspit.Id,
                    Kurs = kurs,
                    Datum = noviIspit.Datum,
                    Komisija = new List<Komisija>()
                };

                foreach (int id in noviIspit.NastavnikIds)
                {
                    var nastavnik = session.Load<Nastavnik>(id);
                    if (nastavnik != null)
                    {
                        Komisija komisija = new Komisija
                        {
                            Nastavnik = nastavnik,
                            Ispit = ispit
                        };
                        ispit.Komisija.Add(komisija);
                    }
                }

                session.Save(ispit);
                session.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }

        public static void ObrisiIspit(string ispitId)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                var ispit = session.Load<Ispit>(ispitId);
                if (ispit == null)
                {
                    MessageBox.Show("Ispit nije pronađen!");
                    return;
                }
                session.Delete(ispit);
                session.Flush();
                session.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static bool IzmeniIspit(IspitBasic noviIspit)
        {
            try
            {
                ISession session = DataLayer.GetSession();

                var ispit = session.Load<Ispit>(noviIspit.Id);
                if (ispit == null)
                    return false;

                ispit.Datum = noviIspit.Datum;

                ispit.Komisija.Clear();
                session.Update(ispit);
                session.Flush();

                foreach (int id in noviIspit.NastavnikIds)
                {
                    var nastavnik = session.Load<Nastavnik>(id);
                    if (nastavnik != null)
                    {
                        Komisija komisija = new Komisija
                        {
                            Nastavnik = nastavnik,
                            Ispit = ispit
                        };
                        ispit.Komisija.Add(komisija);
                    }
                }

                session.Update(ispit);
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

        public static List<PolaznikDTO> vratiPolaznikeKojiNePolazuIspit(string ispitId)
        {
            List<PolaznikDTO> polaznici = new List<PolaznikDTO>();
            try
            {
                ISession session = DataLayer.GetSession();
                polaznici = session.Query<Polaznik>().Where(n => !n.Polaganja.Any(p => p.Ispit.Id == ispitId)).Select(n => new PolaznikDTO(
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

	}
}

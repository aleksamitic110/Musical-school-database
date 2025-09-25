using Muzicka_skola.Entiteti;
using MuzickaSkola;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseAccess.DTOs;
using NHibernate.Linq;

namespace DatabaseAccess.DataProviders
{
    public static class NastavnikDataProvider
    {
        public static async Task<Result<List<NastavnikDTO>, ErrorMessage>> PrikaziSveNastavnike()
        {
            List<NastavnikDTO> nastavnici = new List<NastavnikDTO>();
            ISession? session = null;
            try
            {
                session = DataLayer.GetSession();
                var result = await session.Query<Nastavnik>().Fetch(n => n.Osoba).ThenFetchMany(o => o.Telefoni).ToListAsync();

      
                foreach (var nastavnik in result)
                {
                    if (!NHibernateUtil.IsInitialized(nastavnik.Osoba.Telefoni))
                    {
                        await NHibernateUtil.InitializeAsync(nastavnik.Osoba.Telefoni);
                    }
                }

                nastavnici = result.Select(n => new NastavnikDTO(
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
                return nastavnici;
            }
            catch (Exception ex)
            {
                return new ErrorMessage(ex.Message, 500);
            }
            finally
            {
                session?.Close();
                session?.Dispose();
            }
        }

        public static async Task<Result<int, ErrorMessage>> SacuvajNastavnikaAsync(NastavnikBasic noviNastavnik, string osobaJMBG)
        {
            int nastavnikId = 0;
            ISession? session = null;

            try
            {
                session = DataLayer.GetSession();
                var osoba = await session.LoadAsync<Osoba>(osobaJMBG);

                var nastavnik = new Nastavnik
                {
                    DatumZaposlenja = noviNastavnik.DatumZaposlenja,
                    StrucnaSprema = noviNastavnik.StrucnaSprema,
                    Osoba = osoba
                };

                await session.SaveAsync(nastavnik);
                await session.FlushAsync();

                nastavnikId = nastavnik.Id;
            }
            catch (Exception ex)
            {
                return new ErrorMessage(ex.Message, 500);
            }
            finally
            {
                session?.Close();
                session?.Dispose();
            }

            return nastavnikId;
        }

        public static async Task<Result<NastavnikDTO, ErrorMessage>> NadjiNastavnikaAsync(int nId)
        {
            ISession session = null;

            try
            {
                session = DataLayer.GetSession();

                var n = await session.GetAsync<Nastavnik>(nId);


                if (n == null)
                {
                    return new ErrorMessage($"Nastavnik nije pronadjen!", 404);
                }

                NastavnikDTO nastDTO = new NastavnikDTO(
                    n.Osoba.JMBG,
                    n.Osoba.Ime,
                    n.Osoba.Prezime,
                    n.Osoba.Adresa,
                    n.Osoba.Mail,
                    string.Join(",", n.Osoba.Telefoni.Select(t => t.BrojTelefona)),
                    n.Id,
                    n.StrucnaSprema,
                    n.DatumZaposlenja.Date
                );

                return nastDTO;
            }
            catch (Exception ex)
            {
                return new ErrorMessage(ex.Message, 500);
            }
            finally
            {
                session?.Close();
                session?.Dispose();
            }
        }

        public static async Task<Result<bool, ErrorMessage>> ObrisiNastavnikaAsync(int nastavnikId)
        {
            ISession session = null;

            try
            {
                session = DataLayer.GetSession();

                var nastavnik = await session.LoadAsync<Nastavnik>(nastavnikId);

                var honorarni = await session.Query<Honorarni>()
                    .FirstOrDefaultAsync(h => h.Nastavnik.Id == nastavnikId);

                if (honorarni != null)
                    await session.DeleteAsync(honorarni);

                var stalni = await session.Query<Stalni>()
                    .FirstOrDefaultAsync(s => s.Nastavnik.Id == nastavnikId);

                if (stalni != null)
                {
                    var stalniKojimaJeMentor = await session.Query<Stalni>()
                        .Where(s => s.Mentor.JMBG == nastavnik.Osoba.JMBG)
                        .ToListAsync();

                    foreach (var s in stalniKojimaJeMentor)
                    {
                        s.Mentor = null;
                        await session.UpdateAsync(s);
                    }

                    await session.DeleteAsync(stalni);
                }

                await session.DeleteAsync(nastavnik);

                await session.FlushAsync();
                return true;
            }
            catch (Exception ex)
            {
                return new ErrorMessage(ex.Message, 500);
            }
            finally
            {
                session?.Close();
                session?.Dispose();
            }
        }

        public static async Task<Result<NastavnikDTO, ErrorMessage>> PrikaziMentoraAsync(int nastavnikId)
        {
            ISession session = null;

            try
            {
                session = DataLayer.GetSession();

                var stalniNastavnik = await session.Query<Stalni>()
                    .FirstOrDefaultAsync(s => s.Nastavnik.Id == nastavnikId);

                if (stalniNastavnik == null)
                {
                    return new ErrorMessage($"Stalni nastavnik nije pronadjen.", 404);
                }

                if (stalniNastavnik.Mentor == null)
                {
                    return new ErrorMessage("Nastavnik nema mentora.", 404);
                }

                if (!NHibernateUtil.IsInitialized(stalniNastavnik.Mentor.Telefoni))
                {
                    await NHibernateUtil.InitializeAsync(stalniNastavnik.Mentor.Telefoni);
                }

                var mentor = stalniNastavnik.Mentor;

                NastavnikDTO nastavnikMentor = new NastavnikDTO()
            {
                JMBG = mentor.JMBG,
                Ime = mentor.Ime,
                Prezime = mentor.Prezime,
                Adresa = mentor.Adresa,
                Mail = mentor.Mail,
                Telefoni = string.Join(", ", mentor.Telefoni.Select(t => t.BrojTelefona)),
                DatumZaposlenja = stalniNastavnik.Nastavnik.DatumZaposlenja,
                StrucnaSprema = stalniNastavnik.Nastavnik.StrucnaSprema
            };

                return nastavnikMentor;
            }
            catch (Exception ex)
            {
                return new ErrorMessage(ex.Message, 500);
            }
            finally
            {
                session?.Close();
                session?.Dispose();
            }
        }

        public static async Task<Result<bool, ErrorMessage>> IzmeniNastavnikaAsync(NastavnikBasic noviNastavnik, int nastavnikId)
        {
            ISession session = null;

            try
            {
                session = DataLayer.GetSession();

                var nastavnik = await session.LoadAsync<Nastavnik>(nastavnikId);

                if (nastavnik == null)
                {
                    return new ErrorMessage($"Nastavnik nije pronađen.", 404);
                }

                nastavnik.StrucnaSprema = noviNastavnik.StrucnaSprema;
                nastavnik.DatumZaposlenja = noviNastavnik.DatumZaposlenja;

                await session.UpdateAsync(nastavnik);
                await session.FlushAsync();

                return true;
            }
            catch (Exception ex)
            {
                return new ErrorMessage(ex.Message, 500);
            }
            finally
            {
                session?.Close();
                session?.Dispose();
            }
        }

        public static async Task<Result<List<NastavnikDTO>, ErrorMessage>> PrikaziKomeJeMentorAsync(string nastavnikJMBG)
        {
            ISession session = null;

            try
            {
                session = DataLayer.GetSession();

                var mentirani = await session.Query<Stalni>()
                    .Where(s => s.Mentor.JMBG == nastavnikJMBG)
                    .ToListAsync();

                if (!mentirani.Any())
                {
                    return new ErrorMessage("Nastavnik nije mentor.", 404);
                }

                var nastavniciKomeJeMentor = new List<NastavnikDTO>();

                foreach (var m in mentirani)
                {
                    var o = m.Nastavnik.Osoba;

                    if (!NHibernateUtil.IsInitialized(o.Telefoni))
                    {
                        await NHibernateUtil.InitializeAsync(o.Telefoni);
                    }

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

                return nastavniciKomeJeMentor;
            }
            catch (Exception ex)
            {
                return new ErrorMessage(ex.Message, 500);
            }
            finally
            {
                session?.Close();
                session?.Dispose();
            }
        }


    }
}

using DatabaseAccess.DTOs;
using MuzickaSkola;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.DataProviders
{
    public static class StalniDataProvider
    {
        public static async Task<Result<List<StalniDTO>, ErrorMessage>> PrikaziSveStalneNastavnikeAsync()
        {
            ISession session = null;
            try
            {
                session = DataLayer.GetSession();

                var stalniNastavnci = await session.Query<Stalni>()
                    .Select(s => new StalniDTO(
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
                    ))
                    .ToListAsync();

                return stalniNastavnci;
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

        public static async Task<Result<bool, ErrorMessage>> SacuvajStalnogAsync(StalniBasic noviStalni, string mentorJMBG,OsobaBasic novaOsoba, NastavnikBasic noviNastavnik)
        {
            ISession session = null;
            ITransaction transaction = null;

            try
            {
                session = DataLayer.GetSession();
                transaction = session.BeginTransaction();

                var osobaUBazi = await session.Query<Osoba>()
                    .FirstOrDefaultAsync(o => o.JMBG == novaOsoba.JMBG);

                var mentor = !string.IsNullOrEmpty(mentorJMBG)
                    ? await session.Query<Stalni>()
                        .FirstOrDefaultAsync(s => s.Nastavnik.Osoba.JMBG == mentorJMBG)
                    : null;

                if (osobaUBazi != null)
                {
                    return new ErrorMessage("Osoba sa tim JMBG-om već postoji", 400);
                }

                if (!string.IsNullOrEmpty(mentorJMBG) && mentor == null)
                {
                    return new ErrorMessage("Mentor sa tim JMBG-om ne postoji", 404);
                }

                if (mentor != null)
                {
                    await NHibernateUtil.InitializeAsync(mentor.Nastavnik.Osoba);
                }

                var osoba = new Osoba
                {
                    Adresa = novaOsoba.Adresa,
                    Ime = novaOsoba.Ime,
                    JMBG = novaOsoba.JMBG,
                    Mail = novaOsoba.Mail,
                    Prezime = novaOsoba.Prezime,
                };

                foreach (var item in novaOsoba.Telefoni)
                {
                    var telefon = new Telefon
                    {
                        BrojTelefona = item.BrojTelefona,
                        Osoba = osoba
                    };
                    osoba.Telefoni.Add(telefon);
                }

                var nastavnik = new Nastavnik
                {
                    DatumZaposlenja = noviNastavnik.DatumZaposlenja,
                    StrucnaSprema = noviNastavnik.StrucnaSprema,
                    Osoba = osoba,
                };

                var stalni = new Stalni
                {
                    RadnoVreme = noviStalni.RadnoVreme,
                    Mentor = mentor?.Nastavnik.Osoba,
                    Nastavnik = nastavnik,
                };

                await session.SaveAsync(osoba);
                await session.SaveAsync(nastavnik);
                await session.SaveAsync(stalni);

                await transaction.CommitAsync();

                return true;
            }
            catch (Exception ex)
            {
                if (transaction != null && transaction.IsActive)
                {
                    await transaction.RollbackAsync();
                }

                return new ErrorMessage(ex.Message, 500);
            }
            finally
            {
                transaction?.Dispose();
                session?.Close();
                session?.Dispose();
            }
        }

        public static async Task<Result<bool, ErrorMessage>> IzmeniStalnogAsync(StalniBasic noviStalni,int stalniId,string mentorJMBG,OsobaBasic novaOsoba,NastavnikBasic noviNastavnik,int nastavnikId)
        {
            ISession session = null;
            ITransaction transaction = null;

            try
            {
                session = DataLayer.GetSession();
                transaction = session.BeginTransaction();

                var osoba = await session.LoadAsync<Osoba>(novaOsoba.JMBG);
                var nastavnik = await session.LoadAsync<Nastavnik>(nastavnikId);
                var stalni = await session.LoadAsync<Stalni>(stalniId);

                var mentor = !string.IsNullOrEmpty(mentorJMBG)
                    ? await session.Query<Stalni>()
                        .FirstOrDefaultAsync(s => s.Nastavnik.Osoba.JMBG == mentorJMBG)
                    : null;

                if (!string.IsNullOrEmpty(mentorJMBG) && mentor == null)
                {
                    return new ErrorMessage("Mentor sa tim JMBG-om ne postoji", 404);
                }

                await NHibernateUtil.InitializeAsync(osoba.Telefoni);

 
                osoba.Telefoni.Clear();
                foreach (var item in novaOsoba.Telefoni)
                {
                    var telefon = new Telefon
                    {
                        BrojTelefona = item.BrojTelefona,
                        Osoba = osoba
                    };
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

                await session.UpdateAsync(osoba);
                await session.UpdateAsync(nastavnik);
                await session.UpdateAsync(stalni);

                await transaction.CommitAsync();

                return true;
            }
            catch (Exception ex)
            {
                if (transaction != null && transaction.IsActive)
                {
                    await transaction.RollbackAsync();
                }
                return new ErrorMessage(ex.Message, 500);
            }
            finally
            {
                transaction?.Dispose();
                session?.Close();
                session?.Dispose();
            }
        }

        public static async Task<Result<Stalni, ErrorMessage>> NadjiStalnogAsync(int nastavnikId)
        {
            ISession session = null;
            try
            {
                session = DataLayer.GetSession();

                var stalni = await session.Query<Stalni>()
                    .FirstOrDefaultAsync(h => h.Nastavnik.Id == nastavnikId);

                if (stalni == null)
                {
                    return new ErrorMessage("Stalni nastavnik nije pronađen", 404);
                }

                return stalni;
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

        public static async Task<Result<bool, ErrorMessage>> ObrisiStalnogAsync(int stalniId)
        {
            ISession session = null;
            ITransaction transaction = null;

            try
            {
                session = DataLayer.GetSession();
                transaction = session.BeginTransaction();

                var stalni = await session.GetAsync<Stalni>(stalniId);
                if (stalni == null)
                {
                    return new ErrorMessage("Stalni nastavnik ne postoji", 404);
                }

                await session.DeleteAsync(stalni);
                await transaction.CommitAsync();

                return true;
            }
            catch (Exception ex)
            {
                if (transaction != null && transaction.IsActive)
                {
                    await transaction.RollbackAsync();
                }
                return new ErrorMessage(ex.Message, 500);
            }
            finally
            {
                transaction?.Dispose();
                session?.Close();
                session?.Dispose();
            }
        }


    }
}

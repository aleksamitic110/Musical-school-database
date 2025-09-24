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
    public static class OdrasliDataProvider
    {
        public static async Task<Result<List<OdrasliDTO>, ErrorMessage>> PrikaziOdrasleAsync()
        {
        ISession session = null;

        try
        {
            session = DataLayer.GetSession();

            var odrasli = await session.Query<Odrasli>().Fetch(o => o.Polaznik).ThenFetch(p => p.Osoba).ToListAsync();

            var odrasliPolaznici = new List<OdrasliDTO>();

            foreach (var h in odrasli)
            {
                var osoba = h.Polaznik.Osoba;

                if (!NHibernateUtil.IsInitialized(osoba.Telefoni))
                {
                    await NHibernateUtil.InitializeAsync(osoba.Telefoni);
                }

                odrasliPolaznici.Add(new OdrasliDTO(
                    h.Zanimanje,
                    h.Polaznik.Id,
                    osoba.JMBG,
                    osoba.Ime,
                    osoba.Prezime,
                    osoba.Adresa,
                    osoba.Mail,
                    string.Join(", ", osoba.Telefoni.Select(t => t.BrojTelefona))
                ));
            }

            return odrasliPolaznici;
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



        public static async Task<Result<bool, ErrorMessage>> SacuvajOdraslogPolaznikaAsync(
      OdrasliBasic noviOdrasli, OsobaBasic novaOsoba, PolaznikBasic noviPolaznik)
        {
            ISession session = null;
            ITransaction transaction = null;

            try
            {
                session = DataLayer.GetSession();
                transaction = session.BeginTransaction();

                var osobaUBazi = await session.Query<Osoba>()
                    .FirstOrDefaultAsync(o => o.JMBG == novaOsoba.JMBG);

                if (osobaUBazi != null)
                {
                    return new ErrorMessage("Osoba sa tim JMBG-om već postoji!", 400);
                }

                var osoba = new Osoba
                {
                    Adresa = novaOsoba.Adresa,
                    Ime = novaOsoba.Ime,
                    JMBG = novaOsoba.JMBG,
                    Mail = novaOsoba.Mail,
                    Prezime = novaOsoba.Prezime
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

                var polaznik = new Polaznik
                {
                    Osoba = osoba
                };

                var odrasli = new Odrasli
                {
                    Polaznik = polaznik,
                    Zanimanje = noviOdrasli.Zanimanje
                };

                await session.SaveAsync(osoba);
                await session.SaveAsync(polaznik);
                await session.SaveAsync(odrasli);

                await session.FlushAsync();

                await transaction.CommitAsync(); 

                return true;
            }
            catch (Exception ex)
            {
                if (transaction != null && transaction.IsActive)
                    await transaction.RollbackAsync(); 

                return new ErrorMessage(ex.Message, 500);
            }
            finally
            {
                session?.Close();
                session?.Dispose();
            }
        }


        public static async Task<Result<bool, ErrorMessage>> ObrisiOdraslogPolaznikaAsync(int polaznikId)
        {
            ISession session = null;

            try
            {
                session = DataLayer.GetSession();

                var odrasli = await session.Query<Odrasli>()
                    .FirstOrDefaultAsync(o => o.Polaznik.Id == polaznikId);

                if (odrasli == null)
                {
                    return new ErrorMessage($"Odrasli polaznik nije pronađen.", 404);
                }
                
                await session.DeleteAsync(odrasli);
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

        public static async Task<Result<bool, ErrorMessage>> IzmeniPodatkeOdraslogPolaznikaAsync(int polaznikId, OdrasliBasic noviOdrasli)
        {
            ISession session = null;

            try
            {
                session = DataLayer.GetSession();

                var polaznik = await session.Query<Polaznik>()
                    .FirstOrDefaultAsync(p => p.Id == polaznikId);

                if (polaznik == null)
                {
                    return new ErrorMessage($"Polaznik nije pronađen.", 404);
                }

                var odrasli = await session.Query<Odrasli>()
                    .FirstOrDefaultAsync(o => o.Polaznik.Id == polaznikId);

                if (odrasli != null)
                {
                    odrasli.Zanimanje = noviOdrasli.Zanimanje;
                    await session.UpdateAsync(odrasli);
                }
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




    }

}

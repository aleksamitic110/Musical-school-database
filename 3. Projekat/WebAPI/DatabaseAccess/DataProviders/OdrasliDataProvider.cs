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



        public static async Task<Result<bool, ErrorMessage>> SacuvajOdraslogPolaznikaAsync(OdrasliSaveDto dto)
        {
            ISession session = null;
            try
            {
                session = DataLayer.GetSession();

                var odrasli = new Odrasli
                {
                    Polaznik = await session.LoadAsync<Polaznik>(dto.PolaznikId),
                    Zanimanje = dto.Zanimanje
                };

                await session.SaveAsync(odrasli);
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

        public static async Task<Result<bool, ErrorMessage>> IzmeniOdraslogPolaznikaAsync(OdrasliUpdateDto dto)
        {
            ISession session = null;
            try
            {
                session = DataLayer.GetSession();

                var odrasli = await session.GetAsync<Odrasli>(dto.Id);
                if (odrasli == null)
                {
                    return new ErrorMessage($"Odrasli polaznik sa Id={dto.Id} nije pronađen.", 404);
                }

                odrasli.Polaznik = await session.LoadAsync<Polaznik>(dto.PolaznikId);
                odrasli.Zanimanje = dto.Zanimanje;

                await session.UpdateAsync(odrasli);
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

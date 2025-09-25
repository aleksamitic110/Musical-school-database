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
    public static class PolaznikDataProvider
    {
        public static async Task<Result<List<PolaznikGetDto>, ErrorMessage>> VratiSvePolaznikeAsync()
        {
            ISession session = null;
            try
            {
                session = DataLayer.GetSession();

                var polaznici = await session.Query<Polaznik>().ToListAsync();

                var dtoLista = polaznici.Select(p => new PolaznikGetDto
                {
                    Id = p.Id,
                    OsobaJMBG = p.Osoba?.JMBG,
                    Ime = p.Osoba?.Ime,
                    Prezime = p.Osoba?.Prezime
                }).ToList();

                return dtoLista;
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

        public static async Task<Result<bool, ErrorMessage>> ObrisiPolaznikaAsync(int polaznikId)
        {
            ISession session = null;
            try
            {
                session = DataLayer.GetSession();

                var polaznik = await session.GetAsync<Polaznik>(polaznikId);
                if (polaznik == null)
                {
                    return new ErrorMessage($"Polaznik sa Id={polaznikId} nije pronađen.", 404);
                }

                await session.DeleteAsync(polaznik);
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



        public static async Task<Result<bool, ErrorMessage>> IzmeniPolaznikaAsync(PolaznikUpdateDto dto)
        {
            ISession session = null;
            try
            {
                session = DataLayer.GetSession();

                var polaznik = await session.GetAsync<Polaznik>(dto.Id);
                if (polaznik == null)
                {
                    return new ErrorMessage($"Polaznik sa Id={dto.Id} nije pronađen.", 404);
                }

                polaznik.Osoba = await session.LoadAsync<Osoba>(dto.OsobaJMBG);

                await session.UpdateAsync(polaznik);
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




        public static async Task<Result<bool, ErrorMessage>> SacuvajPolaznikaAsync(PolaznikSaveDto dto)
        {
            ISession session = null;
            try
            {
                session = DataLayer.GetSession();

                var polaznik = new Polaznik
                {
                    Osoba = await session.LoadAsync<Osoba>(dto.OsobaJMBG)
                };

                await session.SaveAsync(polaznik);
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

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
    public static class DeteDataProvider
    {

        public static async Task<Result<bool, ErrorMessage>> IzmeniDeteAsync(DeteUpdateDto dto)
        {
            ISession session = null;
            try
            {
                session = DataLayer.GetSession();

                var dete = await session.GetAsync<Dete>(dto.Id);
                if (dete == null)
                {
                    return new ErrorMessage($"Dete sa Id={dto.Id} nije pronađeno.", 404);
                }

                dete.DatumRodjenja = dto.DatumRodjenja;
                dete.BrojDosijea = dto.BrojDosijea;
                dete.Staratelj = await session.LoadAsync<Staratelj>(dto.StarateljId);
                dete.Polaznik = await session.LoadAsync<Polaznik>(dto.PolaznikId);

                await session.UpdateAsync(dete);
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

        public static async Task<Result<bool, ErrorMessage>> ObrisiDeteAsync(int deteId)
        {
            ISession session = null;
            try
            {
                session = DataLayer.GetSession();

                var dete = await session.GetAsync<Dete>(deteId);
                if (dete == null)
                {
                    return new ErrorMessage($"Dete sa Id={deteId} nije pronađeno.", 404);
                }

                await session.DeleteAsync(dete);
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

        public static async Task<Result<List<DeteGetDto>, ErrorMessage>> VratiDecuAsync()
        {
            ISession session = null;
            try
            {
                session = DataLayer.GetSession();

                var deca = await session.Query<Dete>().ToListAsync();

                var dtoLista = deca.Select(d => new DeteGetDto
                {
                    Id = d.Id,
                    DatumRodjenja = d.DatumRodjenja,
                    BrojDosijea = d.BrojDosijea,
                    StarateljId = d.Staratelj?.Id ?? 0,
                    StarateljIme = d.Staratelj?.Osoba?.Ime ?? "",
                    PolaznikId = d.Polaznik?.Id ?? 0,
                    PolaznikIme = d.Polaznik?.Osoba?.Ime ?? ""
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




        public static async Task<Result<bool, ErrorMessage>> SacuvajDeteAsync(DeteSaveDto dto)
        {
            ISession session = null;
            try
            {
                session = DataLayer.GetSession();

                var dete = new Dete
                {
                    DatumRodjenja = dto.DatumRodjenja,
                    BrojDosijea = dto.BrojDosijea,
                    Staratelj = await session.LoadAsync<Staratelj>(dto.StarateljId),
                    Polaznik = await session.LoadAsync<Polaznik>(dto.PolaznikId)
                };

                await session.SaveAsync(dete);
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

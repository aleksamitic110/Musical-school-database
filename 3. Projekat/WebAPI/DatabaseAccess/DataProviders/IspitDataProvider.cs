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
    public static class IspitDataProvider
    {
        public static async Task<Result<string, ErrorMessage>> SacuvajIspitAsync(IspitSaveDto dto)
        {
            ISession session = null;
            try
            {
                session = DataLayer.GetSession();

                var kurs = await session.GetAsync<Kurs>(dto.KursId);
                if (kurs == null)
                    return new ErrorMessage("Kurs ne postoji.", 400);

                var ispit = new Ispit
                {
                    Id = Guid.NewGuid().ToString(),
                    Kurs = kurs,
                    Datum = dto.Datum
                };

                await session.SaveAsync(ispit);
                await session.FlushAsync();
                return ispit.Id;
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

        public static async Task<Result<bool, ErrorMessage>> IzmeniIspitAsync(IspitUpdateDto dto)
        {
            ISession session = null;
            try
            {
                session = DataLayer.GetSession();

                var ispit = await session.GetAsync<Ispit>(dto.Id);
                if (ispit == null)
                    return new ErrorMessage($"Ispit sa Id={dto.Id} nije pronađen.", 404);

                var kurs = await session.GetAsync<Kurs>(dto.KursId);
                if (kurs == null)
                    return new ErrorMessage("Kurs ne postoji.", 400);

                ispit.Kurs = kurs;
                ispit.Datum = dto.Datum;

                await session.UpdateAsync(ispit);
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

        public static async Task<Result<bool, ErrorMessage>> ObrisiIspitAsync(string ispitId)
        {
            ISession session = null;
            try
            {
                session = DataLayer.GetSession();

                var ispit = await session.GetAsync<Ispit>(ispitId);
                if (ispit == null)
                    return new ErrorMessage($"Ispit sa Id={ispitId} nije pronađen.", 404);

                await session.DeleteAsync(ispit);
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

        public static async Task<Result<List<IspitGetDto>, ErrorMessage>> VratiSveIspiteAsync()
        {
            ISession session = null;
            try
            {
                session = DataLayer.GetSession();

                var ispiti = await session.Query<Ispit>().ToListAsync();

                var dtoLista = ispiti.Select(i => new IspitGetDto
                {
                    Id = i.Id,
                    KursId = i.Kurs?.Id,
                    KursNaziv = i.Kurs?.Naziv ?? "",
                    Datum = i.Datum
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




    }
}

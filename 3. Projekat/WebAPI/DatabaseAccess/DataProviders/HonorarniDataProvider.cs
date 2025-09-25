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
    public static class HonorarniDataProvider
    {
        public static async Task<Result<HonorarniGetDto, ErrorMessage>> NadjiHonorarnogAsync(int honorarniId)
        {
            ISession session = null;
            try
            {
                session = DataLayer.GetSession();

                var honorarni = await session.GetAsync<Honorarni>(honorarniId);
                if (honorarni == null)
                    return new ErrorMessage($"Honorarni sa Id={honorarniId} nije pronađen.", 404);

                var dto = new HonorarniGetDto
                {
                    Id = honorarni.Id,
                    NastavnikId = honorarni.Nastavnik?.Id ?? 0,
                    NastavnikIme = honorarni.Nastavnik?.Osoba?.Ime ?? "",
                    BrojUgovora = honorarni.BrojUgovora,
                    BrojCasovaMesecno = honorarni.BrojCasovaMesecno,
                    TrajanjeUgovora = honorarni.TrajanjeUgovora
                };

                return dto;
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

        public static async Task<Result<int, ErrorMessage>> SacuvajHonorarniAsync(HonorarniSaveDto dto)
        {
            ISession session = null;
            ITransaction transaction = null;
            try
            {
                session = DataLayer.GetSession();
                transaction = session.BeginTransaction();

                var nastavnik = await session.GetAsync<Nastavnik>(dto.NastavnikId);
                if (nastavnik == null)
                    return new ErrorMessage("Nastavnik ne postoji.", 400);

                var honorarni = new Honorarni
                {
                    Nastavnik = nastavnik,
                    BrojUgovora = dto.BrojUgovora,
                    BrojCasovaMesecno = dto.BrojCasovaMesecno,
                    TrajanjeUgovora = dto.TrajanjeUgovora
                };

                await session.SaveAsync(honorarni);
                await transaction.CommitAsync();

                return honorarni.Id;
            }
            catch (Exception ex)
            {
                await transaction?.RollbackAsync();
                return new ErrorMessage(ex.Message, 500);
            }
            finally
            {
                transaction?.Dispose();
                session?.Close();
                session?.Dispose();
            }
        }


        public static async Task<Result<bool, ErrorMessage>> IzmeniHonorarniAsync(HonorarniUpdateDto dto)
        {
            ISession session = null;
            try
            {
                session = DataLayer.GetSession();

                var honorarni = await session.GetAsync<Honorarni>(dto.Id);
                if (honorarni == null)
                    return new ErrorMessage($"Honorarni sa Id={dto.Id} nije pronađen.", 404);

                var nastavnik = await session.GetAsync<Nastavnik>(dto.NastavnikId);
                if (nastavnik == null)
                    return new ErrorMessage("Nastavnik ne postoji.", 400);

                honorarni.Nastavnik = nastavnik;
                honorarni.BrojUgovora = dto.BrojUgovora;
                honorarni.BrojCasovaMesecno = dto.BrojCasovaMesecno;
                honorarni.TrajanjeUgovora = dto.TrajanjeUgovora;


                await session.UpdateAsync(honorarni);
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


        public static async Task<Result<bool, ErrorMessage>> ObrisiHonorarniAsync(int honorarniId)
        {
            ISession session = null;
            try
            {
                session = DataLayer.GetSession();

                var honorarni = await session.GetAsync<Honorarni>(honorarniId);
                if (honorarni == null)
                    return new ErrorMessage($"Honorarni sa Id={honorarniId} nije pronađen.", 404);

                await session.DeleteAsync(honorarni);
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


        public static async Task<Result<List<HonorarniGetDto>, ErrorMessage>> VratiSveHonorarneAsync()
        {
            ISession session = null;
            try
            {
                session = DataLayer.GetSession();

                var honorarniList = await session.Query<Honorarni>().ToListAsync();

                var dtoLista = honorarniList.Select(h => new HonorarniGetDto
                {
                    Id = h.Id,
                    NastavnikId = h.Nastavnik?.Id ?? 0,
                    NastavnikIme = h.Nastavnik?.Osoba?.Ime ?? "",
                    BrojUgovora = h.BrojUgovora,
                    BrojCasovaMesecno = h.BrojCasovaMesecno,
                    TrajanjeUgovora = h.TrajanjeUgovora
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

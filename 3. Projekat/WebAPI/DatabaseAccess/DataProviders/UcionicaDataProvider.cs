using DatabaseAccess.DTOs;
using MuzickaSkola;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.DataProviders
{
    public static class UcionicaDataProvider
    {
        public static async Task<Result<UcionicaDTO, ErrorMessage>> NadjiUcionicuAsync(string uId)
        {
            ISession session = null;

            try
            {
                session = DataLayer.GetSession();

                var ucionica = await session.GetAsync<Ucionica>(uId);

                if (ucionica == null)
                {
                    return new ErrorMessage("Ucionica ne postoji", 404);
                }

                UcionicaDTO ucionicaDTO = new UcionicaDTO(ucionica.Id,ucionica.Oznaka, ucionica.KapacitetUcionice, ucionica.Filijala.Id);


                return ucionicaDTO;
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

        public static async Task<Result<List<UcionicaDTO>, ErrorMessage>> VratiSveUcioniceAsync()
        {
            ISession session = null;

            try
            {
                session = DataLayer.GetSession();

                var ucioniceEntities = await session.Query<Ucionica>()
                    .Select(k => new UcionicaDTO(
                        k.Id,
                        k.Oznaka,
                        k.KapacitetUcionice,
                        k.Filijala.Id
                    ))
                    .ToListAsync();

                return ucioniceEntities;
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

        public static async Task<Result<string, ErrorMessage>> DodajUcionicuAsync(UcionicaDTO novaUcionica)
        {
            ISession session = null;
            ITransaction transaction = null;

            try
            {
                session = DataLayer.GetSession();
                transaction = session.BeginTransaction();

                var filijala = await session.GetAsync<Filijala>(novaUcionica.FilijalaId);
                if (filijala == null)
                {
                    return new ErrorMessage("Filijala ne postoji", 404);
                }

                var ucionica = new Ucionica
                {
                    Id = novaUcionica.Id,
                    Oznaka = novaUcionica.Oznaka,
                    KapacitetUcionice = novaUcionica.KapacitetUcionice,
                    Filijala = filijala
                };

                await session.SaveAsync(ucionica);
                await transaction.CommitAsync();

                return ucionica.Id;
            }
            catch (Exception ex)
            {
                if (transaction != null && transaction.IsActive)
                    await transaction.RollbackAsync();

                return new ErrorMessage(ex.Message, 500);
            }
            finally
            {
                transaction?.Dispose();
                session?.Close();
                session?.Dispose();
            }
        }

        public static async Task<Result<bool, ErrorMessage>> IzmeniUcionicuAsync(UcionicaDTO podaci)
        {
            ISession session = null;
            ITransaction transaction = null;

            try
            {
                session = DataLayer.GetSession();
                transaction = session.BeginTransaction();

                var ucionica = await session.GetAsync<Ucionica>(podaci.Id);
                if (ucionica == null)
                {
                    return new ErrorMessage("Ucionica ne postoji", 404);
                }

                var filijala = await session.GetAsync<Filijala>(podaci.FilijalaId);
                if (filijala == null)
                {
                    return new ErrorMessage("Filijala ne postoji", 404);
                }

                ucionica.Oznaka = podaci.Oznaka;
                ucionica.KapacitetUcionice = podaci.KapacitetUcionice;
                ucionica.Filijala = filijala;

                await session.UpdateAsync(ucionica);
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
                transaction?.Dispose();
                session?.Close();
                session?.Dispose();
            }
        }


        public static async Task<Result<bool, ErrorMessage>> ObrisiUcionicuAsync(string ucionicaId)
        {
            ISession session = null;
            ITransaction transaction = null;

            try
            {
                session = DataLayer.GetSession();
                transaction = session.BeginTransaction();

                var ucionica = await session.GetAsync<Ucionica>(ucionicaId);
                if (ucionica == null)
                {
                    return new ErrorMessage("Ucionica ne postoji", 404);
                }

                await NHibernateUtil.InitializeAsync(ucionica.Casovi);

                foreach (var cas in ucionica.Casovi.ToList())
                {
                    await session.DeleteAsync(cas);
                }

                await session.DeleteAsync(ucionica);
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
                transaction?.Dispose();
                session?.Close();
                session?.Dispose();
            }
        }


    }
}

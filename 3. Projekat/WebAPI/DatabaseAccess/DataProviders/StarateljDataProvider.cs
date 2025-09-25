using DatabaseAccess.DTOs;
using MuzickaSkola;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DatabaseAccess.DataProviders
{
    public static class StarateljDataProvider
    {
        public static async Task<Result<List<StarateljDTO>, ErrorMessage>> VratiStarateljeAsync()
        {
            ISession session = null;

            try
            {
                session = DataLayer.GetSession();

                var starateljiEntities = await session.Query<Staratelj>().ToListAsync();

                var starateljiDto = new List<StarateljDTO>();

                foreach (var s in starateljiEntities)
                {
                    await NHibernateUtil.InitializeAsync(s.Deca);
                    await NHibernateUtil.InitializeAsync(s.Osoba.Telefoni);

                    starateljiDto.Add(new StarateljDTO(
                        s.Id,
                        s.Deca.ToList(),
                        s.Osoba.JMBG,
                        s.Osoba.Ime,
                        s.Osoba.Prezime,
                        s.Osoba.Adresa,
                        s.Osoba.Mail,
                        string.Join(", ", s.Osoba.Telefoni.Select(t => t.BrojTelefona))
                    ));
                }

                return starateljiDto;
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

        public static async Task<Result<bool, ErrorMessage>> SacuvajStarateljaAsync(SacuvajStarateljaDTO dto)
        {
            ISession session = null;
            try
            {
                session = DataLayer.GetSession();

                var staratelj = new Staratelj
                {
                    Osoba = await session.LoadAsync<Osoba>(dto.OsobaJMBG),
                };

                await session.SaveAsync(staratelj);
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


        public static async Task<Result<bool, ErrorMessage>> IzmeniStarateljaAsync(IzmeniStarateljaDTO dto)
        {
            ISession session = null;
            try
            {
                session = DataLayer.GetSession();

                var staratelj = await session.GetAsync<Staratelj>(dto.Id);
                if (staratelj == null)
                {
                    return new ErrorMessage($"Staratelj sa Id={dto.Id} nije pronađen.", 404);
                }

                staratelj.Osoba = await session.LoadAsync<Osoba>(dto.OsobaJMBG);

                await session.UpdateAsync(staratelj);
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


        public static async Task<Result<bool, ErrorMessage>> ObrisiStarateljaAsync(int starateljId)
        {
            ISession session = null;
            try
            {
                session = DataLayer.GetSession();

                var staratelj = await session.GetAsync<Staratelj>(starateljId);
                if (staratelj == null)
                {
                    return new ErrorMessage($"Staratelj sa Id={starateljId} nije pronađen.", 404);
                }

                await session.DeleteAsync(staratelj);
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

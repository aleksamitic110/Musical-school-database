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

        public static async Task<Result<int, ErrorMessage>> SacuvajStarateljaAsync(StarateljBasic noviStaratelj, OsobaBasic novaOsoba)
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
                    return new ErrorMessage("Osoba sa tim JMBG-om već postoji", 400);
                }

                var osoba = new Osoba
                {
                    JMBG = novaOsoba.JMBG,
                    Ime = novaOsoba.Ime,
                    Prezime = novaOsoba.Prezime,
                    Adresa = novaOsoba.Adresa,
                    Mail = novaOsoba.Mail,
                    Telefoni = new List<Telefon>()
                };

                foreach (var telefonBasic in novaOsoba.Telefoni)
                {
                    var telefon = new Telefon
                    {
                        BrojTelefona = telefonBasic.BrojTelefona,
                        Osoba = osoba
                    };
                    osoba.Telefoni.Add(telefon);
                }

                var staratelj = new Staratelj
                {
                    Osoba = osoba,
                    Deca = new List<Dete>()
                };

                await session.SaveAsync(osoba);
                await session.SaveAsync(staratelj);
                await session.FlushAsync();

                await transaction.CommitAsync();

                return staratelj.Id; 
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

        public static async Task<Result<bool, ErrorMessage>> IzmeniStarateljaAsync(StarateljDTO podaci)
        {
            ISession session = null;
            ITransaction transaction = null;

            try
            {
                session = DataLayer.GetSession();
                transaction = session.BeginTransaction();

                var osobaIzBaze = await session.GetAsync<Osoba>(podaci.JMBG);
                if (osobaIzBaze == null)
                {
                    return new ErrorMessage("Osoba nije pronađena u bazi.", 404);
                }

                osobaIzBaze.Ime = podaci.Ime;
                osobaIzBaze.Prezime = podaci.Prezime;
                osobaIzBaze.Adresa = podaci.Adresa;
                osobaIzBaze.Mail = podaci.Mail;

                await NHibernateUtil.InitializeAsync(osobaIzBaze.Telefoni);
                osobaIzBaze.Telefoni.Clear();
                await session.FlushAsync(); 

                var noviTelefoni = podaci.Telefoni
                    .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var broj in noviTelefoni)
                {
                    osobaIzBaze.Telefoni.Add(new Telefon
                    {
                        BrojTelefona = broj.Trim(),
                        Osoba = osobaIzBaze
                    });
                }

                await session.UpdateAsync(osobaIzBaze);
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

        public static async Task<Result<bool, ErrorMessage>> ObrisiStarateljaAsync(int starateljId)
        {
            ISession session = null;
            ITransaction transaction = null;

            try
            {
                session = DataLayer.GetSession();
                transaction = session.BeginTransaction();

                var staratelj = await session.GetAsync<Staratelj>(starateljId);
                if (staratelj == null)
                {
                    return new ErrorMessage("Staratelj ne postoji", 404);
                }

                await NHibernateUtil.InitializeAsync(staratelj.Deca);
                await NHibernateUtil.InitializeAsync(staratelj.Osoba.Telefoni);

                foreach (var dete in staratelj.Deca.ToList())
                {
                    await session.DeleteAsync(dete);
                }

                await session.DeleteAsync(staratelj);

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

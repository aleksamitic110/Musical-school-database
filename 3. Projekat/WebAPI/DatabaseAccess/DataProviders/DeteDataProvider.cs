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
        public static async Task<Result<List<DeteDTO>, ErrorMessage>> VratiDecuStarateljaAsync(int starateljId)
        {
            ISession session = null;

            try
            {
                session = DataLayer.GetSession();

                var decaEntities = await session.Query<Dete>()
                    .Where(d => d.Staratelj.Id == starateljId)
                    .ToListAsync();

                var decaDto = new List<DeteDTO>();

                foreach (var dete in decaEntities)
                {

                    await NHibernateUtil.InitializeAsync(dete.Polaznik.Osoba.Telefoni);

                    decaDto.Add(new DeteDTO
                    {
                        Id = dete.Polaznik.Id,
                        JMBG = dete.Polaznik.Osoba.JMBG,
                        Ime = dete.Polaznik.Osoba.Ime,
                        Prezime = dete.Polaznik.Osoba.Prezime,
                        Adresa = dete.Polaznik.Osoba.Adresa,
                        Mail = dete.Polaznik.Osoba.Mail,
                        Telefoni = string.Join(", ", dete.Polaznik.Osoba.Telefoni.Select(t => t.BrojTelefona)),
                        IdDeteta = dete.Id,
                        DatumRodjenja = dete.DatumRodjenja,
                        BrojDosijea = dete.BrojDosijea,
                        Staratelj = new StarateljDTO
                        {
                            Id = dete.Staratelj.Id,
                            Ime = dete.Staratelj.Osoba.Ime,
                            Prezime = dete.Staratelj.Osoba.Prezime
                        }
                    });
                }

                return decaDto;
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

        public static async Task<Result<int, ErrorMessage>> SacuvajDeteAsync(DeteBasic novoDete,int starateljId,PolaznikBasic noviPolaznik,OsobaBasic novaOsoba)
        {
            ISession session = null;
            ITransaction transaction = null;

            try
            {
                session = DataLayer.GetSession();
                transaction = session.BeginTransaction();

                var starateljUBazi = await session.GetAsync<Staratelj>(starateljId);
                if (starateljUBazi == null)
                {
                    return new ErrorMessage("Staratelj ne postoji.", 404);
                }

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
                    osoba.Telefoni.Add(new Telefon
                    {
                        BrojTelefona = telefonBasic.BrojTelefona,
                        Osoba = osoba
                    });
                }

                var polaznik = new Polaznik
                {
                    Osoba = osoba
                };

                var dete = new Dete
                {
                    DatumRodjenja = novoDete.DatumRodjenja,
                    BrojDosijea = novoDete.BrojDosijea,
                    Polaznik = polaznik,
                    Staratelj = starateljUBazi
                };

                await session.SaveAsync(osoba);
                await session.SaveAsync(polaznik);
                await session.SaveAsync(dete);
                await session.FlushAsync();

                await transaction.CommitAsync();

                return dete.Id;
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

        public static async Task<Result<bool, ErrorMessage>> IzmeniDeteAsync(DeteDTO podaci, PolaznikBasic noviPolaznik, OsobaBasic novaOsoba)
        {
            ISession session = null;
            ITransaction transaction = null;

            try
            {
                session = DataLayer.GetSession();
                transaction = session.BeginTransaction();

                var dete = await session.GetAsync<Dete>(podaci.IdDeteta);
                if (dete == null)
                    return new ErrorMessage("Dete ne postoji", 404);

                var polaznik = await session.GetAsync<Polaznik>(dete.Polaznik.Id);
                var osoba = await session.GetAsync<Osoba>(polaznik.Osoba.JMBG);

                if (osoba == null || polaznik == null)
                    return new ErrorMessage("Polaznik ili osoba nisu pronađeni", 404);

                osoba.Ime = novaOsoba.Ime;
                osoba.Prezime = novaOsoba.Prezime;
                osoba.Adresa = novaOsoba.Adresa;
                osoba.Mail = novaOsoba.Mail;

                osoba.Telefoni.Clear();
                foreach (var t in novaOsoba.Telefoni)
                {
                    osoba.Telefoni.Add(new Telefon { BrojTelefona = t.BrojTelefona, Osoba = osoba });
                }

                dete.DatumRodjenja = podaci.DatumRodjenja;
                dete.BrojDosijea = podaci.BrojDosijea;

                await session.UpdateAsync(osoba);
                await session.UpdateAsync(polaznik);
                await session.UpdateAsync(dete);

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

        public static async Task<Result<bool, ErrorMessage>> ObrisiDeteAsync(int deteId)
        {
            ISession session = null;
            ITransaction transaction = null;

            try
            {
                session = DataLayer.GetSession();
                transaction = session.BeginTransaction();

                var dete = await session.GetAsync<Dete>(deteId);
                if (dete == null)
                    return new ErrorMessage("Dete ne postoji", 404);

                var polaznik = await session.GetAsync<Polaznik>(dete.Polaznik.Id);
                var osoba = await session.GetAsync<Osoba>(polaznik.Osoba.JMBG);

                await NHibernateUtil.InitializeAsync(osoba.Telefoni);

                foreach (var t in osoba.Telefoni.ToList())
                {
                    await session.DeleteAsync(t);
                }

                await session.DeleteAsync(dete);
                await session.DeleteAsync(polaznik);
                await session.DeleteAsync(osoba);

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



        public static async Task<Result<List<DeteDTO>, ErrorMessage>> VratiDecuAsync()
        {
            ISession session = null;

            try
            {
                session = DataLayer.GetSession();

                var decaEntities = await session.Query<Dete>().ToListAsync();
                var decaDTO = new List<DeteDTO>();

                foreach (var dete in decaEntities)
                {
                    await NHibernateUtil.InitializeAsync(dete.Polaznik.Osoba.Telefoni);

                    decaDTO.Add(new DeteDTO
                    {
                        Id = dete.Polaznik.Id,
                        JMBG = dete.Polaznik.Osoba.JMBG,
                        Ime = dete.Polaznik.Osoba.Ime,
                        Prezime = dete.Polaznik.Osoba.Prezime,
                        Adresa = dete.Polaznik.Osoba.Adresa,
                        Mail = dete.Polaznik.Osoba.Mail,
                        Telefoni = string.Join(", ", dete.Polaznik.Osoba.Telefoni.Select(t => t.BrojTelefona)),
                        IdDeteta = dete.Id,
                        DatumRodjenja = dete.DatumRodjenja,
                        BrojDosijea = dete.BrojDosijea,
                        Staratelj = new StarateljDTO
                        {
                            Id = dete.Staratelj.Id,
                            Ime = dete.Staratelj.Osoba.Ime,
                            Prezime = dete.Staratelj.Osoba.Prezime
                        }
                    });
                }

                return decaDTO;
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

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
    public static class OsobaDataProvider
    {
        public static async Task<Result<string, ErrorMessage>> SacuvajOsobuAsync(SacuvajOsobaDTO novaOsoba)
        {
            ISession session = null;

            try
            {
                session = DataLayer.GetSession();

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

                foreach (string brojTelefona in novaOsoba.Telefoni)
                {
                    if (brojTelefona.Length != 10) {
                        return new ErrorMessage($"broj: {brojTelefona} nije validan", 400);
                    }
                    var telefon = new Telefon
                    {
                        BrojTelefona = brojTelefona,
                        Osoba = osoba
                    };
                    osoba.Telefoni.Add(telefon);
                }

                await session.SaveAsync(osoba);
                await session.FlushAsync();

                return osoba.JMBG;
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

        public static async Task<Result<bool, ErrorMessage>> ObrisiOsobuAsync(string jmbg)
        {
            ISession session = null;

            try
            {
                session = DataLayer.GetSession();

                var osoba = await session.Query<Osoba>()
                    .FirstOrDefaultAsync(o => o.JMBG == jmbg);

                if (osoba == null)
                    return new ErrorMessage($"Osoba sa tim JMBG-om nije pronađena.", 404);

                if (!NHibernateUtil.IsInitialized(osoba.Telefoni))
                    await NHibernateUtil.InitializeAsync(osoba.Telefoni);


                await session.DeleteAsync(osoba);
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


        public static async Task<Result<List<OsobaDTO>, ErrorMessage>> PrikaziSveOsobeAsync()
        {
            List<OsobaDTO> osobe = new List<OsobaDTO>();
            ISession? session = null;
            try
            {
                session = DataLayer.GetSession();
                var result = await session.Query<Osoba>().Fetch(o => o.Telefoni).ToListAsync();


                foreach (var osoba in result)
                {
                    if (!NHibernateUtil.IsInitialized(osoba.Telefoni))
                    {
                        await NHibernateUtil.InitializeAsync(osoba.Telefoni);
                    }
                }

                osobe = result.Select(o => new OsobaDTO(
                    o.JMBG,
                    o.Ime,
                    o.Prezime,
                    o.Adresa,
                    o.Mail,
                    string.Join(",", o.Telefoni.Select(t => t.BrojTelefona))
                )).ToList();
                return osobe;
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

        public static async Task<Result<bool, ErrorMessage>> IzmeniOsobuAsync(OsobaBasic novaOsoba)
        {
            ISession session = null;
            ITransaction transaction = null;

            try
            {
                session = DataLayer.GetSession();
                transaction = session.BeginTransaction();

                var osoba = await session.LoadAsync<Osoba>(novaOsoba.JMBG);
                if (osoba == null)
                {
                    return new ErrorMessage($"Osoba nije pronađena.", 404);
                }

                if (!NHibernateUtil.IsInitialized(osoba.Telefoni))
                {
                    await NHibernateUtil.InitializeAsync(osoba.Telefoni);
                }
                foreach (var telefon in osoba.Telefoni.ToList())
                {
                    await session.DeleteAsync(telefon);
                }
                osoba.Telefoni.Clear();

                foreach (var item in novaOsoba.Telefoni)
                {
                    osoba.Telefoni.Add(new Telefon
                    {
                        BrojTelefona = item.BrojTelefona,
                        Osoba = osoba
                    });
                }

                osoba.Ime = novaOsoba.Ime;
                osoba.Prezime = novaOsoba.Prezime;
                osoba.Adresa = novaOsoba.Adresa;
                osoba.Mail = novaOsoba.Mail;

                await session.UpdateAsync(osoba);
                await session.FlushAsync();

                await transaction.CommitAsync();

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

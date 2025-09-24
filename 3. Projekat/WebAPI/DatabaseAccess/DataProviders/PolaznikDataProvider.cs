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
        public static async Task<Result<List<PolaznikDTO>, ErrorMessage>> VratiPolaznikeAsync()
        {
            ISession session = null;

            try
            {
                session = DataLayer.GetSession();

                var polaznici = await session.Query<Polaznik>()
                    .Fetch(p => p.Osoba)
                    .ThenFetchMany(o => o.Telefoni)
                    .ToListAsync();

                polaznici = polaznici.Distinct().ToList();

                var polaznikDTOs = polaznici.Select(n => new PolaznikDTO(
                    n.Id,
                    n.Osoba.JMBG,
                    n.Osoba.Ime,
                    n.Osoba.Prezime,
                    n.Osoba.Adresa,
                    n.Osoba.Mail,
                    string.Join(", ", n.Osoba.Telefoni.Select(t => t.BrojTelefona))
                )).ToList();

                return polaznikDTOs;
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
            int? starateljIdZaProveru = null;
            ISession session = null;
            ITransaction transaction = null;

            try
            {
                session = DataLayer.GetSession();
                transaction = session.BeginTransaction();

                var polaznik = await session.GetAsync<Polaznik>(polaznikId);
                if (polaznik == null)
                    return new ErrorMessage($"Polaznik nije pronađen.", 404);

                var pohadjanja = await session.Query<Pohadja>()
                    .Where(p => p.Polaznik.Id == polaznikId)
                    .ToListAsync();
                foreach (var p in pohadjanja)
                    await session.DeleteAsync(p);

                var polaganja = await session.Query<Polaganje>()
                    .Where(p => p.Polaznik.Id == polaznikId)
                    .ToListAsync();
                foreach (var p in polaganja)
                    await session.DeleteAsync(p);

                var odrasli = await session.Query<Odrasli>()
                    .FirstOrDefaultAsync(o => o.Polaznik.Id == polaznikId);
                if (odrasli != null)
                    await session.DeleteAsync(odrasli);

                var dete = await session.Query<Dete>()
                    .FirstOrDefaultAsync(d => d.Polaznik.Id == polaznikId);
                if (dete != null)
                {
                    starateljIdZaProveru = dete.Staratelj.Id;
                    await session.DeleteAsync(dete);
                }

                await session.DeleteAsync(polaznik);

                var osoba = polaznik.Osoba;
                if (osoba != null)
                {
                    foreach (var telefon in osoba.Telefoni.ToList())
                        await session.DeleteAsync(telefon);

                    await session.DeleteAsync(osoba);
                }

                await transaction.CommitAsync();
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


            if (starateljIdZaProveru.HasValue)
            {
                ISession session2 = null;
                ITransaction transaction2 = null;
                try
                {
                    session2 = DataLayer.GetSession();
                    transaction2 = session2.BeginTransaction();

                    int id = starateljIdZaProveru.Value;
                    var brojPreostaleDece = await session2.Query<Dete>()
                        .CountAsync(d => d.Staratelj.Id == id);

                    if (brojPreostaleDece == 0)
                    {
                        var starateljZaBrisanje = await session2.GetAsync<Staratelj>(id);
                        if (starateljZaBrisanje != null)
                            await session2.DeleteAsync(starateljZaBrisanje);
                    }

                    await transaction2.CommitAsync();
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

            return true;
        }


        public static async Task<Result<bool, ErrorMessage>> IzmeniPolaznikaAsync(PolaznikDTO podaci)
        {
            ISession session = null;
            ITransaction transaction = null;

            try
            {
                session = DataLayer.GetSession();
                transaction = session.BeginTransaction();

                var polaznikIzBaze = await session.GetAsync<Polaznik>(podaci.Id);
                var osobaIzBaze = await session.GetAsync<Osoba>(podaci.JMBG);

                if (polaznikIzBaze == null || osobaIzBaze == null)
                    return new ErrorMessage("Polaznik ili osoba nisu pronađeni u bazi.", 404);

                osobaIzBaze.Ime = podaci.Ime;
                osobaIzBaze.Prezime = podaci.Prezime;
                osobaIzBaze.Adresa = podaci.Adresa;
                osobaIzBaze.Mail = podaci.Mail;

                osobaIzBaze.Telefoni.Clear();
                await session.FlushAsync();

                string[] noviTelefoni = podaci.Telefoni.Split(';');
                foreach (var broj in noviTelefoni)
                {
                    if (!string.IsNullOrWhiteSpace(broj))
                    {
                        osobaIzBaze.Telefoni.Add(new Telefon { BrojTelefona = broj, Osoba = osobaIzBaze });
                    }
                }

                if (podaci is DeteDTO detePodaci)
                {
                    var deteIzBaze = await session.Query<Dete>()
                        .FirstOrDefaultAsync(d => d.Polaznik.Id == podaci.Id);

                    if (deteIzBaze != null)
                    {
                        deteIzBaze.DatumRodjenja = detePodaci.DatumRodjenja;
                        deteIzBaze.BrojDosijea = detePodaci.BrojDosijea;

                        if (deteIzBaze.Staratelj.Id != detePodaci.Staratelj.Id)
                        {
                            deteIzBaze.Staratelj = await session.LoadAsync<Staratelj>(detePodaci.Staratelj.Id);
                        }

                        await session.UpdateAsync(deteIzBaze);
                    }
                }
                else if (podaci is OdrasliDTO odrasliPodaci)
                {
                    var odrasliIzBaze = await session.Query<Odrasli>()
                        .FirstOrDefaultAsync(o => o.Polaznik.Id == podaci.Id);

                    if (odrasliIzBaze != null)
                    {
                        odrasliIzBaze.Zanimanje = odrasliPodaci.Zanimanje;
                        await session.UpdateAsync(odrasliIzBaze);
                    }
                }

                await session.UpdateAsync(osobaIzBaze);
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


        public static async Task<Result<int, ErrorMessage>> DodajPolaznikaAsync(OsobaBasic novaOsoba)
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
                    return new ErrorMessage("Osoba sa tim JMBG-om već postoji!", 400);

                var osoba = new Osoba
                {
                    JMBG = novaOsoba.JMBG,
                    Ime = novaOsoba.Ime,
                    Prezime = novaOsoba.Prezime,
                    Adresa = novaOsoba.Adresa,
                    Mail = novaOsoba.Mail
                };

                foreach (var tel in novaOsoba.Telefoni)
                {
                    osoba.Telefoni.Add(new Telefon { BrojTelefona = tel.BrojTelefona, Osoba = osoba });
                }

                var polaznik = new Polaznik
                {
                    Osoba = osoba
                };

                await session.SaveAsync(osoba);
                await session.SaveAsync(polaznik);

                await transaction.CommitAsync();

                return polaznik.Id;
            }
            catch (Exception ex)
            {
                if (transaction != null) await transaction.RollbackAsync();
                return new ErrorMessage("Greška prilikom dodavanja polaznika: " + ex.Message, 500);
            }
            finally
            {
                session?.Close();
                session?.Dispose();
            }
        }

    }
}

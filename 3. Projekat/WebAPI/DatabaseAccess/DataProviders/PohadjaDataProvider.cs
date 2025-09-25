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
    public static class PohadjaDataProvider
    {
        public static async Task<Result<PohadjaDTO, ErrorMessage>> SacuvajPohadjaAsync(int polaznikId, int kursId)
        {
            ISession session = null;

            try
            {
                session = DataLayer.GetSession();

                var polaznik = await session.GetAsync<Polaznik>(polaznikId);
                if (polaznik == null)
                    return new ErrorMessage($"Polaznik nije pronađen.", 404);

                var kurs = await session.GetAsync<Kurs>(kursId);
                if (kurs == null)
                    return new ErrorMessage($"Kurs nije pronađen.", 404);

                var pohadja = new Pohadja
                {
                    Polaznik = polaznik,
                    Kurs = kurs
                };

                await session.SaveAsync(pohadja);
                await session.FlushAsync();

                PohadjaDTO pohadjaDto = new PohadjaDTO(pohadja.Id, pohadja.Polaznik, pohadja.Kurs);

                return pohadjaDto;
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
        public static async Task<Result<List<PolaznikDTO>, ErrorMessage>> NadjiPolaznikeZaKursDTOAsync(string kursId)
    {
        ISession session = null;

        try
        {
            session = DataLayer.GetSession();

            var polaznici = await session.Query<Pohadja>()
                .Fetch(p => p.Polaznik)
                .ThenFetch(p => p.Osoba)
                .ThenFetchMany(o => o.Telefoni)
                .Where(p => p.Kurs.Id == kursId)
                .ToListAsync();

            var polaznikDTOs = polaznici.Select(p => new PolaznikDTO(
                p.Polaznik.Id,
                p.Polaznik.Osoba.JMBG,
                p.Polaznik.Osoba.Ime,
                p.Polaznik.Osoba.Prezime,
                p.Polaznik.Osoba.Adresa,
                p.Polaznik.Osoba.Mail,
                string.Join(", ", p.Polaznik.Osoba.Telefoni.Select(t => t.BrojTelefona))
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


    public static async Task<Result<bool, ErrorMessage>> ObrisiPohadjaAsync(int pohadjaId)
        {
            ISession session = null;

            try
            {
                session = DataLayer.GetSession();

                var pohadja = await session.GetAsync<Pohadja>(pohadjaId);
                if (pohadja == null)
                    return new ErrorMessage($"Pohadjanje nije pronadjeno", 404);

                await session.DeleteAsync(pohadja);
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

        public static async Task<Result<bool, ErrorMessage>> IzmeniPohadjaAsync(int pohadjaId, int noviPolaznikId, int noviKursId)
        {
            ISession session = null;

            try
            {
                session = DataLayer.GetSession();

                var pohadja = await session.GetAsync<Pohadja>(pohadjaId);
                if (pohadja == null)
                    return new ErrorMessage($"Pohadjanje nije pronađena.", 404);

                var noviPolaznik = await session.GetAsync<Polaznik>(noviPolaznikId);
                if (noviPolaznik == null)
                    return new ErrorMessage($"Polaznik nije pronađen.", 404);

                var noviKurs = await session.GetAsync<Kurs>(noviKursId);
                if (noviKurs == null)
                    return new ErrorMessage($"Kurs nije pronađen.", 404);

                pohadja.Polaznik = noviPolaznik;
                pohadja.Kurs = noviKurs;

                await session.UpdateAsync(pohadja);
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

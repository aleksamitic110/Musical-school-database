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
    public static class PolaganjeDataProvider
    {
        
        public static async Task<Result<List<PolaganjeDTO>, ErrorMessage>> VratiPolaznikeKojiSuPolagaliIspitAsync(string ispitId)
    {
        ISession session = null;

        try
        {
            session = DataLayer.GetSession();

            var polazanja = await session.Query<Polaganje>()
                .Fetch(p => p.Polaznik)
                .ThenFetch(p => p.Osoba)
                .Fetch(p => p.Ispit)
                .ThenFetch(i => i.Kurs)
                .Where(po => po.Ispit.Id == ispitId && po.Ocena == 0)
                .ToListAsync();

            var polazniciDTO = polazanja.Select(po => new PolaganjeDTO(
                po.Id,
                po.Polaznik.Osoba.JMBG,
                po.Polaznik.Osoba.Ime,
                po.Polaznik.Osoba.Prezime,
                po.Ispit.Kurs.Naziv,
                po.Ispit.Datum,
                po.Ocena,
                po.Polozio
            )).ToList();

            return polazniciDTO;
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
        
        public static async Task<Result<bool, ErrorMessage>> OceniPolaganjePolaznikaAsync(int polaganjeId, bool polozio, int ocena)
    {
        ISession session = null;

        try
        {
            session = DataLayer.GetSession();

            var polaganje = await session.GetAsync<Polaganje>(polaganjeId);
            if (polaganje == null)
                return new ErrorMessage($"Polaganje nije pronađeno.", 404);

            polaganje.Polozio = polozio;
            polaganje.Ocena = ocena;

            await session.UpdateAsync(polaganje);
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
        
        public static async Task<Result<bool, ErrorMessage>> DodajPolaganjeAsync(List<int> polaznikIds, string ispitId)
    {
        ISession session = null;

        try
        {
            session = DataLayer.GetSession();

            var ispit = await session.GetAsync<Ispit>(ispitId);
            if (ispit == null)
                return new ErrorMessage($"Ispit nije pronađen.", 404);

            foreach (int polaznikId in polaznikIds)
            {
                var polaznik = await session.GetAsync<Polaznik>(polaznikId);
                if (polaznik == null)
                    return new ErrorMessage($"Polaznik nije pronađen.", 404);

                var polaganje = new Polaganje
                {
                    Polaznik = polaznik,
                    Ispit = ispit
                };

                ispit.Polaganja.Add(polaganje);
                await session.SaveAsync(polaganje);
            }

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


        public static async Task<Result<bool, ErrorMessage>> ObrisiPolaganjeAsync(int polaganjeId)
        {
            ISession session = null;

            try
            {
                session = DataLayer.GetSession();

                var polaganje = await session.GetAsync<Polaganje>(polaganjeId);
                if (polaganje == null)
                    return new ErrorMessage($"Polaganje nije pronađeno.", 404);

                await session.DeleteAsync(polaganje);
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

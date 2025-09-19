using Muzicka_skola.Entiteti;
using MuzickaSkola;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseAccess.DTOs;
using NHibernate.Linq;

namespace DatabaseAccess.DataProviders
{
    public static class NastavnikDataProvider
    {
        public static async Task<Result<List<NastavnikDTO>, ErrorMessage>> PrikaziSveNastavnike()
        {
            List<NastavnikDTO> nastavnici = new List<NastavnikDTO>();
            ISession? session = null;
            try
            {
                session = DataLayer.GetSession();
                var result = await session.Query<Nastavnik>().Fetch(n => n.Osoba).ThenFetchMany(o => o.Telefoni).ToListAsync();

      
                foreach (var nastavnik in result)
                {
                    if (!NHibernateUtil.IsInitialized(nastavnik.Osoba.Telefoni))
                    {
                        await NHibernateUtil.InitializeAsync(nastavnik.Osoba.Telefoni);
                    }
                }

                nastavnici = result.Select(n => new NastavnikDTO(
                    n.Osoba.JMBG,
                    n.Osoba.Ime,
                    n.Osoba.Prezime,
                    n.Osoba.Adresa,
                    n.Osoba.Mail,
                    string.Join(",", n.Osoba.Telefoni.Select(t => t.BrojTelefona)),
                    n.Id,
                    n.StrucnaSprema,
                    n.DatumZaposlenja.Date
                )).ToList();
                return nastavnici;
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

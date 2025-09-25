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
    public static class KomisijaDataProvider
    {
		#region GET Metode

		public static async Task<Result<List<KomisijaDTO>, ErrorMessage>> VratiSveKomisijeAsync()
		{
			ISession session = null;
			try
			{
				session = DataLayer.GetSession();
				var komisije = await session.Query<Komisija>()
					.Select(k => new KomisijaDTO
					{
						Id = k.Id,
						NastavnikId = k.Nastavnik.Id,
						IspitId = k.Ispit.Id,
						NastavnikImePrezime = k.Nastavnik.Osoba.Ime + " " + k.Nastavnik.Osoba.Prezime,
						IspitKursNaziv = k.Ispit.Kurs.Naziv
					})
					.ToListAsync();
				return komisije;
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

	
		public static async Task<Result<List<NastavnikDTO>, ErrorMessage>> VratiKomisijuZaIspitAsync(string ispitId)
		{
			ISession session = null;
			try
			{
				session = DataLayer.GetSession();
				var nastavnici = await session.Query<Komisija>()
					.Where(k => k.Ispit.Id == ispitId)
					.Select(k => k.Nastavnik) 
					.Select(n => new NastavnikDTO 
					{
						Id = n.Id,
						JMBG = n.Osoba.JMBG,
						Ime = n.Osoba.Ime,
						Prezime = n.Osoba.Prezime,
						Adresa = n.Osoba.Adresa,
						Mail = n.Osoba.Mail,
						Telefoni = string.Join(";", n.Osoba.Telefoni.Select(t => t.BrojTelefona)),
						StrucnaSprema = n.StrucnaSprema,
						DatumZaposlenja = n.DatumZaposlenja
					})
					.ToListAsync();
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

		#endregion

		#region POST/CREATE Metoda

		public static async Task<Result<int, ErrorMessage>> DodajClanaKomisijeAsync(KomisijaDTO novaVeza)
		{
			ISession session = null;
			ITransaction transaction = null;
			try
			{
				session = DataLayer.GetSession();
				transaction = session.BeginTransaction();

				var nastavnik = await session.GetAsync<Nastavnik>(novaVeza.NastavnikId);
				if (nastavnik == null) return new ErrorMessage("Nastavnik ne postoji.", 400);

				var ispit = await session.GetAsync<Ispit>(novaVeza.IspitId);
				if (ispit == null) return new ErrorMessage("Ispit ne postoji.", 400);

				
				bool postoji = await session.Query<Komisija>().AnyAsync(k => k.Nastavnik.Id == novaVeza.NastavnikId && k.Ispit.Id == novaVeza.IspitId);
				if (postoji) return new ErrorMessage("Ovaj nastavnik je već član komisije za dati ispit.", 409); // 409 Conflict

				var komisija = new Komisija { Nastavnik = nastavnik, Ispit = ispit };

				await session.SaveAsync(komisija);
				await transaction.CommitAsync();

				return komisija.Id;
			}
			catch (Exception ex)
			{
				await transaction?.RollbackAsync();
				return new ErrorMessage(ex.Message, 500);
			}
			finally
			{
				transaction?.Dispose(); session?.Close(); session?.Dispose();
			}
		}

        #endregion

        #region Put
        public static async Task<Result<bool, ErrorMessage>> IzmeniClanaKomisijeAsync(int komisijaId, KomisijaDTO izmenaVeze)
        {
            ISession session = null;
            ITransaction transaction = null;

            try
            {
                session = DataLayer.GetSession();
                transaction = session.BeginTransaction();

                var komisija = await session.GetAsync<Komisija>(komisijaId);
                if (komisija == null)
                    return new ErrorMessage($"Komisija sa Id={komisijaId} nije pronađena.", 404);

                var nastavnik = await session.GetAsync<Nastavnik>(izmenaVeze.NastavnikId);
                if (nastavnik == null)
                    return new ErrorMessage("Nastavnik ne postoji.", 400);

                var ispit = await session.GetAsync<Ispit>(izmenaVeze.IspitId);
                if (ispit == null)
                    return new ErrorMessage("Ispit ne postoji.", 400);

                komisija.Nastavnik = nastavnik;
                komisija.Ispit = ispit;

                await session.UpdateAsync(komisija);
                await transaction.CommitAsync();

                return true;
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

        #endregion

        #region DELETE Metoda


        public static async Task<Result<bool, ErrorMessage>> ObrisiClanaKomisijeAsync(int komisijaId)
		{
			ISession session = null;
			ITransaction transaction = null;
			try
			{
				session = DataLayer.GetSession();
				transaction = session.BeginTransaction();

				var komisija = await session.GetAsync<Komisija>(komisijaId);
				if (komisija == null) return new ErrorMessage("Zapis u komisiji nije pronađen.", 404);

				await session.DeleteAsync(komisija);
				await transaction.CommitAsync();

				return true;
			}
			catch (Exception ex)
			{
				await transaction?.RollbackAsync();
				return new ErrorMessage(ex.Message, 500);
			}
			finally
			{
				transaction?.Dispose(); session?.Close(); session?.Dispose();
			}
		}

		#endregion
	}
}

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
    public static class IspitDataProvider
    {
		#region GET Metode

		public static async Task<Result<List<IspitDTO>, ErrorMessage>> VratiSveIspiteAsync()
		{
			ISession session = null;
			try
			{
				session = DataLayer.GetSession();

				
				var ispitiEntities = await session.Query<Ispit>()
					.Fetch(i => i.Kurs)
					.FetchMany(i => i.Komisija)
					.ThenFetch(k => k.Nastavnik)
					.ThenFetch(n => n.Osoba)
					.ToListAsync();

				
				await session.Query<Polaganje>()
					.Where(p => ispitiEntities.Contains(p.Ispit)) // Dohvati samo za ispite koje smo već našli
					.Fetch(p => p.Polaznik) // Opciono, ako ti trebaju podaci o polazniku
					.ToListAsync();

				
				var ispitiDto = new List<IspitDTO>();
				foreach (var i in ispitiEntities)
				{
					var komisijaStr = string.Join(", ", i.Komisija.Select(k => $"{k.Nastavnik.Osoba.Ime} {k.Nastavnik.Osoba.Prezime}"));

					var polozenaPolaganja = i.Polaganja.Where(p => p.Polozio);
					double prosecnaOcena = polozenaPolaganja.Any() ? polozenaPolaganja.Average(p => p.Ocena) : 0;

					ispitiDto.Add(new IspitDTO
					{
						Id = i.Id,
						KursId = i.Kurs.Id,
						KursNaziv = i.Kurs.Naziv,
						Datum = i.Datum,
						Komisija = komisijaStr,
						ProsecnaOcena = prosecnaOcena
					});
				}

				return ispitiDto;
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

		public static async Task<Result<List<PolaznikDTO>, ErrorMessage>> VratiPolaznikeKojiNePolazuAsync(string ispitId)
		{
			ISession session = null;
			try
			{
				session = DataLayer.GetSession();
			
				var ispit = await session.GetAsync<Ispit>(ispitId);
				if (ispit == null)
					return new ErrorMessage("Ispit sa datim ID-jem ne postoji.", 404);

			
				var sviPolazniciNaKursuIds = await session.Query<Pohadja>()
													 .Where(p => p.Kurs.Id == ispit.Kurs.Id)
													 .Select(p => p.Polaznik.Id)
													 .ToListAsync();

				
				var polazniciKojiPolazuIds = await session.Query<Polaganje>()
													  .Where(p => p.Ispit.Id == ispitId)
													  .Select(p => p.Polaznik.Id)
													  .ToListAsync();

				
				var kandidatiIds = sviPolazniciNaKursuIds.Except(polazniciKojiPolazuIds);

				var polaznici = await session.Query<Polaznik>()
					.Where(p => kandidatiIds.Contains(p.Id))
					.Select(p => new PolaznikDTO
					{
						Id = p.Id,
						JMBG = p.Osoba.JMBG,
						Ime = p.Osoba.Ime,
						Prezime = p.Osoba.Prezime,
						Adresa = p.Osoba.Adresa,
						Mail = p.Osoba.Mail,
						Telefoni = string.Join(";", p.Osoba.Telefoni.Select(t => t.BrojTelefona))
					})
					.ToListAsync();

				return polaznici;
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

		public static async Task<Result<string, ErrorMessage>> DodajIspitAsync(IspitBasic noviIspit)
		{
			ISession session = null;
			ITransaction transaction = null;
			try
			{
				session = DataLayer.GetSession();
				transaction = session.BeginTransaction();

				var kurs = await session.GetAsync<Kurs>(noviIspit.KursId);
				if (kurs == null) return new ErrorMessage("Kurs nije pronađen.", 400);

				var ispit = new Ispit { Id = noviIspit.Id, Kurs = kurs, Datum = noviIspit.Datum, Komisija = new List<Komisija>() };

				var nastavnici = await session.Query<Nastavnik>().Where(n => noviIspit.NastavnikIds.Contains(n.Id)).ToListAsync();
				foreach (var nastavnik in nastavnici)
				{
					ispit.Komisija.Add(new Komisija { Nastavnik = nastavnik, Ispit = ispit });
				}

				await session.SaveAsync(ispit);
				await transaction.CommitAsync();

				return ispit.Id;
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

		#region PUT/UPDATE Metoda

		public static async Task<Result<bool, ErrorMessage>> IzmeniIspitAsync(IspitBasic podaci)
		{
			ISession session = null;
			ITransaction transaction = null;
			try
			{
				session = DataLayer.GetSession();
				transaction = session.BeginTransaction();

				var ispit = await session.GetAsync<Ispit>(podaci.Id);
				if (ispit == null) return new ErrorMessage("Ispit nije pronađen.", 404);

				ispit.Datum = podaci.Datum;

				
				ispit.Komisija.Clear();
				await session.FlushAsync();

				var nastavnici = await session.Query<Nastavnik>().Where(n => podaci.NastavnikIds.Contains(n.Id)).ToListAsync();
				foreach (var nastavnik in nastavnici)
				{
					ispit.Komisija.Add(new Komisija { Nastavnik = nastavnik, Ispit = ispit });
				}

				await session.UpdateAsync(ispit);
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

		#region DELETE Metoda

		public static async Task<Result<bool, ErrorMessage>> ObrisiIspitAsync(string ispitId)
		{
			ISession session = null;
			ITransaction transaction = null;
			try
			{
				session = DataLayer.GetSession();
				transaction = session.BeginTransaction();

				var ispit = await session.GetAsync<Ispit>(ispitId);
				if (ispit == null) return new ErrorMessage("Ispit nije pronađen.", 404);

				
				await session.DeleteAsync(ispit);
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

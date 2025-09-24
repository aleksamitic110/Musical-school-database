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
    public static class CasDataProvider
    {
		#region GET Metode
		public static async Task<Result<List<CasDTO>, ErrorMessage>> VratiSveCasoveAsync()
		{
			ISession session = null;
			try
			{
				session = DataLayer.GetSession();
				var casovi = await session.Query<Cas>()
					.Select(c => new CasDTO
					(
						c.Id,
						c.Kurs.Id,
						c.Ucionica.Id,
						c.Datum,
						c.Vreme,
						c.Lekcija
					))
					.ToListAsync();

				return casovi;
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

		public static async Task<Result<CasDTO, ErrorMessage>> NadjiCasAsync(string casId)
		{
			ISession session = null;
			try
			{
				session = DataLayer.GetSession();
				var cas = await session.GetAsync<Cas>(casId);

				if (cas == null)
				{
					return new ErrorMessage("Čas sa datim ID-jem nije pronađen.", 404);
				}

				// Mapiranje entiteta u DTO
				var casDTO = new CasDTO(cas.Id, cas.Kurs.Id, cas.Ucionica.Id, cas.Datum, cas.Vreme, cas.Lekcija);
				return casDTO;
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

		public static async Task<Result<string, ErrorMessage>> DodajCasAsync(CasDTO noviCas)
		{
			ISession session = null;
			ITransaction transaction = null;
			try
			{
				session = DataLayer.GetSession();
				transaction = session.BeginTransaction();

				// Provera da li postoje Kurs i Ucionica na koje se referencira
				var kurs = await session.GetAsync<Kurs>(noviCas.IdKursa);
				if (kurs == null)
				{
					return new ErrorMessage("Kurs sa datim ID-jem ne postoji.", 400); // 400 Bad Request
				}
				var ucionica = await session.GetAsync<Ucionica>(noviCas.IdUcionice);
				if (ucionica == null)
				{
					return new ErrorMessage("Učionica sa datim ID-jem ne postoji.", 400);
				}

				var cas = new Cas
				{
					Id = noviCas.IdCasa,
					Datum = noviCas.Datum,
					Vreme = noviCas.Vreme,
					Lekcija = noviCas.Lekcija,
					Kurs = kurs,
					Ucionica = ucionica
				};

				await session.SaveAsync(cas);
				await transaction.CommitAsync();

				return cas.Id;
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

		#region PUT/UPDATE Metoda
		public static async Task<Result<bool, ErrorMessage>> IzmeniCasAsync(CasDTO podaci)
		{
			ISession session = null;
			ITransaction transaction = null;
			try
			{
				session = DataLayer.GetSession();
				transaction = session.BeginTransaction();

				var cas = await session.GetAsync<Cas>(podaci.IdCasa);
				if (cas == null)
				{
					return new ErrorMessage("Čas sa datim ID-jem ne postoji.", 404);
				}

				// Ažuriramo osnovne podatke
				cas.Datum = podaci.Datum;
				cas.Vreme = podaci.Vreme;
				cas.Lekcija = podaci.Lekcija;

				// Ako se menja kurs, proveravamo da li novi postoji
				if (cas.Kurs.Id != podaci.IdKursa)
				{
					var noviKurs = await session.GetAsync<Kurs>(podaci.IdKursa);
					if (noviKurs == null)
						return new ErrorMessage("Novi kurs sa datim ID-jem ne postoji.", 400);
					cas.Kurs = noviKurs;
				}

				// Ako se menja ucionica, proveravamo da li nova postoji
				if (cas.Ucionica.Id != podaci.IdUcionice)
				{
					var novaUcionica = await session.GetAsync<Ucionica>(podaci.IdUcionice);
					if (novaUcionica == null)
						return new ErrorMessage("Nova učionica sa datim ID-jem ne postoji.", 400);
					cas.Ucionica = novaUcionica;
				}

				await session.UpdateAsync(cas);
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
		public static async Task<Result<bool, ErrorMessage>> ObrisiCasAsync(string casId)
		{
			ISession session = null;
			ITransaction transaction = null;
			try
			{
				session = DataLayer.GetSession();
				transaction = session.BeginTransaction();

				var cas = await session.GetAsync<Cas>(casId);
				if (cas == null)
				{
					return new ErrorMessage("Čas sa datim ID-jem ne postoji.", 404);
				}

				// Zbog Cascade.All() u mapiranju, NHibernate će automatski obrisati
				// i sve povezane evidencije prisustva.
				await session.DeleteAsync(cas);
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
	}
}

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
    public static class EvidencijaDataProvider
    {
		#region GET Metode

		public static async Task<Result<List<EvidencijaDTO>, ErrorMessage>> VratiSveEvidencijeAsync()
		{
			ISession session = null;
			try
			{
				session = DataLayer.GetSession();
				var evidencije = await session.Query<Evidencija>()
					.Select(e => new EvidencijaDTO(
						e.Id,
						e.Ocena,
						e.Prisustvo,
						e.Polaznik.Id,
						e.Cas.Id
					))
					.ToListAsync();
				return evidencije;
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

		public static async Task<Result<EvidencijaDTO, ErrorMessage>> NadjiEvidencijuAsync(int evidencijaId)
		{
			ISession session = null;
			try
			{
				session = DataLayer.GetSession();
				var e = await session.GetAsync<Evidencija>(evidencijaId);
				if (e == null)
				{
					return new ErrorMessage("Evidencija sa datim ID-jem nije pronađena.", 404);
				}
				return new EvidencijaDTO(e.Id, e.Ocena, e.Prisustvo, e.Polaznik.Id, e.Cas.Id);
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

		public static async Task<Result<int, ErrorMessage>> DodajEvidencijuAsync(EvidencijaDTO novaEvidencija)
		{
			ISession session = null;
			ITransaction transaction = null;
			try
			{
				session = DataLayer.GetSession();
				transaction = session.BeginTransaction();

				var polaznik = await session.GetAsync<Polaznik>(novaEvidencija.PolaznikId);
				if (polaznik == null)
					return new ErrorMessage("Polaznik sa datim ID-jem ne postoji.", 400);

				var cas = await session.GetAsync<Cas>(novaEvidencija.CasId);
				if (cas == null)
					return new ErrorMessage("Čas sa datim ID-jem ne postoji.", 400);

				var evidencija = new Evidencija
				{
					Ocena = novaEvidencija.Ocena,
					Prisustvo = novaEvidencija.Prisustvo,
					Polaznik = polaznik,
					Cas = cas
				};

				await session.SaveAsync(evidencija);
				await transaction.CommitAsync();

				return evidencija.Id;
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

		public static async Task<Result<bool, ErrorMessage>> IzmeniEvidencijuAsync(EvidencijaDTO podaci)
		{
			ISession session = null;
			ITransaction transaction = null;
			try
			{
				session = DataLayer.GetSession();
				transaction = session.BeginTransaction();

				var evidencija = await session.GetAsync<Evidencija>(podaci.Id);
				if (evidencija == null)
				{
					return new ErrorMessage("Evidencija sa datim ID-jem ne postoji.", 404);
				}

				evidencija.Ocena = podaci.Ocena;
				evidencija.Prisustvo = podaci.Prisustvo;


				await session.UpdateAsync(evidencija);
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

		public static async Task<Result<bool, ErrorMessage>> ObrisiEvidencijuAsync(int evidencijaId)
		{
			ISession session = null;
			ITransaction transaction = null;
			try
			{
				session = DataLayer.GetSession();
				transaction = session.BeginTransaction();

				var evidencija = await session.GetAsync<Evidencija>(evidencijaId);
				if (evidencija == null)
				{
					return new ErrorMessage("Evidencija sa datim ID-jem ne postoji.", 404);
				}

				await session.DeleteAsync(evidencija);
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

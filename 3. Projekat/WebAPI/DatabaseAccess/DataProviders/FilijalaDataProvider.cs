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
    public static class FilijalaDataProvider
    {
		#region GET Metode

		public static async Task<Result<List<FilijalaDTO>, ErrorMessage>> VratiSveFilijaleAsync()
		{
			ISession session = null;
			try
			{
				session = DataLayer.GetSession();
				var filijale = await session.Query<Filijala>()
					.Select(f => new FilijalaDTO(
						f.Id,
						f.Adresa,
						f.RadnoVreme,
						f.OpremljenostUcionica,
						f.KapacitetFilijale
					))
					.ToListAsync();
				return filijale;
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

		public static async Task<Result<FilijalaDTO, ErrorMessage>> NadjiFilijaluAsync(string filijalaId)
		{
			ISession session = null;
			try
			{
				session = DataLayer.GetSession();
				var f = await session.GetAsync<Filijala>(filijalaId);
				if (f == null)
				{
					return new ErrorMessage("Filijala sa datim ID-jem nije pronađena.", 404);
				}
				return new FilijalaDTO(f.Id, f.Adresa, f.RadnoVreme, f.OpremljenostUcionica, f.KapacitetFilijale);
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

		public static async Task<Result<string, ErrorMessage>> DodajFilijaluAsync(FilijalaDTO novaFilijala)
		{
			ISession session = null;
			ITransaction transaction = null;
			try
			{
				session = DataLayer.GetSession();
				transaction = session.BeginTransaction();

				var filijala = new Filijala
				{
					Id = novaFilijala.Id,
					Adresa = novaFilijala.Adresa,
					RadnoVreme = novaFilijala.RadnoVreme,
					OpremljenostUcionica = novaFilijala.OpremljenostUcionica,
					KapacitetFilijale = novaFilijala.KapacitetFilijale
				};

				await session.SaveAsync(filijala);
				await transaction.CommitAsync();

				return filijala.Id;
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

		public static async Task<Result<bool, ErrorMessage>> IzmeniFilijaluAsync(FilijalaDTO podaci)
		{
			ISession session = null;
			ITransaction transaction = null;
			try
			{
				session = DataLayer.GetSession();
				transaction = session.BeginTransaction();

				var filijala = await session.GetAsync<Filijala>(podaci.Id);
				if (filijala == null)
				{
					return new ErrorMessage("Filijala sa datim ID-jem ne postoji.", 404);
				}

				filijala.Adresa = podaci.Adresa;
				filijala.RadnoVreme = podaci.RadnoVreme;
				filijala.OpremljenostUcionica = podaci.OpremljenostUcionica;
				filijala.KapacitetFilijale = podaci.KapacitetFilijale;

				await session.UpdateAsync(filijala);
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

		public static async Task<Result<bool, ErrorMessage>> ObrisiFilijaluAsync(string filijalaId)
		{
			ISession session = null;
			ITransaction transaction = null;
			try
			{
				session = DataLayer.GetSession();
				transaction = session.BeginTransaction();

				var filijala = await session.GetAsync<Filijala>(filijalaId);
				if (filijala == null)
				{
					return new ErrorMessage("Filijala sa datim ID-jem ne postoji.", 404);
				}

				
				await session.DeleteAsync(filijala);
				await transaction.CommitAsync();

				return true;
			}
			catch (Exception ex)
			{
				await transaction?.RollbackAsync();
				
				string errorMessage = ex.Message;
				if (ex.InnerException != null)
				{
					errorMessage += "\n\nInner Exception: " + ex.InnerException.Message;
				}
				return new ErrorMessage(errorMessage, 500);
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

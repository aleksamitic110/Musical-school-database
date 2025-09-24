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
    public static class HonorarniDataProvider
    {
		#region GET Metode

		public static async Task<Result<List<HonorarniDTO>, ErrorMessage>> VratiSveHonorarneAsync()
		{
			ISession session = null;
			try
			{
				session = DataLayer.GetSession();
				var nastavnici = await session.Query<Honorarni>()
					.Select(h => new HonorarniDTO
					{
						
						JMBG = h.Nastavnik.Osoba.JMBG,
						Ime = h.Nastavnik.Osoba.Ime,
						Prezime = h.Nastavnik.Osoba.Prezime,
						Adresa = h.Nastavnik.Osoba.Adresa,
						Mail = h.Nastavnik.Osoba.Mail,
						Telefoni = string.Join(";", h.Nastavnik.Osoba.Telefoni.Select(t => t.BrojTelefona)),
					
						Id = h.Nastavnik.Id,
						StrucnaSprema = h.Nastavnik.StrucnaSprema,
						DatumZaposlenja = h.Nastavnik.DatumZaposlenja,
					
						BrojUgovora = h.BrojUgovora,
						BrojCasovaMesecno = h.BrojCasovaMesecno,
						TrajanjeUgovora = h.TrajanjeUgovora
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

		public static async Task<Result<HonorarniDTO, ErrorMessage>> NadjiHonorarnogAsync(int id)
		{

			ISession session = null;
			try
			{
				session = DataLayer.GetSession();
				var h = await session.GetAsync<Honorarni>(id);
				if (h == null)
				{
					return new ErrorMessage("Honorarni nastavnik sa datim ID-jem nije pronađen.", 404);
				}

				
				await NHibernateUtil.InitializeAsync(h.Nastavnik);
				await NHibernateUtil.InitializeAsync(h.Nastavnik.Osoba);
				await NHibernateUtil.InitializeAsync(h.Nastavnik.Osoba.Telefoni);

				var dto = new HonorarniDTO
				{
					JMBG = h.Nastavnik.Osoba.JMBG,
					Ime = h.Nastavnik.Osoba.Ime,
					Prezime = h.Nastavnik.Osoba.Prezime,
					Adresa = h.Nastavnik.Osoba.Adresa,
					Mail = h.Nastavnik.Osoba.Mail,
					Telefoni = string.Join(";", h.Nastavnik.Osoba.Telefoni.Select(t => t.BrojTelefona)),
					Id = h.Nastavnik.Id,
					StrucnaSprema = h.Nastavnik.StrucnaSprema,
					DatumZaposlenja = h.Nastavnik.DatumZaposlenja,
					BrojUgovora = h.BrojUgovora,
					BrojCasovaMesecno = h.BrojCasovaMesecno,
					TrajanjeUgovora = h.TrajanjeUgovora
				};
				return dto;
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

		public static async Task<Result<int, ErrorMessage>> DodajHonorarnogAsync(HonorarniDTO novi)
		{
			ISession session = null;
			ITransaction transaction = null;
			try
			{
				session = DataLayer.GetSession();
				transaction = session.BeginTransaction();

				var osobaUBazi = await session.GetAsync<Osoba>(novi.JMBG);
				if (osobaUBazi != null)
					return new ErrorMessage("Osoba sa datim JMBG već postoji.", 400);

				var osoba = new Osoba { JMBG = novi.JMBG, Ime = novi.Ime, Prezime = novi.Prezime, Adresa = novi.Adresa, Mail = novi.Mail, Telefoni = new List<Telefon>() };
				string[] telefoni = novi.Telefoni.Split(';');
				foreach (var t in telefoni) { if (!string.IsNullOrWhiteSpace(t)) osoba.Telefoni.Add(new Telefon { BrojTelefona = t.Trim(), Osoba = osoba }); }

				var nastavnik = new Nastavnik { StrucnaSprema = novi.StrucnaSprema, DatumZaposlenja = novi.DatumZaposlenja, Osoba = osoba };
				var honorarni = new Honorarni { BrojUgovora = novi.BrojUgovora, BrojCasovaMesecno = novi.BrojCasovaMesecno, TrajanjeUgovora = novi.TrajanjeUgovora, Nastavnik = nastavnik };

				await session.SaveAsync(osoba);
				await session.SaveAsync(nastavnik);
				await session.SaveAsync(honorarni);
				await transaction.CommitAsync();

				return honorarni.Id;
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

		public static async Task<Result<bool, ErrorMessage>> IzmeniHonorarnogAsync(int id, HonorarniDTO podaci)
		{
			ISession session = null;
			ITransaction transaction = null;
			try
			{
				session = DataLayer.GetSession();
				transaction = session.BeginTransaction();

				var honorarni = await session.GetAsync<Honorarni>(id);
				if (honorarni == null) return new ErrorMessage("Honorarni nastavnik nije pronađen.", 404);

				var nastavnik = honorarni.Nastavnik;
				var osoba = nastavnik.Osoba;

		
				osoba.Ime = podaci.Ime; osoba.Prezime = podaci.Prezime; osoba.Adresa = podaci.Adresa; osoba.Mail = podaci.Mail;
				osoba.Telefoni.Clear();
				await session.FlushAsync();
				string[] telefoni = podaci.Telefoni.Split(';');
				foreach (var t in telefoni) { if (!string.IsNullOrWhiteSpace(t)) osoba.Telefoni.Add(new Telefon { BrojTelefona = t.Trim(), Osoba = osoba }); }

			
				nastavnik.StrucnaSprema = podaci.StrucnaSprema; nastavnik.DatumZaposlenja = podaci.DatumZaposlenja;

				honorarni.BrojUgovora = podaci.BrojUgovora; honorarni.BrojCasovaMesecno = podaci.BrojCasovaMesecno; honorarni.TrajanjeUgovora = podaci.TrajanjeUgovora;

				await session.UpdateAsync(osoba);
				await session.UpdateAsync(nastavnik);
				await session.UpdateAsync(honorarni);
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

		public static async Task<Result<bool, ErrorMessage>> ObrisiHonorarnogAsync(int id)
		{
			ISession session = null;
			ITransaction transaction = null;
			try
			{
				session = DataLayer.GetSession();
				transaction = session.BeginTransaction();

				var honorarni = await session.GetAsync<Honorarni>(id);
				if (honorarni == null) return new ErrorMessage("Honorarni nastavnik nije pronađen.", 404);

	
				var nastavnik = honorarni.Nastavnik;
				var osoba = nastavnik.Osoba;

				
				await NHibernateUtil.InitializeAsync(nastavnik.Kursevi);
				if (nastavnik.Kursevi.Any())
				{
					return new ErrorMessage("Nije moguće obrisati nastavnika jer drži aktivne kurseve.", 400);
				}

				await session.DeleteAsync(honorarni);
				await session.DeleteAsync(nastavnik);

				
				await session.DeleteAsync(osoba);

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

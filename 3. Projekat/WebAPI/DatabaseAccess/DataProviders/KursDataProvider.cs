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
    public static class KursDataProvider
    {
		#region GET Metode

		public static async Task<Result<List<KursDTO>, ErrorMessage>> VratiSveKurseveAsync()
		{
			ISession session = null;
			try
			{
				session = DataLayer.GetSession();
				var kursevi = await session.Query<Kurs>()
					.Select(k => new KursDTO
					{
						Id = k.Id,
						Naziv = k.Naziv,
						Nivo = k.Nivo,
						TipNastave = k.TipNastave,
						Filijala = k.Filijala.Id,
						Nastavnik = k.Nastavnik.Id,
						Instrumenti = (k as KursInstrumentalni).Instrumenti,
						NazivPredmeta = (k as KursTeorijski).NazivPredmeta,
						TipPevanja = (k as KursVokalni).TipPevanja
					})
					.ToListAsync();
				return kursevi;
			}
			catch (Exception ex) { return new ErrorMessage(ex.Message, 500); }
			finally { session?.Close(); session?.Dispose(); }
		}

		public static async Task<Result<List<PolaznikDTO>, ErrorMessage>> VratiPolaznikeKursaAsync(string kursId)
		{
			ISession session = null;
			try
			{
				session = DataLayer.GetSession();
				var polaznici = await session.Query<Pohadja>()
					.Where(p => p.Kurs.Id == kursId)
					.Select(p => p.Polaznik)
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
			catch (Exception ex) { return new ErrorMessage(ex.Message, 500); }
			finally { session?.Close(); session?.Dispose(); }
		}

		#endregion

		#region POST/CREATE Metoda

		public static async Task<Result<string, ErrorMessage>> DodajKursAsync(KursDTO noviKurs)
		{
			ISession session = null;
			ITransaction transaction = null;
			try
			{
				session = DataLayer.GetSession();
				transaction = session.BeginTransaction();

				var filijala = await session.GetAsync<Filijala>(noviKurs.Filijala);
				if (filijala == null) return new ErrorMessage("Filijala ne postoji.", 400);

				var nastavnik = await session.GetAsync<Nastavnik>(noviKurs.Nastavnik);
				if (nastavnik == null) return new ErrorMessage("Nastavnik ne postoji.", 400);

				Kurs kurs;
				if (noviKurs.Instrumenti != null)
				{
					kurs = new KursInstrumentalni { Instrumenti = noviKurs.Instrumenti };
				}
				else if (noviKurs.NazivPredmeta != null)
				{
					kurs = new KursTeorijski { NazivPredmeta = noviKurs.NazivPredmeta };
				}
				else if (noviKurs.TipPevanja != null)
				{
					kurs = new KursVokalni { TipPevanja = noviKurs.TipPevanja };
				}
				else
				{
					return new ErrorMessage("Mora se navesti tip kursa (Instrumenti, NazivPredmeta ili TipPevanja).", 400);
				}

				kurs.Id = noviKurs.Id;
				kurs.Naziv = noviKurs.Naziv;
				kurs.Nivo = noviKurs.Nivo;
				kurs.TipNastave = noviKurs.TipNastave;
				kurs.Filijala = filijala;
				kurs.Nastavnik = nastavnik;

				await session.SaveAsync(kurs);
				await transaction.CommitAsync();

				return kurs.Id;
			}
			catch (Exception ex)
			{
				await transaction?.RollbackAsync();
				return new ErrorMessage(ex.Message, 500);
			}
			finally { transaction?.Dispose(); session?.Close(); session?.Dispose(); }
		}

		#endregion

		#region PUT/UPDATE Metoda

		public static async Task<Result<bool, ErrorMessage>> IzmeniKursAsync(KursDTO podaci)
		{
			ISession session = null;
			ITransaction transaction = null;
			try
			{
				session = DataLayer.GetSession();
				transaction = session.BeginTransaction();

				var kurs = await session.GetAsync<Kurs>(podaci.Id);
				if (kurs == null) return new ErrorMessage("Kurs nije pronađen.", 404);

				kurs.Naziv = podaci.Naziv;
				kurs.Nivo = podaci.Nivo;
				kurs.TipNastave = podaci.TipNastave;

				if (kurs.Filijala.Id != podaci.Filijala)
				{
					var novaFilijala = await session.GetAsync<Filijala>(podaci.Filijala);
					if (novaFilijala == null) return new ErrorMessage("Nova filijala nije pronađena.", 400);
					kurs.Filijala = novaFilijala;
				}
				if (kurs.Nastavnik.Id != podaci.Nastavnik)
				{
					var noviNastavnik = await session.GetAsync<Nastavnik>(podaci.Nastavnik);
					if (noviNastavnik == null) return new ErrorMessage("Novi nastavnik nije pronađen.", 400);
					kurs.Nastavnik = noviNastavnik;
				}

				// Ažuriranje specifičnih polja
				if (kurs is KursInstrumentalni ki) ki.Instrumenti = podaci.Instrumenti;
				else if (kurs is KursTeorijski kt) kt.NazivPredmeta = podaci.NazivPredmeta;
				else if (kurs is KursVokalni kv) kv.TipPevanja = podaci.TipPevanja;

				await session.UpdateAsync(kurs);
				await transaction.CommitAsync();

				return true;
			}
			catch (Exception ex)
			{
				await transaction?.RollbackAsync();
				return new ErrorMessage(ex.Message, 500);
			}
			finally { transaction?.Dispose(); session?.Close(); session?.Dispose(); }
		}

		#endregion

		#region DELETE Metoda

		public static async Task<Result<bool, ErrorMessage>> ObrisiKursAsync(string kursId)
		{
			ISession session = null;
			ITransaction transaction = null;
			try
			{
				session = DataLayer.GetSession();
				transaction = session.BeginTransaction();

				var kurs = await session.GetAsync<Kurs>(kursId);
				if (kurs == null) return new ErrorMessage("Kurs nije pronađen.", 404);

				// Zbog Cascade.All, NHibernate će obrisati sve vezano za kurs (Cas, Ispit, Pohadja)
				await session.DeleteAsync(kurs);
				await transaction.CommitAsync();

				return true;
			}
			catch (Exception ex)
			{
				await transaction?.RollbackAsync();
				return new ErrorMessage(ex.Message, 500);
			}
			finally { transaction?.Dispose(); session?.Close(); session?.Dispose(); }
		}

		#endregion
	}
}

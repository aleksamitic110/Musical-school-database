using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Cfg;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Muzicka_skola.Mapiranja;
using System.Windows.Forms;
namespace Muzicka_skola
{
	class DataLayer
	{
		private static ISessionFactory _factory = null;
		private static object objLock = new object();


		//funkcija na zahtev otvara sesiju
		public static ISession GetSession()
		{
			//ukoliko session factory nije kreiran
			if (_factory == null)
			{
				lock (objLock)
				{
					if (_factory == null)
						_factory = CreateSessionFactory();
				}
			}

			

			return _factory.OpenSession();
		}

		//konfiguracija i kreiranje session factory
		private static ISessionFactory CreateSessionFactory()
		{
			try
			{
				var cfg = OracleManagedDataClientConfiguration.Oracle10
				.ShowSql()
				.ConnectionString(c =>
					c.Is("Data Source=gislab-oracle.elfak.ni.ac.rs:1521/SBP_PDB;User Id=S19252;Password=Aleksa03"));


				return Fluently.Configure()
					.Database(cfg)
					.Mappings(m => m.FluentMappings.AddFromAssemblyOf<OsobaMap>())
					.BuildSessionFactory();
			}
			catch (Exception ex)
			{
				var sb = new StringBuilder();

				sb.AppendLine("❌ Greska pri kreiranju SessionFactory:");
				sb.AppendLine(ex.Message);

				Exception inner = ex.InnerException;
				while (inner != null)
				{
					sb.AppendLine("➡ InnerException:");
					sb.AppendLine(inner.Message);
					inner = inner.InnerException;
				}

				if (ex is NHibernate.HibernateException hEx && hEx.Data.Contains("PotentialReasons"))
				{
					sb.AppendLine("💡 Moguci razlozi:");
					foreach (var reason in (IEnumerable<string>)hEx.Data["PotentialReasons"])
					{
						sb.AppendLine(" - " + reason);
					}
				}

				MessageBox.Show(sb.ToString(), "NHibernate Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}



		}
	}
}

using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;

namespace MuzickaSkola;

public static class DataLayer
{
    private static ISessionFactory? _factory = null;
    private static readonly object objLock = new();

    public static ISession? GetSession()
    {
        if (_factory == null)
        {
            lock (objLock)
            {
                _factory ??= CreateSessionFactory();
            }
        }

        return _factory?.OpenSession();
    }

    private static ISessionFactory? CreateSessionFactory()
    {
        try
        {
            var cfg = OracleManagedDataClientConfiguration.Oracle10
                        .ShowSql()
                        .ConnectionString(c =>
                            c.Is("Data Source=gislab-oracle.elfak.ni.ac.rs:1521/SBP_PDB;User Id=S19252;Password=Aleksa03"));

            return Fluently.Configure()
                .Database(cfg)
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                .BuildSessionFactory();
        }
        catch (Exception e)
        {
            string error = e.HandleError();

            return null;
        }
    }
}

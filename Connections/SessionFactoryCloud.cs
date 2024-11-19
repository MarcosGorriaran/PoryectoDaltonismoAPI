using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Cfg;
using NHibernate;

namespace cat.itb.M6UF2EA3.connections
{
    public class SessionFactoryCloudzt

    {
        private SessionFactoryCloudzt() { }
        private static string ConnectionString = "Server=tyke.db.elephantsql.com;Port=5432;Database=ipnnzuuj;User Id=ipnnzuuj;Password=z-VCsCRQ6Xo8S3aVf6UKX7xSjCOKKVJR;";
        private static ISessionFactory session;

        private static ISessionFactory CreateSession<T>()
        {
            if (session != null)
                return session;

            IPersistenceConfigurer configDB = PostgreSQLConfiguration.PostgreSQL82.ConnectionString(ConnectionString);
            var configMap =
                Fluently.Configure().Database(configDB).Mappings(
                    c => c.FluentMappings.AddFromAssemblyOf<T>());

            session = configMap.BuildSessionFactory();

            return session;
        }

        public static NHibernate.ISession Open<T>()
        {
            return CreateSession<T>().OpenSession();
        }
    }
}

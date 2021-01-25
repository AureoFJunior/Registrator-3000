using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientReg
{
    class NhibernateFactory
    {
        private static String ConnectionString = "Server=localhost; Port=5432;" +
            " User Id=postgres; Password=123456; Database=Cadastros";

        private static ISessionFactory session;

        public static ISessionFactory createSec()
        {
            if (session != null)
                return session;

            IPersistenceConfigurer configDB = PostgreSQLConfiguration.PostgreSQL82.ConnectionString(ConnectionString);

            var configMap = Fluently.Configure().Database(configDB).Mappings(t => t.FluentMappings.AddFromAssemblyOf<ClientReg.ClienteMap>());

            session = configMap.BuildSessionFactory();

            return session;
        }

        public static ISession openSec()
        {
            return createSec().OpenSession();
        }

    }



}

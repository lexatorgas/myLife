using System.Configuration;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using LifeCore.Models;
using NHibernate;

namespace LifeCore.Nhibernate
{
    public class NhibernateHelper
    {
        public static ISessionFactory BuildSessionFactory()
        {
            return Fluently.Configure()
                .Database(MySQLConfiguration.Standard
                    .ConnectionString("Server=localhost;Database=test;Uid=root;Pwd=root;"))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Test>())
                .CurrentSessionContext("call")
                .BuildSessionFactory();
        }

        public static ISession OpenSession()
        {
            return BuildSessionFactory().OpenSession();
        }
    }
}

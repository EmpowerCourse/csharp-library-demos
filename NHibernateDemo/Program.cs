using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Linq;
using NHibernateDemo.Mappings;
using NHibernateDemo.Models;

var connectionString = "Data Source=.\\SQLEXPRESS;Database=Demo;Trusted_Connection=yes;";

var sessionFactory = Fluently.Configure()
    .Database(MsSqlConfiguration.MsSql2012
        .ShowSql()
        .FormatSql()
        .ConnectionString(p => p.Is(connectionString)
        )
        .AdoNetBatchSize(20)
        .DefaultSchema("dbo"))
    .ExposeConfiguration(c => c.SetProperty(NHibernate.Cfg.Environment.CommandTimeout, "300"))
    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CustomerMap>())
    .BuildSessionFactory();


using (var session = sessionFactory.OpenSession())
{
}
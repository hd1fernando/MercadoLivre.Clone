using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using MercadoLivre.Clone.Data.Mappigins;

namespace MercadoLivre.Clone.Api.Extensions;

public static class NHibernateExtensions
{
    public static IServiceCollection AddNHibernate(this IServiceCollection service, string connectionString)
    {
        var sessionFactory = Fluently.Configure()
            .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connectionString)
                .ShowSql()
                .FormatSql())
            .Mappings(m => m.FluentMappings.AddFromAssembly(typeof(CategoryEntityMap).Assembly))
            .BuildSessionFactory();

        service.AddScoped(factory =>
        {
            return sessionFactory.OpenSession();
        });

        return service;
    }
}

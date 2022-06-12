using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using MercadoLivre.Clone.Data.Mappigins;

namespace MercadoLivre.Clone.Api.Extensions;

public static class NHibernateExtensions
{
    public static IServiceCollection AddNHibernate(this IServiceCollection service, IConfiguration configuration)
    {
        var sessionFactory = Fluently.Configure()
            .Database(MsSqlConfiguration.MsSql2012.ConnectionString(configuration.GetConnectionString("DefaultConnection"))
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

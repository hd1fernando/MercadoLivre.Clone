using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;

namespace MercadoLivre.Clone.Api.Extensions;

public static class NHibernateExtensions
{
    public static IServiceCollection AddNHibernate(this IServiceCollection service, string connectionString)
    {
        var mapper = new ModelMapper();
        mapper.AddMappings(typeof(NHibernateExtensions).Assembly.ExportedTypes);
        var entityMapping = mapper.CompileMappingForAllExplicitlyAddedEntities();

        var configuration = new Configuration();
        configuration.DataBaseIntegration(c =>
        {
            c.ConnectionString = connectionString;
            c.Driver<Sql2008ClientDriver>();
            c.Dialect<MsSql2008Dialect>();
            c.LogSqlInConsole = true;
            c.LogFormattedSql = true;
            c.AutoCommentSql = true;
            c.Timeout = 60;
        });
        configuration.SessionFactory().GenerateStatistics();
        configuration.AddMapping(entityMapping);

        var sessionFactory = configuration.BuildSessionFactory();

        service.AddSingleton(sessionFactory);
        service.AddScoped(_ => sessionFactory.OpenSession());

        return service;

    }
}

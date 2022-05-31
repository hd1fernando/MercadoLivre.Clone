using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;
using System.Text;
using System.Text.Json;

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

public static class ApplicationBuilderExtensions
{
    public static void UseFluentValidationExceptionHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(x =>
        {
            x.Run(async context =>
            {
                var errorFeature = context.Features.Get<IExceptionHandlerFeature>();
                var exception = errorFeature.Error;

                if (!(exception is ValidationException validationException))
                    throw exception;

                var errors = validationException.Errors.Select(e => new
                {
                    e.PropertyName,
                    e.ErrorMessage
                });

                var errorText = JsonSerializer.Serialize(errors);
                context.Response.StatusCode = 400;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(errorText, Encoding.UTF8);

            });
        });
    }
}

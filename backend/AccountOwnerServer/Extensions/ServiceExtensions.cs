using Contracts;
using LoggerService;
using Entities;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace AccountOwnerServer.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(
                "CorsPolicy",
                builder =>
                    builder
                        .AllowAnyOrigin() // WithOrigin("Dominio.com.br")
                        .AllowAnyMethod() // WithMethods("POST","GET")
                        .AllowAnyHeader()
            ); //
        });
    }

    public static void ConfigureIISIntegration(this IServiceCollection services)
    {
        services.Configure<IISOptions>(options => { });
    }

    public static void ConfigureLoggerService(this IServiceCollection services)
    {
        services.AddSingleton<ILoggerManager, LoggerManager>();
    }

    public static void ConfigureMySqlContext(this IServiceCollection services, IConfiguration config)
    {
        var conn = config["mysqlconnection:connectionString"];
        services.AddDbContext<RepositoryContext>(options => options.UseMySql(conn, ServerVersion.AutoDetect(conn)));
    }

    public static void ConfigureRepositoryWrapper(this IServiceCollection services)
    {
        services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
    }
}

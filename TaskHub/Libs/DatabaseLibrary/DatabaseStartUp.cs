using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DatabaseLibrary;

/// <summary>
/// Добавление настроек базы данных
/// </summary>
public static class DatabaseStartUp
{
    /// <summary>
    /// Секция Postgres
    /// </summary>
    private const string PostgresConnectionStringName = "Postgres";

    /// <summary>
    /// Добавление Postgres (EF Core)
    /// </summary>
    public static void AddDatabase<TDbContext>(this IServiceCollection services)
        where TDbContext : DbContext
    {
        services.AddDbContext<TDbContext>((serviceProvider, options) =>
        {
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();

            var connectionString = configuration.GetConnectionString(PostgresConnectionStringName);
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException(
                    "Не найдена строка подключения к базе данных. Укажи её в конфигурации (ConnectionStrings:Postgres).");
            }

            options.UseNpgsql(connectionString);
        });
    }
}
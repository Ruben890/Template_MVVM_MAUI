using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AppContext = Infrastructure.Data.Context.AppContext;

namespace Infrastructure.Config
{
    public static class DatabaseConfiguration
    {
        /// <summary>
        /// Configures the SQLite database context for dependency injection.
        /// </summary>
        /// <param name="services">The service collection to add the DbContext to.</param>
        public static void AddSqliteContext(this IServiceCollection services)
        {
            var dbPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "db"
            );

            services.AddDbContext<AppContext>(options =>
                options.UseSqlite($"Data Source={dbPath}"),
                ServiceLifetime.Transient
            );
        }
    }
}

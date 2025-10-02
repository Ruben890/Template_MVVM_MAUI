using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SQLitePCL;
using AppContext = Infrastructure.Data.Context.AppContext;

namespace Infrastructure.Config
{
    public static class DatabaseConfiguration
    {
        public static IServiceCollection AddLynxSqliteContext(this IServiceCollection services, string folder)
        {
            // Inicializa SQLite
            Batteries_V2.Init();

            // Crear la carpeta si no existe
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            var dbPath = Path.Combine(folder, "Lynx.db");

            services.AddDbContext<AppContext>(options =>
                options.UseSqlite($"Data Source={dbPath}"),
                ServiceLifetime.Transient
            );

            return services;
        }

        public static void ApplyMigrations(this IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<AppContext>();

            // Si la DB no existe, la crea y crea tablas según el modelo
            if (db.Database.GetPendingMigrations().Any())
            {
                db.Database.Migrate(); // Aplica migraciones pendientes automáticamente
            }
            else
            {
                db.Database.EnsureCreated(); // Crea la DB si no existe
            }
        }
    }
}

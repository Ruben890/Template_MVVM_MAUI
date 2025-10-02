using Appliaction.Interfaces.IServices;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Config
{
    public static class Configuration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, string databaseFolder)
        {
            services.AddRepositoryServices();
            services.AddLynxSqliteContext(databaseFolder);
            services.AddTransient<IApiService, ApiService>();

            return services;
        }
    }
}

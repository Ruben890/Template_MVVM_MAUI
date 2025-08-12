using Appliaction.Interfaces.IServices;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Config
{
    public static class Configuration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddRepositoryServices();
            services.AddSqliteContext();
            services.AddTransient<IApiService, ApiService>();

            return services;
        }
    }
}

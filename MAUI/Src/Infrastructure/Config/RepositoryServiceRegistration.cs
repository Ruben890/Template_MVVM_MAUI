using Appliaction.Interfaces;
using Appliaction.Interfaces.IRepository;
using Infrastructure.Data;
using Infrastructure.Data.Respository;
using Microsoft.Extensions.DependencyInjection;
using AppContext = Infrastructure.Data.Context.AppContext;

namespace Infrastructure.Config
{
    public static class RepositoryServiceRegistration
    {
        public static void AddRepositoryServices(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork<AppContext>>();
            services.AddTransient<IUserRepository, UserRepository>();

        }
    }
}

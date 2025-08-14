using UI.ViewModels.Auth;
using UI.Views.Auth;

namespace UI.Config
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Registra todas las páginas (views) y sus ViewModels en el contenedor de servicios.
        /// Utiliza AddTransient para crear una nueva instancia cada vez que se solicite.
        /// </summary>
        public static void AddViewsAndViewModels(this IServiceCollection services)
        {
            services.AddTransient<LoginViewModel>();
            services.AddTransient<LoginPage>();
        }
    }
}

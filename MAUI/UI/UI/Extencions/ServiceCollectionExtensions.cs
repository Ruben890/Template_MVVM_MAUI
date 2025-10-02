using UI.ViewModels.Auth;
using UI.Views.Auth;

namespace UI.Config
{
    public static class ServiceCollectionExtensions
    {
        public static void AddPagesAndViewModels(this IServiceCollection services)
        {
            services.AddViewModels();
            services.AddViews();
        }


        public static void AddViews(this IServiceCollection services)
        {
            services.AddTransient<LoginPage>();
        }

        public static void AddViewModels(this IServiceCollection services)
        {
            // Registro de páginas (views)
            services.AddTransient<LoginViewModel>();
            services.AddViews();
        }
    }
}

using Appliaction.Config;
using Infrastructure.Config;
using UI.Config;
using Microsoft.Extensions.Logging;
using Shared.Enums;
using Shared.Config;
using RestSharp;

namespace UI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            // Define el entorno actual (Development, Production, etc)
            EnvironmentType currentEnv = EnvironmentType.Development;

            // Carga la configuración de la app según el entorno
            var appConfig = AppConfig.Load(currentEnv);

            if (string.IsNullOrWhiteSpace(appConfig.ApiBaseUrl))
                throw new ArgumentException("La configuración 'ApiBaseUrl' no puede ser null o vacía.");

            // Registra AppConfig como singleton para inyección
            builder.Services.AddSingleton(appConfig);

            // Registra RestClient configurado con base URL y header default
            builder.Services.AddSingleton(sp =>
            {
                var client = new RestClient(appConfig.ApiBaseUrl);
                client.AddDefaultHeader("Accept", "application/json");
                return client;
            });

            // Registrar servicios de infraestructura y aplicación (extensiones)
            builder.Services.AddInfrastructureServices();
            builder.Services.AddApplicationServices();
            builder.Services.AddViewsAndViewModels();

            // Configurar fuentes personalizadas
            builder.ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

            // Usar la clase App, inyectando el entorno y configuración
            builder.UseMauiApp<App>();

            // Configurar logging solo en Development
            if (currentEnv == EnvironmentType.Development)
            {
                builder.Logging.AddDebug();
            }

            return builder.Build();
        }
    }
}

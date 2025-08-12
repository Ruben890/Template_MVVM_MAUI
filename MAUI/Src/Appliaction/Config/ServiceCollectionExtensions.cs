using Appliaction.Interfaces.IServices;
using Microsoft.Extensions.DependencyInjection;

namespace Appliaction.Config
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Registra los servicios principales de la capa de aplicación.
        /// Por ejemplo, incluye servicios como el de autenticación, que mantiene 
        /// el estado global del usuario autenticado durante todo el ciclo de vida de la aplicación.
        /// </summary>
        /// <param name="services">Contenedor de servicios para la inyección de dependencias.</param>
        public static void AddApplicationServices(this IServiceCollection services)
        {
            // Agrupa el registro de configuraciones o estados globales de la aplicación
            services.AddConfigurationGlobalState();
        }

        /// <summary>
        /// Registra configuraciones y servicios relacionados con el estado global de la aplicación.
        /// Aquí puedes añadir servicios para manejar configuración, caché, estados compartidos, etc.
        /// Actualmente registra el servicio de autenticación como singleton para mantener su estado global.
        /// </summary>
        /// <param name="services">Contenedor de servicios para la inyección de dependencias.</param>
        public static void AddConfigurationGlobalState(this IServiceCollection services)
        {
            // Registro singleton para mantener el estado global del usuario autenticado
            services.AddSingleton<IAuthServices, AuthServices>();
        }
    }
}

using Shared.Enums;

namespace Shared.Config
{
    public class AppConfig
    {
        public string? ApiBaseUrl { get; set; }
        public bool EnableLogging { get; set; }
        public static AppConfig Load(EnvironmentType env)
        {
            switch (env)
            {
                case EnvironmentType.Development:
                    return new AppConfig
                    {
                        ApiBaseUrl = "http://localhost:5221/",
                        EnableLogging = true
                    };

                case EnvironmentType.Production:
                    return new AppConfig
                    {
                        ApiBaseUrl = "http://localhost:5221/",
                        EnableLogging = false
                    };

                default:
                    throw new ArgumentException("Entorno no soportado");
            }
        }
    }

}

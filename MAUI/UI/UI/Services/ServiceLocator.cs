namespace UI.Services
{
    public static class ServiceLocator
    {
        private static IServiceProvider? _services;

        public static void SetLocator(IServiceProvider services)
        {
            _services = services ?? throw new ArgumentNullException(nameof(services));
        }

        public static T Get<T>() => _services?.GetService(typeof(T)) is T service
            ? service
            : throw new InvalidOperationException($"Servicio {typeof(T)} no registrado.");
    }
}

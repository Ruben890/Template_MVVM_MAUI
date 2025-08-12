using Appliaction.Interfaces.IServices;
using UI.Views.Auth;

namespace UI
{
    public partial class AppShell : Shell
    {
        private readonly IAuthServices _authServices;

        public AppShell(IAuthServices authServices)
        {
            InitializeComponent();

            _authServices = authServices;

            FlyoutBehavior = FlyoutBehavior.Disabled;
            Title = "App";

            if (_authServices.IsAuthenticated)
            {
                // Usuario autenticado, mostrar contenido principal
                Items.Add(new ShellContent
                {
                    Title = "Home",
                    Route = "MainPage",
                    ContentTemplate = new DataTemplate(typeof(MainPage))
                });
            }
            else
            {
                Items.Add(new ShellContent
                {
                    Title = "Login",
                    Route = "LoginPage",
                    ContentTemplate = new DataTemplate(typeof(LoginPage))
                });
            }

            RegisterRoutes();
        }

        private void RegisterRoutes()
        {
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        }
    }
}

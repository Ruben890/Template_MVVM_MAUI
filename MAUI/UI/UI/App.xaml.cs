using Appliaction.Interfaces.IServices;
using Shared.Config;
using Colors = Components.Themes.Colors;
using Styles = Components.Themes.Styles;

namespace UI
{
    public partial class App : Application
    {
        public static AppConfig? Config { get; private set; }
        private readonly IAuthServices _authServices;

        public App(AppConfig config, IAuthServices authServices)
        {
            InitializeComponent();

            Config = config;

            Resources.MergedDictionaries.Add(new Colors());
            Resources.MergedDictionaries.Add(new Styles());

            _authServices = authServices;

            MainPage = new AppShell(_authServices);
        }
    }
}

using Appliaction.Interfaces.IServices;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using Shared.Enums;
using Shared.Models.Auth;
using System.Reflection;
using System.Windows.Input;

namespace UI.ViewModels.Auth
{
    public class LoginViewModel : BindableObject
    {
        private readonly IAuthServices _authServices;

        private string _email = string.Empty;
        private string _password = string.Empty;
        private bool _isSyncing = false;
        private string _syncStatus = string.Empty;
        private string _syncName = string.Empty;

        public string Email
        {
            get => _email;
            set { _email = value; OnPropertyChanged(); }
        }

        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(); }
        }

        public ICommand LoginCommand { get; }
        public ICommand ForgotPasswordCommand { get; }

        public string AppVersion => Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "v1.0.0";

        public LoginViewModel(IAuthServices authServices)
        {
            _authServices = authServices;

            LoginCommand = new Command(async () => await LoginAsync());
            ForgotPasswordCommand = new Command(async () => await ForgotPasswordAsync());
        }

        private async Task LoginAsync()
        {
            if (_authServices == null) return;

            var request = new AuthLoginRequest
            {
                Email = this.Email,
                Password = this.Password,
            };

            var result = await _authServices.Login(request);

            if (result.Status == ServiceResultStatus.Fail || result.Status == ServiceResultStatus.Warning)
            {
                await Toast.Make(result.Message!, ToastDuration.Long, 14).Show();
                return;
            }

        }

        private async Task ForgotPasswordAsync()
        {
            await Application.Current!.MainPage!.DisplayAlert("Recuperar contraseña", "Aquí iría la lógica", "OK");
        }
    }
}

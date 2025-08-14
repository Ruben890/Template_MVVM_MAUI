using Appliaction.Interfaces.IServices;

namespace UI.ViewModels.Auth
{
    public class LoginViewModel : BindableObject
    {
        private readonly IAuthServices _authServices;

        public LoginViewModel(IAuthServices authServices)
        {
            _authServices = authServices ?? throw new ArgumentNullException(nameof(authServices));
        }

    }
}

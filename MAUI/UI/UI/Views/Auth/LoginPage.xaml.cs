using Appliaction.Interfaces.IServices;

namespace UI.Views.Auth;

public partial class LoginPage : ContentPage
{
	private readonly IAuthServices  _authServices;
    public LoginPage(IAuthServices authServices)
	{
		_authServices = authServices;
		InitializeComponent();
	}
}
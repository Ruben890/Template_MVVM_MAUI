using Appliaction.Interfaces.IServices;
using UI.ViewModels.Auth;

namespace UI.Views.Auth;

public partial class LoginPage : ContentPage
{

    public LoginPage(LoginViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

}
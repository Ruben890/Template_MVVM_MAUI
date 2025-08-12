using Appliaction.Interfaces.IServices;
using Shared;
using Shared.Models;
using Shared.Models.Auth;

public class AuthServices : IAuthServices
{
    private readonly IApiService _apiService;

    // Estado en memoria del usuario autenticado
    private UserModel? _currentUser;

    public AuthServices(
        IApiService apiService)
    {
        _apiService = apiService;
    }

    public bool IsAuthenticated => _currentUser is not null;

    public async Task<ServiceResult<UserModel>> Login(AuthLoginRequest request)
    {
        try
        {
            var parameters = new GenericParameters { Services = "Logon" };

            var userResponse = await _apiService.PostAsync<AuthLoginRequest, UserModel>("index", request, parameters);

            if (userResponse is null || userResponse.Type is null)
                return ServiceResult<UserModel>.Fail("Usuario no encontrado");

            // Guardar usuario autenticado en memoria (sin modificar base)
            _currentUser = userResponse;

            return ServiceResult<UserModel>.Ok(userResponse, "Login exitoso");
        }
        catch (Exception ex)
        {
            var errorMessage = ex.InnerException?.Message ?? ex.Message;
            return ServiceResult<UserModel>.Fail($"Error al autenticar: {errorMessage}");
        }
    }

    public Task<ServiceResult<bool>> Logout()
    {
        try
        {
            if (_currentUser is null)
                return Task.FromResult(ServiceResult<bool>.Fail("No hay usuario autenticado"));

            // Limpiar estado local
            _currentUser = null;

            return Task.FromResult(ServiceResult<bool>.Ok(true, "Logout exitoso"));
        }
        catch (Exception ex)
        {
            var errorMessage = ex.InnerException?.Message ?? ex.Message;
            return Task.FromResult(ServiceResult<bool>.Fail($"Error al hacer logout: {errorMessage}"));
        }
    }

    public ServiceResult<UserModel> GetCurrentUser()
    {
        if (_currentUser is null)
            return ServiceResult<UserModel>.Fail("Usuario no autenticado");

        return ServiceResult<UserModel>.Ok(_currentUser);
    }
}

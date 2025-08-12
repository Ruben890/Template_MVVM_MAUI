using Shared;
using Shared.Models;
using Shared.Models.Auth;

namespace Appliaction.Interfaces.IServices
{
    /// <summary>
    /// Servicio de autenticación para manejar el estado y operaciones del usuario autenticado.
    /// </summary>
    public interface IAuthServices
    {
        /// <summary>
        /// Indica si hay un usuario autenticado actualmente.
        /// </summary>
        bool IsAuthenticated { get; }

        /// <summary>
        /// Devuelve el usuario autenticado con un resultado estándar, o error si no hay ninguno.
        /// </summary>
        ServiceResult<UserModel> GetCurrentUser();

        /// <summary>
        /// Realiza el login con las credenciales indicadas y guarda el usuario autenticado en memoria.
        /// </summary>
        Task<ServiceResult<UserModel>> Login(AuthLoginRequest request);

        /// <summary>
        /// Realiza el logout, limpiando el estado local del usuario autenticado.
        /// </summary>
        Task<ServiceResult<bool>> Logout();
    }
}

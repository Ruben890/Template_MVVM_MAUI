
using Domain.Entities;

namespace Appliaction.Interfaces.IRepository
{
    public interface IUserRepository
    {
        void DeleteUser(User user);
        Task<User?> GetUserByUserNameOrId(string userName, int? Id = null);
        Task InserUser(User user);
        void UpdateUser(User user);
    }
}

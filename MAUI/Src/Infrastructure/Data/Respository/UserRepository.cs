using Appliaction.Interfaces.IRepository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using AppContext = Infrastructure.Data.Context.AppContext;

namespace Infrastructure.Data.Respository
{
    public class UserRepository : RepositoryBase<User, AppContext>, IUserRepository
    {
        private readonly AppContext _context;
        public UserRepository(AppContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User?> GetUserByUserNameOrId(string userName, int? Id = null)
        {
            var query = _context.Users.AsQueryable();

            if (!string.IsNullOrWhiteSpace(userName))
            {
                query = query.Where( x => x.UserName!.ToUpper() == userName.ToUpper());
            }

            if (Id.HasValue) query.Where(x => x.Id == Id);


            return await query
                     .Select(x => new User
                     {
                         Id = x.Id,
                         LasName = x.LasName,
                         Name = x.Name,
                         UserName = x.UserName,
                     }).FirstOrDefaultAsync();

        }

        public Task InserUser(User user) => CreateAsync(user);

        public void DeleteUser(User user) => Delete(user);

        public void UpdateUser(User user) => Update(user);  
    }
}

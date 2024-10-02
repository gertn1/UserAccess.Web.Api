using UserAccess.Api.Domain.Entities;
using UserAccess.Api.Domain.Interfaces.Repositories.Base;

namespace UserAccess.Api.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IRepositoryBase<User, int>
    {
        Task<User?> GetByEmailAsync(string email);
        Task<User> GetUserByEmailAsync(string email);
    }
}

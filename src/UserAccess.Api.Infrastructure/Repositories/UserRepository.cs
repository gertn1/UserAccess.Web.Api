using Microsoft.EntityFrameworkCore;
using UserAccess.Api.Domain.Entities;
using UserAccess.Api.Domain.Interfaces.Repositories;
using UserAccess.Api.Infrastructure.Data;

namespace UserAccess.Api.Infrastructure.Repositories
{
    public class UserRepository : RepositoryBase<User, int>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users.Include(u => u.Role)
                                       .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            var user = await _context.Users.Include(u => u.Role)
                                           .FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            return user;
        }
    }
}

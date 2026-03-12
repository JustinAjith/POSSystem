using POSSystem.Models;
using POSSystem.Models.DtoModels;
using POSSystem.Models.EntityModels;
using POSSystem.Repositories.Interfaces;

namespace POSSystem.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly AppDbContext _context;

        public AuthRepository(AppDbContext context) => _context = context;
        public async Task<User> CreateUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}

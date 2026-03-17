using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public async Task<User?> Login(Login request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
            if (user == null) return null;
            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.Password)) return null;
            return user;
        }
    }
}

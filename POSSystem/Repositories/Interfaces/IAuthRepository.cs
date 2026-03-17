using POSSystem.Models.DtoModels;
using POSSystem.Models.EntityModels;

namespace POSSystem.Repositories.Interfaces
{
    public interface IAuthRepository
    {
        Task<User> CreateUser(User user);
        Task<User?> Login(Login request);
    }
}

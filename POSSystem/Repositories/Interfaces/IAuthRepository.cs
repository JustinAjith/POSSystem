using POSSystem.Models.EntityModels;

namespace POSSystem.Repositories.Interfaces
{
    public interface IAuthRepository
    {
        Task<User> CreateUser(User user);
    }
}

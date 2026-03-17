using POSSystem.Models.EntityModels;

namespace POSSystem.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}

using POSSystem.Models.DtoModels;
using POSSystem.Models.ResponseDTOModels;

namespace POSSystem.Services.Interfaces
{
    public interface IAuthService
    {
        Task<ResponseUserDto> CreateUserAsync(RegisterUser user);
        Task<ResponseTokenDto?> Login(Login request);
    }
}

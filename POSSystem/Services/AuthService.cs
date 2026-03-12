using POSSystem.Models.DtoModels;
using POSSystem.Models.EntityModels;
using POSSystem.Models.ResponseDTOModels;
using POSSystem.Repositories.Interfaces;
using POSSystem.Services.Interfaces;

namespace POSSystem.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _repository;

        public AuthService(IAuthRepository repository) => _repository = repository;
        public async Task<ResponseUserDto> CreateUserAsync(RegisterUser dtoUser)
        {
            var user = new User
            {
                Name = dtoUser.Name,
                Email = dtoUser.Email,
                Password = dtoUser.Password,
                Address = dtoUser.Address,
                IsActive = dtoUser.IsActive,
            };
            var response = await _repository.CreateUser(user);

            var returnUser = new ResponseUserDto
            {
                Id = response.Id,
                Name = response.Name,
                Email = response.Email,
                Address = response.Address,
                IsActive = response.IsActive,
            };
            return returnUser;
        }
    }
}

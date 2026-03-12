using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
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
        private readonly IMapper _mapper;

        public AuthService(IAuthRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ResponseUserDto> CreateUserAsync(RegisterUser dtoUser)
        {
            User user = _mapper.Map<User>(dtoUser);
            var response = await _repository.CreateUser(user);
            ResponseUserDto returnUser = _mapper.Map<ResponseUserDto>(response);
            return returnUser;
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public AuthService(IAuthRepository repository, IMapper mapper, ITokenService tokenService)
        {
            _repository = repository;
            _tokenService = tokenService;
            _mapper = mapper;
        }
        public async Task<ResponseUserDto> CreateUserAsync(RegisterUser dtoUser)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(dtoUser.Password);
            dtoUser.Password = passwordHash;
            User user = _mapper.Map<User>(dtoUser);
            var response = await _repository.CreateUser(user);
            ResponseUserDto returnUser = _mapper.Map<ResponseUserDto>(response);
            return returnUser;
        }

        public async Task<ResponseTokenDto?> Login(Login request)
        {
            var user = await _repository.Login(request);
            if (user == null) return null;

            string token = _tokenService.GenerateToken(user);
            ResponseUserDto userDto = _mapper.Map<ResponseUserDto>(user);
            ResponseTokenDto dto = new ResponseTokenDto
            {
                Token = token,
                User = userDto
            };
            return dto;
        }
    }
}

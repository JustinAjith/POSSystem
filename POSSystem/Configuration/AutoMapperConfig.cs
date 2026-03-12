using AutoMapper;
using POSSystem.Models.DtoModels;
using POSSystem.Models.EntityModels;
using POSSystem.Models.ResponseDTOModels;

namespace POSSystem.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<User, RegisterUser>().ReverseMap();
            CreateMap<User, ResponseUserDto>().ReverseMap();
        }
    }
}

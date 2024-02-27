using AutoMapper;
using CaseForRanna_BackEnd.Entities;
using CaseForRanna_BackEnd.Entities.Dtos;

namespace CaseForRanna_BackEnd.Helpers
{
    public class AutoMapperConfig:Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<User, CreateUserDto>();
            CreateMap<User, CreateUserDto>().ReverseMap();
        }
    }
}

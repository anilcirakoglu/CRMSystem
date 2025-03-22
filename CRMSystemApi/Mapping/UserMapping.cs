using AutoMapper;
using CRMSystem.DtoLayer.UserDto;
using CRMSystem.EntityLayer.Entities;
namespace CRMSystemApi.Mapping
{
    public class UserMapping:Profile
    {
        public UserMapping()
        {
            CreateMap<User,CreateUserDto>().ReverseMap();
            CreateMap<User,UpdateUserDto>().ReverseMap();
            CreateMap<User,ResultUserDto>().ReverseMap();
            CreateMap<User, UpdateUserDto>().ReverseMap();
        }
    }
}

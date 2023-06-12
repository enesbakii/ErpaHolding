using AutoMapper;
using ErpaHolding.Business.DTOs.UserDto;
using ErpaHolding.Entity;

namespace ErpaHolding.Business.Mappings.AutoMapper
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<UserEntity, UserDto>().ReverseMap();
            CreateMap<UserEntity, UserCreateDto>().ReverseMap();
            CreateMap<UserEntity, UserUpdateDto>().ReverseMap();
        }
    }
}

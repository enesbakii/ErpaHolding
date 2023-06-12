using AutoMapper;
using ErpaHolding.Business.DTOs;
using ErpaHolding.Entity;

namespace ErpaHolding.Business.Mappings.AutoMapper
{
    public class UserRoleProfile : Profile
    {
        public UserRoleProfile()
        {
            CreateMap<UserRolesEntity, UserRoleDto>().ReverseMap();
        }
    }
}

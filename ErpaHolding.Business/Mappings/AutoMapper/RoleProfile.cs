using AutoMapper;
using ErpaHolding.Business.DTOs.RoleDto;
using ErpaHolding.Entity;

namespace ErpaHolding.Business.Mappings.AutoMapper
{
    public class RoleProfile:Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleEntity, RoleDto>().ReverseMap();
        }
    }
}

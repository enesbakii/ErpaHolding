using AutoMapper;
using ErpaHolding.Business.DTOs.CartDto;
using ErpaHolding.Entity;

namespace ErpaHolding.Business.Mappings.AutoMapper
{
    public class CartProfile:Profile
    {
        public CartProfile()
        {
            CreateMap<CartEntity, CartCreateDto>().ReverseMap();
            CreateMap<CartEntity, CartDto>().ReverseMap();
        }
    }
}

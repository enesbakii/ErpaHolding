using AutoMapper;
using ErpaHolding.Business.DTOs.CartDto;
using ErpaHolding.Entity;

namespace ErpaHolding.Business.Mappings.AutoMapper
{
    public class CartDetailProfile:Profile
    {
        public CartDetailProfile()
        {
            CreateMap<CartDetailsEntity,CartDetailsCreateDto>().ReverseMap();
        }
    }
}

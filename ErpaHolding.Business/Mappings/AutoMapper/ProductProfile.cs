using AutoMapper;
using ErpaHolding.Business.DTOs.ProductDto;
using ErpaHolding.Entity;

namespace ErpaHolding.Business.Mappings.AutoMapper
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductEntity,ProductDto>().ReverseMap();
            CreateMap<ProductEntity,ProductCreateDto>().ReverseMap();
            CreateMap<ProductEntity, ProductUpdateDto>().ReverseMap();
        }
    }
}

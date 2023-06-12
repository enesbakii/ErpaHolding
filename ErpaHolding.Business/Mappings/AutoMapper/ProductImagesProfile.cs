using AutoMapper;
using ErpaHolding.Business.DTOs.ProductImagesDto;
using ErpaHolding.Entity;


namespace ErpaHolding.Business.Mappings.AutoMapper
{
    public class ProductImagesProfile:Profile
    {
    
        public ProductImagesProfile()
        {

            CreateMap<ProductImagesEntity, ProductImagesCreateDto>().ReverseMap();
            CreateMap<ProductImagesEntity, ProductImagesDto>().ReverseMap();
            CreateMap<ProductImagesEntity, ProductImagesUpdateDto>().ReverseMap();

        }

    }
}

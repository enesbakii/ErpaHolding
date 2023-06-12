using AutoMapper;
using ErpaHolding.Business.DTOs.BrandDto;
using ErpaHolding.Entity;

namespace ErpaHolding.Business.Mappings.AutoMapper
{
    public class BrandProfile:Profile
    {
        public BrandProfile()
        {
            CreateMap<BrandEntity, BrandCreateDto>().ReverseMap();
            CreateMap<BrandEntity, BrandDto>().ReverseMap();
            CreateMap<BrandEntity, BrandUpdateDto>().ReverseMap();
        }
    }
}

using AutoMapper;
using ErpaHolding.Business.DTOs.CategoryDto;
using ErpaHolding.Entity;

namespace ErpaHolding.Business.Mappings.AutoMapper
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryEntity, CategoryCreateDto>().ReverseMap();
            CreateMap<CategoryEntity, CategoryDto>().ReverseMap();
            CreateMap<CategoryEntity, CategoryUpdateDto>().ReverseMap();
        }
    }
}

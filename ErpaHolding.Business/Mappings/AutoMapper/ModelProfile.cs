using AutoMapper;
using ErpaHolding.Business.DTOs.ModelDto;
using ErpaHolding.Entity;

namespace ErpaHolding.Business.Mappings.AutoMapper
{
    public class ModelProfile:Profile
    {
        public ModelProfile()
        {
            CreateMap<ModelEntity, ModelCreateDto>().ReverseMap();
            CreateMap<ModelEntity, ModelUpdateDto>().ReverseMap();
            CreateMap<ModelEntity, ModelDto>().ReverseMap();
        }
    }
}

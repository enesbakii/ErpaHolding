using ErpaHolding.Business.DTOs.ModelDto;
using ErpaHolding.Business.Responce;

namespace ErpaHolding.Business.Services
{
    public interface IModelService
    {
        Task<CustomResponseDto<ModelCreateDto>> CreateAsync(ModelCreateDto modelCreateDto);
        Task<CustomResponseDto<IEnumerable<ModelDto>>> GetAllAsync();
        Task<CustomResponseDto<ModelDto>> GetByFilterAsync(Guid id);
        Task<CustomResponseDto<NoContentDto>> UpdateAsync(ModelUpdateDto modelUpdateDto);
        Task<CustomResponseDto<NoContentDto>> RemoveAsync(Guid id);
    }
}

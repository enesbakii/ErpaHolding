using ErpaHolding.Business.DTOs.CategoryDto;
using ErpaHolding.Business.Responce;

namespace ErpaHolding.Business.Services
{
    public interface ICategoryService
    {
        Task<CustomResponseDto<CategoryCreateDto>> CreateAsync(CategoryCreateDto categoryCreateDto);
        Task<CustomResponseDto<IEnumerable<CategoryDto>>> GetAllAsync();
        Task<CustomResponseDto<CategoryDto>> GetByFilterAsync(Guid id);
        Task<CustomResponseDto<NoContentDto>> UpdateAsync(CategoryUpdateDto categoryUpdateDto);
        Task<CustomResponseDto<NoContentDto>> RemoveAsync(Guid id);
    }
}

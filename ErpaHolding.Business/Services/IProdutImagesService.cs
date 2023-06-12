using ErpaHolding.Business.DTOs.ProductImagesDto;
using ErpaHolding.Business.Responce;

namespace ErpaHolding.Business.Services
{
    public interface IProdutImagesService
    {
        Task<CustomResponseDto<ProductImagesCreateDto>> CreateAsync(ProductImagesCreateDto productImagesCreateDto);
        Task<CustomResponseDto<IEnumerable<ProductImagesDto>>> GetAllAsync();
        Task<CustomResponseDto<ProductImagesDto>> GetByFilterAsync(Guid id);
        Task<CustomResponseDto<NoContentDto>> UpdateAsync(ProductImagesUpdateDto productImagesUpdateDto);
        Task<CustomResponseDto<NoContentDto>> RemoveAsync(Guid id);
        Task<CustomResponseDto<List<ProductImagesCreateDto>>> CreateListAsync(List<ProductImagesCreateDto> userRoleDtos);
    }
}

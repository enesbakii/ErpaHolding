using ErpaHolding.Business.DTOs.ProductDto;
using ErpaHolding.Business.Responce;

namespace ErpaHolding.Business.Services
{
    public interface IProductService
    {
        Task<CustomResponseDto<ProductCreateDto>> CreateAsync(ProductCreateDto productCreateDto);

        Task<CustomResponseDto<IEnumerable<ProductDto>>> GetAllAsync();
        Task<CustomResponseDto<ProductDto>> GetByFilterAsync(Guid id);
        Task<CustomResponseDto<NoContentDto>> UpdateAsync(ProductUpdateDto productUpdateDto);
        Task<CustomResponseDto<NoContentDto>> RemoveAsync(Guid id);

    }
}

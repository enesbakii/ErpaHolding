using ErpaHolding.Business.DTOs.BrandDto;
using ErpaHolding.Business.Responce;

namespace ErpaHolding.Business.Services
{
    public interface IBrandService
    {
        Task<CustomResponseDto<BrandCreateDto>> CreateAsync(BrandCreateDto brandCreateDto);
        Task<CustomResponseDto<IEnumerable<BrandDto>>> GetAllAsync();
        Task<CustomResponseDto<BrandDto>> GetByFilterAsync(Guid id);
        Task<CustomResponseDto<NoContentDto>> UpdateAsync(BrandUpdateDto brandUpdateDto);
        Task<CustomResponseDto<NoContentDto>> RemoveAsync(Guid id);
    }
}


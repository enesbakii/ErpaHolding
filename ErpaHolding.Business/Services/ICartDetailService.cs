using ErpaHolding.Business.DTOs.CartDto;
using ErpaHolding.Business.DTOs.CategoryDto;
using ErpaHolding.Business.Responce;

namespace ErpaHolding.Business.Services
{
    public interface ICartDetailService
    {
        Task<CustomResponseDto<List<CartDetailsCreateDto>>> CreateAsync(List<CartDetailsCreateDto> cartDetailsDto);
        Task<CustomResponseDto<IEnumerable<CartDetailsDto>>> GetAllAsync();
    }
}

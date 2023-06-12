using ErpaHolding.Business.DTOs.CartDto;
using ErpaHolding.Business.Responce;

namespace ErpaHolding.Business.Services
{
    public interface ICartService
    {
        Task<CustomResponseDto<CartCreateDto>> CreateAsync(CartCreateDto cartCreateDto);
 
    }
}

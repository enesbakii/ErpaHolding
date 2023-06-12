using ErpaHolding.Business.DTOs.CategoryDto;
using ErpaHolding.Business.DTOs.UserDto;
using ErpaHolding.Business.Responce;

namespace ErpaHolding.Business.Services
{
    public interface IUserService
    {
        Task<CustomResponseDto<UserCreateDto>> CreateAsync(UserCreateDto userCreateDto);
        Task<CustomResponseDto<LoginResponseDto>> LoginAsync(LoginDto loginDto);
        Task<CustomResponseDto<IEnumerable<UserDto>>> GetAllAsync();
    }
}

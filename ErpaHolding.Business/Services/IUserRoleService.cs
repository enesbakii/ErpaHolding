using ErpaHolding.Business.DTOs;
using ErpaHolding.Business.Responce;

namespace ErpaHolding.Business.Services
{
    public interface IUserRoleService
    {
        Task<CustomResponseDto<UserRoleDto>> CreateAsync(UserRoleDto userRoleDto);
        Task<CustomResponseDto<List<UserRoleDto>>> CreateListAsync(List<UserRoleDto> userRoleDtos);
    }
}

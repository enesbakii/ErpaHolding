using ErpaHolding.Business.DTOs.RoleDto;
using ErpaHolding.Business.Responce;

namespace ErpaHolding.Business.Services
{
    public interface IRoleService
    {
        Task<CustomResponseDto<IEnumerable<RoleDto>>> GetAllAsync();
    }
}

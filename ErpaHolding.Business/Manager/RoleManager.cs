using AutoMapper;
using ErpaHolding.Business.DTOs.RoleDto;
using ErpaHolding.Business.Responce;
using ErpaHolding.Business.Services;
using ErpaHolding.DataAccess.Interfaces;
using ErpaHolding.Entity;
using Microsoft.AspNetCore.Http;

namespace ErpaHolding.Business.Manager
{
    public class RoleManager : IRoleService
    {
        private readonly IRepository<RoleEntity> _roleRepository;
        private readonly IMapper _mapper;
        public RoleManager(IRepository<RoleEntity> roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }


        public async Task<CustomResponseDto<IEnumerable<RoleDto>>> GetAllAsync()
        {
            var entity = await _roleRepository.GetAllAsync();
            var newDto = _mapper.Map<IEnumerable<RoleDto>>(entity);
            return CustomResponseDto<IEnumerable<RoleDto>>.Success(StatusCodes.Status200OK, newDto.ToList());
        }
    }
}

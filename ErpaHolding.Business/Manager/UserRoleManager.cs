using AutoMapper;
using ErpaHolding.Business.DTOs;
using ErpaHolding.Business.Responce;
using ErpaHolding.Business.Services;
using ErpaHolding.DataAccess.Interfaces;
using ErpaHolding.DataAccess.UnitOfWorks;
using ErpaHolding.Entity;
using Microsoft.AspNetCore.Http;

namespace ErpaHolding.Business.Manager
{
    public class UserRoleManager : IUserRoleService
    {
        private readonly IRepository<UserRolesEntity> _userRoleRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public UserRoleManager(IRepository<UserRolesEntity> userRoleRepository, IMapper mapper, IUnitOfWork uow)
        {
            _userRoleRepository = userRoleRepository;
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<CustomResponseDto<UserRoleDto>> CreateAsync(UserRoleDto userRoleDto)
        {
            var entity = _mapper.Map<UserRolesEntity>(userRoleDto);
            await _userRoleRepository.CreateAsync(entity);
            await _uow.CommitAsync();

            var newDto = _mapper.Map<UserRoleDto>(entity);
            return CustomResponseDto<UserRoleDto>.Success(StatusCodes.Status200OK, newDto);
        }

        public async Task<CustomResponseDto<List<UserRoleDto>>> CreateListAsync(List<UserRoleDto> userRoleDtos)
        {
            var entities = _mapper.Map<List<UserRolesEntity>>(userRoleDtos);
            await _userRoleRepository.CreateListAsync(entities);
            await _uow.CommitAsync();

            var newDtos = _mapper.Map<List<UserRoleDto>>(entities);
            return CustomResponseDto<List<UserRoleDto>>.Success(StatusCodes.Status200OK, newDtos);
        }


    }
}


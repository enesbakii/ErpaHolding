using AutoMapper;
using ErpaHolding.Business.DTOs;
using ErpaHolding.Business.DTOs.CategoryDto;
using ErpaHolding.Business.DTOs.UserDto;
using ErpaHolding.Business.Extensions;
using ErpaHolding.Business.Responce;
using ErpaHolding.Business.Services;
using ErpaHolding.DataAccess.Interfaces;
using ErpaHolding.DataAccess.UnitOfWorks;
using ErpaHolding.Entity;
using FluentValidation;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ErpaHolding.Business.Manager
{
    public class UserManager : IUserService
    {
        private readonly IRepository<UserEntity> _userRepository;
        private readonly IRepository<RoleEntity> _roleRepository;
        private readonly IRepository<UserRolesEntity> _userRolesRepository;
        private readonly IValidator<UserCreateDto> _createValidator;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IDataProtector _dataProtector;
        private readonly IRoleService _roleService;
        private readonly IUserRoleService _userRoleService;

        public UserManager(IDataProtectionProvider dataProtectionProvider, IMapper mapper, IValidator<UserCreateDto> createValidator, IRepository<UserEntity> userRepository, IUnitOfWork uow, IUserRoleService userRoleService, IRoleService roleService, IRepository<RoleEntity> roleRepository, IRepository<UserRolesEntity> userRolesRepository)
        {

            _dataProtector = dataProtectionProvider.CreateProtector("security");
            _mapper = mapper;
            _createValidator = createValidator;
            _userRepository = userRepository;
            _uow = uow;
            _userRoleService = userRoleService;
            _roleService = roleService;
            _roleRepository = roleRepository;
            _userRolesRepository = userRolesRepository;
        }


         private static string StringSha256Hash(string text) =>
        string.IsNullOrEmpty(text) ? string.Empty : BitConverter.ToString(new System.Security.Cryptography.SHA256Managed().ComputeHash(System.Text.Encoding.UTF8.GetBytes(text))).Replace("-", string.Empty);




        public async Task<CustomResponseDto<UserCreateDto>> CreateAsync(UserCreateDto userCreateDto)
        {

            var validationRusult = _createValidator.Validate(userCreateDto);
            if (validationRusult.IsValid)
            {
                var hasUser = _userRepository.Where(x => x.UserName == userCreateDto.UserName || x.PhoneNumber == userCreateDto.PhoneNumber);
                if (hasUser.Any())
                {
                    return CustomResponseDto<UserCreateDto>.Fail(StatusCodes.Status400BadRequest, "Bu kullanıcı mevcut");
                }


                var encryptedPassword = StringSha256Hash(userCreateDto.Password);
                //var encryptedPassword = _dataProtector.Protect(userCreateDto.Password);
                userCreateDto.Password = encryptedPassword;
                var userEntity = _mapper.Map<UserEntity>(userCreateDto);

                await _userRepository.CreateAsync(userEntity);
                await _uow.CommitAsync();

                var userRoleDtos = new List<UserRoleDto>();

                foreach (var roleId in userCreateDto.RoleIds)
                {
                    var userRole = new UserRoleDto()
                    {
                        RoleId = roleId,
                        UserId = userEntity.Id
                    };

                    userRoleDtos.Add(userRole);
                }

                await _userRoleService.CreateListAsync(userRoleDtos);
                await _uow.CommitAsync();

                var newDto = _mapper.Map<UserCreateDto>(userEntity);
                return CustomResponseDto<UserCreateDto>.Success(StatusCodes.Status200OK, newDto);
            }

            return CustomResponseDto<UserCreateDto>.Fail(StatusCodes.Status400BadRequest, validationRusult.ConvertToCustomValidationError());
        }

        public async Task<CustomResponseDto<IEnumerable<UserDto>>> GetAllAsync()
        {
            var entity = await _userRepository.GetAllAsync();
            var newDto = _mapper.Map<IEnumerable<UserDto>>(entity);
            return CustomResponseDto<IEnumerable<UserDto>>.Success(StatusCodes.Status200OK, newDto.ToList());
        }

        public async Task<CustomResponseDto<LoginResponseDto>> LoginAsync(LoginDto loginDto)
        {
            var response = new LoginResponseDto();


            var passwordHash = StringSha256Hash(loginDto.Password);
            //var passwordHash = _dataProtector.Protect(dto.Password);
            var userQuery = _userRepository.GetQuery();
            var user = await userQuery.SingleOrDefaultAsync(x => (x.UserName == loginDto.Username || x.PhoneNumber==loginDto.Username) && x.Password == passwordHash);

            if (user == null)
            {
                response.IsLogin = false;
                return CustomResponseDto<LoginResponseDto>.Fail(StatusCodes.Status400BadRequest,"Kullanıcı adı veya şifre hatalı",response);
            }



            var userRoleQuery = _userRolesRepository.GetQuery();
            var roleQuery = _roleRepository.GetQuery();

            var roles = userQuery.Where(x => x.UserName == loginDto.Username && x.Password == passwordHash).Join(userRoleQuery, x => x.Id, x => x.UserId, (user, userRole) => new
            {
                user,
                userRole
            }).Join(roleQuery, twoTable => twoTable.userRole.RoleId, role => role.Id, (twoTable, role) => new RoleEntity
            {
                Id = role.Id,
                Name = role.Name,

            }).ToList();

            response.UserId = user.Id;
            response.IsLogin = true;
            response.Roles = roles.Select(x => x.Name).ToList();

            return CustomResponseDto<LoginResponseDto>.Success(StatusCodes.Status200OK, response);
        }
    }
}

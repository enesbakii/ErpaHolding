using AutoMapper;
using ErpaHolding.Business.DTOs.CartDto;
using ErpaHolding.Business.DTOs.CategoryDto;
using ErpaHolding.Business.Responce;
using ErpaHolding.Business.Services;
using ErpaHolding.DataAccess.Interfaces;
using ErpaHolding.DataAccess.UnitOfWorks;
using ErpaHolding.Entity;
using Microsoft.AspNetCore.Http;

namespace ErpaHolding.Business.Manager
{
    public class CartDetailManager:ICartDetailService
    {
        private readonly IRepository<CartDetailsEntity> _cartDetailsRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public CartDetailManager(IRepository<CartDetailsEntity> cartDetailsRepository, IMapper mapper, IUnitOfWork uow)
        {
            _cartDetailsRepository = cartDetailsRepository;
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<CustomResponseDto<List<CartDetailsCreateDto>>> CreateAsync(List<CartDetailsCreateDto> cartDetailsDto)
        {


            var entities = _mapper.Map<List<CartDetailsEntity>>(cartDetailsDto);
            await _cartDetailsRepository.CreateListAsync(entities);
            await _uow.CommitAsync();

            var newDtos = _mapper.Map<List<CartDetailsCreateDto>>(entities);
            return CustomResponseDto<List<CartDetailsCreateDto>>.Success(StatusCodes.Status200OK, newDtos);


        }

        public async Task<CustomResponseDto<IEnumerable<CartDetailsDto>>> GetAllAsync()
        {
            var entity = await _cartDetailsRepository.GetAllAsync();
            var newDto = _mapper.Map<IEnumerable<CartDetailsDto>>(entity);
            return CustomResponseDto<IEnumerable<CartDetailsDto>>.Success(StatusCodes.Status200OK, newDto.ToList());
        }
    }
}

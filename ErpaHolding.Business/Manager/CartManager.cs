using AutoMapper;
using ErpaHolding.Business.DTOs.CartDto;
using ErpaHolding.Business.Responce;
using ErpaHolding.Business.Services;
using ErpaHolding.DataAccess.Interfaces;
using ErpaHolding.DataAccess.UnitOfWorks;
using ErpaHolding.Entity;
using Microsoft.AspNetCore.Http;

namespace ErpaHolding.Business.Manager
{
    public class CartManager : ICartService
    {
        private readonly IRepository<CartEntity> _cartRepository;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CartManager(IRepository<CartEntity> cartRepository, IUnitOfWork uow, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<CartCreateDto>> CreateAsync(CartCreateDto cartCreateDto)
        {


            var entity = _mapper.Map<CartEntity>(cartCreateDto);
            await _cartRepository.CreateAsync(entity);
            await _uow.CommitAsync();

            var newDto = _mapper.Map<CartCreateDto>(entity);
            return CustomResponseDto<CartCreateDto>.Success(StatusCodes.Status200OK, newDto);


        }

  
    }
}

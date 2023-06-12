using AutoMapper;
using ErpaHolding.Business.DTOs.ProductDto;
using ErpaHolding.Business.Extensions;
using ErpaHolding.Business.Responce;
using ErpaHolding.Business.Services;
using ErpaHolding.DataAccess.Interfaces;
using ErpaHolding.DataAccess.UnitOfWorks;
using ErpaHolding.Entity;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace ErpaHolding.Business.Manager
{
    public class ProductManager : IProductService
    {
        private readonly IRepository<ProductEntity> _productRepository;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<ProductCreateDto> _createValidator;
        private readonly IValidator<ProductUpdateDto> _updateValidator;

        public ProductManager(IRepository<ProductEntity> productRepository, IUnitOfWork uow, IMapper mapper, IValidator<ProductCreateDto> createValidator, IValidator<ProductUpdateDto> updateValidator)
        {
            _productRepository = productRepository;
            _uow = uow;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<CustomResponseDto<ProductCreateDto>> CreateAsync(ProductCreateDto productCreateDto)
        {
            var validationRusult = _createValidator.Validate(productCreateDto);
            if (validationRusult.IsValid)
            {
                var productEntity = _mapper.Map<ProductEntity>(productCreateDto);
                await _productRepository.CreateAsync(productEntity);
                await _uow.CommitAsync();

                var newDto = _mapper.Map<ProductCreateDto>(productEntity);
                return CustomResponseDto<ProductCreateDto>.Success(StatusCodes.Status200OK, newDto);
            }

            return CustomResponseDto<ProductCreateDto>.Fail(StatusCodes.Status400BadRequest, validationRusult.ConvertToCustomValidationError());
        }

   

            public async Task<CustomResponseDto<IEnumerable<ProductDto>>> GetAllAsync()
            {
                var entity = await _productRepository.GetAllAsync();
                var newDto = _mapper.Map<IEnumerable<ProductDto>>(entity);
                return CustomResponseDto<IEnumerable<ProductDto>>.Success(StatusCodes.Status200OK, newDto.ToList());
            }

            public async Task<CustomResponseDto<ProductDto>> GetByFilterAsync(Guid id)
            {
                var entity = await _productRepository.GetByFilterAsync(x => x.Id == id);
                if (entity == null)
                {
                    return CustomResponseDto<ProductDto>.Fail(StatusCodes.Status404NotFound, "Aradğınız ürün bulunmadı");
                }
                var newDto = _mapper.Map<ProductDto>(entity);
                return CustomResponseDto<ProductDto>.Success(StatusCodes.Status200OK, newDto);
            }

            public async Task<CustomResponseDto<NoContentDto>> RemoveAsync(Guid id)
            {
                var entity = await _productRepository.GetByFilterAsync(x => x.Id == id);
                if (entity != null)
                {
                    _productRepository.Remove(entity);
                    await _uow.CommitAsync();
                    return CustomResponseDto<NoContentDto>.Success(StatusCodes.Status204NoContent);
                }

                return CustomResponseDto<NoContentDto>.Fail(StatusCodes.Status404NotFound, "Kategori bulunamadı");
            }

            public async Task<CustomResponseDto<NoContentDto>> UpdateAsync(ProductUpdateDto productUpdateDto)
            {
                var validationRusult = _updateValidator.Validate(productUpdateDto);
                if (validationRusult.IsValid)
                {

                    var entity = _mapper.Map<ProductEntity>(productUpdateDto);
                    _productRepository.Update(entity);
                    await _uow.CommitAsync();

                    var newDto = _mapper.Map<ProductUpdateDto>(entity);
                    return CustomResponseDto<NoContentDto>.Success(StatusCodes.Status204NoContent);
                }
                return CustomResponseDto<NoContentDto>.Fail(StatusCodes.Status400BadRequest, validationRusult.ConvertToCustomValidationError());
            }
        }
    }

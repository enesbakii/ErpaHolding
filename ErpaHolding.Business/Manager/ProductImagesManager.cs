using AutoMapper;
using ErpaHolding.Business.DTOs.ProductImagesDto;
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
    public class ProductImagesManager : IProdutImagesService
    {
        private readonly IRepository<ProductImagesEntity> _productImagesRepository;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<ProductImagesCreateDto> _createValidator;
        private readonly IValidator<ProductImagesUpdateDto> _updateValidator;

        public ProductImagesManager(IRepository<ProductImagesEntity> productImagesRepository, IUnitOfWork uow, IMapper mapper, IValidator<ProductImagesCreateDto> createValidator, IValidator<ProductImagesUpdateDto> updateValidator)
        {
            _productImagesRepository = productImagesRepository;
            _uow = uow;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<CustomResponseDto<ProductImagesCreateDto>> CreateAsync(ProductImagesCreateDto productImagesCreateDto)
        {
            var validationRusult = _createValidator.Validate(productImagesCreateDto);
            if (validationRusult.IsValid)
            {
                var productImagesEntity = _mapper.Map<ProductImagesEntity>(productImagesCreateDto);
                await _productImagesRepository.CreateAsync(productImagesEntity);
                await _uow.CommitAsync();

                var newDto = _mapper.Map<ProductImagesCreateDto>(productImagesEntity);
                return CustomResponseDto<ProductImagesCreateDto>.Success(StatusCodes.Status200OK, newDto);
            }

            return CustomResponseDto<ProductImagesCreateDto>.Fail(StatusCodes.Status400BadRequest, validationRusult.ConvertToCustomValidationError());
        }

        public async Task<CustomResponseDto<List<ProductImagesCreateDto>>> CreateListAsync(List<ProductImagesCreateDto> productImagesCreateDtos)
        {
            var productImagesEntities = _mapper.Map<List<ProductImagesEntity>>(productImagesCreateDtos);
            await _productImagesRepository.CreateListAsync(productImagesEntities);
            await _uow.CommitAsync();

            var newDtos = _mapper.Map<List<ProductImagesCreateDto>>(productImagesEntities);
            return CustomResponseDto<List<ProductImagesCreateDto>>.Success(StatusCodes.Status200OK, newDtos);
        }

        public async Task<CustomResponseDto<IEnumerable<ProductImagesDto>>> GetAllAsync()
        {
            var entity = await _productImagesRepository.GetAllAsync();
            var newDto = _mapper.Map<IEnumerable<ProductImagesDto>>(entity);
            return CustomResponseDto<IEnumerable<ProductImagesDto>>.Success(StatusCodes.Status200OK, newDto.ToList());
        }

        public async Task<CustomResponseDto<ProductImagesDto>> GetByFilterAsync(Guid id)
        {
            var entity = await _productImagesRepository.GetByFilterAsync(x => x.Id == id);
            if (entity == null)
            {
                return CustomResponseDto<ProductImagesDto>.Fail(StatusCodes.Status404NotFound, "Aradğınız kategori bulunmadı");
            }
            var newDto = _mapper.Map<ProductImagesDto>(entity);
            return CustomResponseDto<ProductImagesDto>.Success(StatusCodes.Status200OK, newDto);

        }

        public async Task<CustomResponseDto<NoContentDto>> RemoveAsync(Guid id)
        {
            var entity = await _productImagesRepository.GetByFilterAsync(x => x.Id == id);
            if (entity != null)
            {
                _productImagesRepository.Remove(entity);
                await _uow.CommitAsync();
                return CustomResponseDto<NoContentDto>.Success(StatusCodes.Status204NoContent);
            }

            return CustomResponseDto<NoContentDto>.Fail(StatusCodes.Status404NotFound, "Kategori bulunamadı");
        }

        public async Task<CustomResponseDto<NoContentDto>> UpdateAsync(ProductImagesUpdateDto productImagesUpdateDto)
        {
            var validationRusult = _updateValidator.Validate(productImagesUpdateDto);
            if (validationRusult.IsValid)
            {

                var entity = _mapper.Map<ProductImagesEntity>(productImagesUpdateDto);
                _productImagesRepository.Update(entity);
                await _uow.CommitAsync();

                var newDto = _mapper.Map<ProductImagesUpdateDto>(entity);
                return CustomResponseDto<NoContentDto>.Success(StatusCodes.Status204NoContent);
            }
            return CustomResponseDto<NoContentDto>.Fail(StatusCodes.Status400BadRequest, validationRusult.ConvertToCustomValidationError());
        }
    }
}

using AutoMapper;
using ErpaHolding.Business.DTOs.BrandDto;
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
    public class BrandManager : IBrandService
    {
        private readonly IRepository<BrandEntity> _brandRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        private readonly IValidator<BrandCreateDto> _createValidator;
        private readonly IValidator<BrandUpdateDto> _updateValidator;

        public BrandManager(IRepository<BrandEntity> brandRepository, IMapper mapper, IUnitOfWork uow, IValidator<BrandCreateDto> createValidator, IValidator<BrandUpdateDto> updateValidator)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
            _uow = uow;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<CustomResponseDto<BrandCreateDto>> CreateAsync(BrandCreateDto brandCreateDto)
        {
            var validationRusult = _createValidator.Validate(brandCreateDto);
            if (validationRusult.IsValid)
            {
                var  hasCategory = await _brandRepository.GetAllAsync(x => x.Defination == brandCreateDto.Defination);
                if (hasCategory.Any())
                {
                    return CustomResponseDto<BrandCreateDto>.Fail(StatusCodes.Status400BadRequest, "Bu isimde mevcut marka mevcut");
                }
                var brandEntity = _mapper.Map<BrandEntity>(brandCreateDto);
                await _brandRepository.CreateAsync(brandEntity);
                await _uow.CommitAsync();

                var newDto = _mapper.Map<BrandCreateDto>(brandEntity);
                return CustomResponseDto<BrandCreateDto>.Success(StatusCodes.Status200OK, newDto);
            }

            return CustomResponseDto<BrandCreateDto>.Fail(StatusCodes.Status400BadRequest, validationRusult.ConvertToCustomValidationError());
        }

        public async Task<CustomResponseDto<IEnumerable<BrandDto>>> GetAllAsync()
        {
            var entity = await _brandRepository.GetAllAsync();
            var newDto = _mapper.Map<IEnumerable<BrandDto>>(entity);
            return CustomResponseDto<IEnumerable<BrandDto>>.Success(StatusCodes.Status200OK, newDto.ToList());
        }

        public async Task<CustomResponseDto<BrandDto>> GetByFilterAsync(Guid id)
        {
            var entity = await _brandRepository.GetByFilterAsync(x => x.Id == id);
            if (entity == null)
            {
                return CustomResponseDto<BrandDto>.Fail(StatusCodes.Status404NotFound, "Aradğınız kategori bulunmadı");
            }
            var newDto = _mapper.Map<BrandDto>(entity);
            return CustomResponseDto<BrandDto>.Success(StatusCodes.Status200OK, newDto);
        }

        public async Task<CustomResponseDto<NoContentDto>> RemoveAsync(Guid id)
        {
            var entity = await _brandRepository.GetByFilterAsync(x => x.Id == id);
            if (entity != null)
            {
                _brandRepository.Remove(entity);
                await _uow.CommitAsync();
                return CustomResponseDto<NoContentDto>.Success(StatusCodes.Status204NoContent);
            }

            return CustomResponseDto<NoContentDto>.Fail(StatusCodes.Status404NotFound, "Kategori bulunamadı");
        }

        public async Task<CustomResponseDto<NoContentDto>> UpdateAsync(BrandUpdateDto brandUpdateDto)
        {

    
            var validationRusult = _updateValidator.Validate(brandUpdateDto);
            if (validationRusult.IsValid)
            {
                var hasCategory = await _brandRepository.GetAllAsync(x => x.Id == brandUpdateDto.Id && x.Id!= brandUpdateDto.Id);
                if (hasCategory.Any())
                {
                    return CustomResponseDto<NoContentDto>.Fail(400, "Bu isimde mevcut marka mevcut");
                }
                var entity = _mapper.Map<BrandEntity>(brandUpdateDto);
                _brandRepository.Update(entity);
                await _uow.CommitAsync();

                var newDto = _mapper.Map<BrandUpdateDto>(entity);
                return CustomResponseDto<NoContentDto>.Success(StatusCodes.Status204NoContent);
            }
            return CustomResponseDto<NoContentDto>.Fail(StatusCodes.Status400BadRequest, validationRusult.ConvertToCustomValidationError());
        }
    }
}

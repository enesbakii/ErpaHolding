using AutoMapper;
using ErpaHolding.Business.DTOs.CategoryDto;
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
    public class CategoryManager : ICategoryService
    {
        private readonly IRepository<CategoryEntity> _categoryRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        private readonly IValidator<CategoryCreateDto> _createValidator;
        private readonly IValidator<CategoryUpdateDto> _updateValidator;



        public CategoryManager(IRepository<CategoryEntity> categoryRepository, IMapper mapper, IUnitOfWork uow, IValidator<CategoryCreateDto> createValidator, IValidator<CategoryUpdateDto> updateValidator)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _uow = uow;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<CustomResponseDto<CategoryCreateDto>> CreateAsync(CategoryCreateDto categoryCreateDto)
        {
            var validationRusult = _createValidator.Validate(categoryCreateDto);
            if (validationRusult.IsValid)
            {
                IEnumerable<CategoryEntity>? hasCategory = await _categoryRepository.GetAllAsync(x => x.Name == categoryCreateDto.Name);
                if (hasCategory.Any())
                {
                    return CustomResponseDto<CategoryCreateDto>.Fail(StatusCodes.Status400BadRequest, "Bu isimde mevcut kategori mevcut");
                }
                var categoryEntity = _mapper.Map<CategoryEntity>(categoryCreateDto);
                await _categoryRepository.CreateAsync(categoryEntity);
                await _uow.CommitAsync();

                var newDto = _mapper.Map<CategoryCreateDto>(categoryEntity);
                return CustomResponseDto<CategoryCreateDto>.Success(StatusCodes.Status200OK, newDto);
            }

            return CustomResponseDto<CategoryCreateDto>.Fail(StatusCodes.Status400BadRequest, validationRusult.ConvertToCustomValidationError());
        }

        public async Task<CustomResponseDto<IEnumerable<CategoryDto>>> GetAllAsync()
        {
            var entity = await _categoryRepository.GetAllAsync();
            var newDto = _mapper.Map<IEnumerable<CategoryDto>>(entity);
            return CustomResponseDto<IEnumerable<CategoryDto>>.Success(StatusCodes.Status200OK, newDto.ToList());
        }

        public async Task<CustomResponseDto<CategoryDto>> GetByFilterAsync(Guid id)
        {
            var entity = await _categoryRepository.GetByFilterAsync(x => x.Id == id);
            if (entity == null)
            {
                return CustomResponseDto<CategoryDto>.Fail(StatusCodes.Status404NotFound, "Aradığınız kategori bulunmadı");
            }
            var newDto = _mapper.Map<CategoryDto>(entity);
            return CustomResponseDto<CategoryDto>.Success(StatusCodes.Status200OK, newDto);

        }

        public async Task<CustomResponseDto<NoContentDto>> RemoveAsync(Guid id)
        {
            var entity = await _categoryRepository.GetByFilterAsync(x => x.Id == id);
            if (entity != null)
            {
                _categoryRepository.Remove(entity);
                await _uow.CommitAsync();
                return CustomResponseDto<NoContentDto>.Success(StatusCodes.Status204NoContent);
            }

            return CustomResponseDto<NoContentDto>.Fail(StatusCodes.Status404NotFound, "Kategori bulunamadı");

        }

        public async Task<CustomResponseDto<NoContentDto>> UpdateAsync(CategoryUpdateDto categoryUpdateDto)
        {
            var validationRusult = _updateValidator.Validate(categoryUpdateDto);
            if (validationRusult.IsValid)
            {
                var hasCategory = await _categoryRepository.GetAllAsync(x => x.Id == categoryUpdateDto.Id && x.Id != categoryUpdateDto.Id);
                if (hasCategory.Any())
                {
                    return CustomResponseDto<NoContentDto>.Fail(400, "Bu isimde mevcut kategori mevcut");
                }
                var entity = _mapper.Map<CategoryEntity>(categoryUpdateDto);
                _categoryRepository.Update(entity);
                await _uow.CommitAsync();

                var newDto = _mapper.Map<CategoryUpdateDto>(entity);
                return CustomResponseDto<NoContentDto>.Success(StatusCodes.Status204NoContent);
            }
            return CustomResponseDto<NoContentDto>.Fail(StatusCodes.Status400BadRequest, validationRusult.ConvertToCustomValidationError());
        }
    }
}

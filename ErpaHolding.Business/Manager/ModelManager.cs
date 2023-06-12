using AutoMapper;
using ErpaHolding.Business.DTOs.ModelDto;
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
    public class ModelManager : IModelService
    {
        private readonly IRepository<ModelEntity> _modelRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        private readonly IValidator<ModelCreateDto> _createValidator;
        private readonly IValidator<ModelUpdateDto> _updateValidator;

        public ModelManager(IRepository<ModelEntity> modelRepository, IMapper mapper, IUnitOfWork uow, IValidator<ModelCreateDto> createValidator, IValidator<ModelUpdateDto> updateValidator)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
            _uow = uow;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<CustomResponseDto<ModelCreateDto>> CreateAsync(ModelCreateDto modelCreateDto)
        {
            var validationRusult = _createValidator.Validate(modelCreateDto);
            if (validationRusult.IsValid)
            {
                var hasModel = await _modelRepository.GetAllAsync(x => x.Name == modelCreateDto.Name);
                if (hasModel.Any())
                {
                    return CustomResponseDto<ModelCreateDto>.Fail(StatusCodes.Status400BadRequest, "Bu isimde mevcut model mevcut");
                }
                var modelEntity = _mapper.Map<ModelEntity>(modelCreateDto);
                await _modelRepository.CreateAsync(modelEntity);
                await _uow.CommitAsync();

                var newDto = _mapper.Map<ModelCreateDto>(modelEntity);
                return CustomResponseDto<ModelCreateDto>.Success(StatusCodes.Status200OK, newDto);
            }

            return CustomResponseDto<ModelCreateDto>.Fail(StatusCodes.Status400BadRequest, validationRusult.ConvertToCustomValidationError());

        }

        public async Task<CustomResponseDto<IEnumerable<ModelDto>>> GetAllAsync()
        {
            var entity = await _modelRepository.GetAllAsync();
            var newDto = _mapper.Map<IEnumerable<ModelDto>>(entity);
            return CustomResponseDto<IEnumerable<ModelDto>>.Success(StatusCodes.Status200OK, newDto.ToList());
        }

        public async Task<CustomResponseDto<ModelDto>> GetByFilterAsync(Guid id)
        {
            var entity = await _modelRepository.GetByFilterAsync(x => x.Id == id);
            if (entity == null)
            {
                return CustomResponseDto<ModelDto>.Fail(StatusCodes.Status404NotFound, "Aradığınız kategori bulunmadı");
            }
            var newDto = _mapper.Map<ModelDto>(entity);
            return CustomResponseDto<ModelDto>.Success(StatusCodes.Status200OK, newDto);
        }

        public async Task<CustomResponseDto<NoContentDto>> RemoveAsync(Guid id)
        {
            var entity = await _modelRepository.GetByFilterAsync(x => x.Id == id);
            if (entity != null)
            {
                _modelRepository.Remove(entity);
                await _uow.CommitAsync();
                return CustomResponseDto<NoContentDto>.Success(StatusCodes.Status204NoContent);
            }

            return CustomResponseDto<NoContentDto>.Fail(StatusCodes.Status404NotFound, "Kategori bulunamadı");
        }

        public async Task<CustomResponseDto<NoContentDto>> UpdateAsync(ModelUpdateDto modelUpdateDto)
        {
            var validationRusult = _updateValidator.Validate(modelUpdateDto);
            if (validationRusult.IsValid)
            {
                var hasModel = await _modelRepository.GetAllAsync(x => x.Id == modelUpdateDto.Id && x.Id != modelUpdateDto.Id);
                if (hasModel.Any())
                {
                    return CustomResponseDto<NoContentDto>.Fail(400, "Bu isimde mevcut kategori mevcut");
                }
                var entity = _mapper.Map<ModelEntity>(modelUpdateDto);
                _modelRepository.Update(entity);
                await _uow.CommitAsync();

                var newDto = _mapper.Map<ModelUpdateDto>(entity);
                return CustomResponseDto<NoContentDto>.Success(StatusCodes.Status204NoContent);
            }
            return CustomResponseDto<NoContentDto>.Fail(StatusCodes.Status400BadRequest, validationRusult.ConvertToCustomValidationError());
        }
    }


}

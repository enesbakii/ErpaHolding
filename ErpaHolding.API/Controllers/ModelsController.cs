using ErpaHolding.Business.DTOs.ModelDto;
using ErpaHolding.Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ErpaHolding.API.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : ControllerBase
    {
        private readonly IModelService _modelService;

        public ModelsController(IModelService modelService)
        {
            _modelService = modelService;
        }
        [HttpPost]
        public async Task<IActionResult> Save(ModelCreateDto modelCreateDto)
        {
            var response = await _modelService.CreateAsync(modelCreateDto);
            if (response.StatusCode != StatusCodes.Status200OK)
            {
                return BadRequest(response.Errors);
            }
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _modelService.GetAllAsync();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = await _modelService.GetByFilterAsync(id);
            if (response.StatusCode == StatusCodes.Status200OK)
            {
                return Ok(response);
            }
            return NotFound(response.Errors);
        }

        [HttpPut]
        public async Task<IActionResult> Update(ModelUpdateDto modelUpdateDto)
        {
            var response = await _modelService.UpdateAsync(modelUpdateDto);
            if (response.StatusCode != StatusCodes.Status204NoContent)
            {
                return BadRequest(response.Errors);
            }
            return NoContent();

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            var responce = await _modelService.RemoveAsync(id);
            if (responce.StatusCode != StatusCodes.Status204NoContent)
            {
                return NotFound(responce.Errors);
            }
            return NoContent();
        }
    }
}

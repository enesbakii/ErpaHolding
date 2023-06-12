using ErpaHolding.Business.DTOs.CategoryDto;
using ErpaHolding.Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ErpaHolding.API.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpPost]
        public async Task<IActionResult> Save(CategoryCreateDto categoryCreateDto)
        {
            var response = await _categoryService.CreateAsync(categoryCreateDto);
            if (response.StatusCode != StatusCodes.Status200OK)
            {                               
                return BadRequest(response.Errors);               
            }
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _categoryService.GetAllAsync();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = await _categoryService.GetByFilterAsync(id);
            if (response.StatusCode == StatusCodes.Status200OK)
            {
                return Ok(response);
            }
            return NotFound(response.Errors);
        }

        [HttpPut]
        public async Task<IActionResult> Update(CategoryUpdateDto categoryUpdateDto)
        {
            var response = await _categoryService.UpdateAsync(categoryUpdateDto);
            if (response.StatusCode != StatusCodes.Status204NoContent)
            {
                return BadRequest(response.Errors);
            }
            return NoContent();

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            var responce = await _categoryService.RemoveAsync(id);
            if (responce.StatusCode!=StatusCodes.Status204NoContent)
            {
                return NotFound(responce.Errors);
            }
            return NoContent();
        }
    }
}

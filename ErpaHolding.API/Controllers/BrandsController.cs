using ErpaHolding.Business.DTOs.BrandDto;
using ErpaHolding.Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ErpaHolding.API.Controllers
{
    [Authorize(Roles ="admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpPost]
        public async Task<IActionResult> Save(BrandCreateDto brandCreateDto)
        {
            var response = await _brandService.CreateAsync(brandCreateDto);
            if (response.StatusCode != StatusCodes.Status200OK)
            {

                return BadRequest(response.Errors);
            }
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _brandService.GetAllAsync();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = await _brandService.GetByFilterAsync(id);
            if (response.StatusCode == StatusCodes.Status200OK)
            {
                return Ok(response);
            }
            return NotFound(response.Errors);
        }

        [HttpPut]
        public async Task<IActionResult> Update(BrandUpdateDto brandUpdateDto)
        {
            var response = await _brandService.UpdateAsync(brandUpdateDto);
            if (response.StatusCode != StatusCodes.Status204NoContent)
            {
                return BadRequest(response.Errors);
            }
            return NoContent();

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            var responce = await _brandService.RemoveAsync(id);
            if (responce.StatusCode != StatusCodes.Status204NoContent)
            {
                return NotFound(responce.Errors);
            }
            return NoContent();
        }
    }
}

using ErpaHolding.Business.DTOs.CartDto;
using ErpaHolding.Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ErpaHolding.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        private readonly ICartDetailService _cartDetailService;

        public CartController(ICartService cartService, ICartDetailService cartDetailService)
        {
            _cartService = cartService;
            _cartDetailService = cartDetailService;
        }
        [Authorize]
        [HttpPost("SaveWithAuthorizedPerson")]
        public async Task<IActionResult> SaveWithAuthorizedPerson(List<CartDetailsDto> cartdetails)
        {
            var userId = Guid.Parse((User.Claims.FirstOrDefault(x => x.Type == "userId")?.Value));

            var cartCreateDto = new CartCreateDto()
            {
                UserId = userId
            };

            var response = await _cartService.CreateAsync(cartCreateDto);


            var cartDetailList = new List<CartDetailsCreateDto>();
            foreach (var cartDetailsDto in cartdetails)
            {
                var cartDetailsCreateDto = new CartDetailsCreateDto()
                {
                    CartId = response.Data.Id,
                    Count = cartDetailsDto.Count,
                    ProductId = cartDetailsDto.ProductId
                };

                cartDetailList.Add(cartDetailsCreateDto);
            }


            await _cartDetailService.CreateAsync(cartDetailList);
            if (response.StatusCode != StatusCodes.Status200OK)
            {

                return BadRequest(response.Errors);
            }
            return Ok();
        }

        [HttpPost("SaveWithUnAuthorizedPerson")]
        public async Task<IActionResult> SaveWithUnAuthorizedPerson(List<CartDetailsDto> cartdetails)
        {
            var cartCreateDto = new CartCreateDto()
            {
                UserId = Guid.NewGuid()
            };            

            var response = await _cartService.CreateAsync(cartCreateDto);


            var cartDetailList = new List<CartDetailsCreateDto>();
            foreach(var cartDetailsDto in cartdetails)
            {
                var cartDetailsCreateDto = new CartDetailsCreateDto()
                {
                    CartId = response.Data.Id,
                    Count = cartDetailsDto.Count,
                    ProductId = cartDetailsDto.ProductId
                };

                cartDetailList.Add(cartDetailsCreateDto);
            }


            await _cartDetailService.CreateAsync(cartDetailList);
            if (response.StatusCode != StatusCodes.Status200OK)
            {

                return BadRequest(response.Errors);
            }
            return Ok();
        }
    }
}

using ErpaHolding.API.Tools;
using ErpaHolding.Business.DTOs.UserDto;
using ErpaHolding.Business.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace ErpaHolding.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public async Task<IActionResult> Save(UserCreateDto userCreateDto)
        {
            var response = await _userService.CreateAsync(userCreateDto);
            if (response.StatusCode != StatusCodes.Status200OK)
            {
                return BadRequest(response.Errors);
            }
            return Ok();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var result = await _userService.LoginAsync(dto);
            if (result.Data.IsLogin)
            {
                var token = TokenGenerator.GenerateToken(result.Data.UserId, result.Data.Roles);
                return Created("", new
                {
                    Token = token,
                });
            }
            return BadRequest("Kullanıcı adı veya şifre hatalı");
        }
        [HttpPost]
        [Route("logout")]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return Ok();
        }
    }
}

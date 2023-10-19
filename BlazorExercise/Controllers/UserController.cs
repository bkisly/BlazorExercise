using System.IdentityModel.Tokens.Jwt;
using BlazorExercise.Models.Dto;
using BlazorExercise.Services.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlazorExercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserCredentialsDto userCredentialsDto)
        {
            try
            {
                await _userService.RegisterUser(userCredentialsDto);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }

            return CreatedAtAction(nameof(Register), userCredentialsDto);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserCredentialsDto userCredentialsDto)
        {
            try
            {
                var token = await _userService.SignIn(userCredentialsDto);
                Response.Cookies.Append("JWT", $"Bearer {token}", new CookieOptions { Expires = DateTime.Now.AddHours(2) });
                return CreatedAtAction(nameof(Login), token);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("logout"), Authorize]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("JWT");
            return NoContent();
        }
    }
}

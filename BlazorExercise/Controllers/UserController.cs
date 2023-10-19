using System.IdentityModel.Tokens.Jwt;
using BlazorExercise.Models.Dto;
using BlazorExercise.Services.User;
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
                return CreatedAtAction(nameof(Login), await _userService.SignIn(userCredentialsDto));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete, Authorize]
        public IActionResult Logout()
        {
            Console.WriteLine($"called by user with name: {User.Identity?.Name}");
            throw new NotImplementedException();
        }
    }
}

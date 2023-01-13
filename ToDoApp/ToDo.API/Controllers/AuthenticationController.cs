using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDo.API.Dtos.User;

namespace ToDo.API.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        /// <summary>
        /// Generates authorization token
        /// </summary>
        /// <returns>Authorization token</returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto loginDto)
        {

            return Ok("Logged in");
        }

        /// <summary>
        /// Registers new user
        /// </summary>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto registerDto)
        {

            return NoContent();
        }
    }
}

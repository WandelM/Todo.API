using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDo.API.Dtos.User;
using ToDo.API.Services;
using ToDo.Domain.Repositories;

namespace ToDo.API.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    [Authorize("AdminPolicy")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUsersRepository _usersRepository;
        private readonly ITokenService _tokenService;

        public AuthenticationController(IUsersRepository usersRepository, ITokenService tokenService)
        {
            _usersRepository = usersRepository ?? throw new NullReferenceException(nameof(usersRepository));
            _tokenService = tokenService ?? throw new NullReferenceException(nameof(tokenService));
        }

        /// <summary>
        /// Generates authorization token
        /// </summary>
        /// <returns>Authorization token</returns>
        [HttpPost("authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginDto loginDto)
        {
            var user = await _usersRepository.GetByEmailAsync(loginDto.Email);

            if (user == null)
                return Unauthorized();

            if (user.Password != loginDto.Password)
                return Unauthorized();

            var token = _tokenService.GetToken(user);

            return Ok(token);
        }
    }
}

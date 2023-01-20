using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDo.API.Dtos.User;
using ToDo.API.Services;
using ToDo.Domain.Models.Users;
using ToDo.Domain.Repositories;

namespace ToDo.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IValidator<UserRegisterDto> _userRegisterValidator;

        public UserController(IUsersRepository usersRepository, IValidator<UserRegisterDto> userRegisterValidator)
        {
            _usersRepository = usersRepository ?? throw new NullReferenceException(nameof(usersRepository));
            _userRegisterValidator = userRegisterValidator ?? throw new NullReferenceException(nameof(userRegisterValidator));
        }

        [HttpGet("current")]
        [Authorize]
        public async Task<ActionResult<UserGetDto>> CurrentUser()
        {
            var userId = int.Parse(User.FindFirst(ClaimNames.UserId)!.Value);

            var user = await _usersRepository.GetByIdAsync(userId);

            return Ok(new UserGetDto(user!.Email, user.CreateDate));
        }

        [HttpPost("register")]
        [Authorize("AdminPolicy")]
        public async Task<IActionResult> Register(UserRegisterDto user)
        {
            var result = _userRegisterValidator.Validate(user);

            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);

                return BadRequest(ModelState);
            }

            var mappedUser = new User()
            {
                Email = user.Email,
                Password = user.Password,
                Role = "User"
            };

            _usersRepository.Add(mappedUser);
            await _usersRepository.SaveChangesAsync();

            return NoContent();
        }
    }
}

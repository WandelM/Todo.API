using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace ToDo.API.Dtos.User
{
    public class UserRegisterDto
    {
        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
    }

    public class UserRegisterValidatior: AbstractValidator<UserRegisterDto>
    {
        public UserRegisterValidatior()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email cannot be empty.");
            RuleFor(x => x.Email).EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible);
            RuleFor(x => x.Email).MaximumLength(100).WithMessage("Email is to long");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password cannot be empty.");
            RuleFor(x => x.Password).Length(5, 50).WithMessage("Password has to contain at least 5 characters");
        }
    }
}

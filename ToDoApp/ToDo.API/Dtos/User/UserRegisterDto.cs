using System.ComponentModel.DataAnnotations;

namespace ToDo.API.Dtos.User
{
    public class UserRegisterDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

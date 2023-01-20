namespace ToDo.API.Dtos.User
{
    public class UserGetDto
    {
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }

        public UserGetDto()
        {
        }

        public UserGetDto(string email, DateTime createdDate)
        {
            Email = email;
            CreatedDate = createdDate;
        }
    }
}

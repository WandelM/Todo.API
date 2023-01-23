using ToDo.Domain.Models.ToDoItems;

namespace ToDo.Domain.Models.Users
{
    public class User : BaseModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public ICollection<ToDoItem> ToDoItems { get; set; }
    }
}

using ToDo.Domain.Models.Users;

namespace ToDo.Domain.Models.ToDoItems
{
    public class ToDoItem : BaseModel
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool IsDone { get; set; }
        public DateTime? DueDate { get; set; }
    }
}

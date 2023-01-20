namespace ToDo.Domain.Models.ToDoItem
{
    public class ToDoItem: BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
    }
}

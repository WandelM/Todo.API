namespace ToDo.API.Dtos.ToDoItems
{
    public class ToDoItemGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool IsDone { get; set; }
        public DateTime? DueDate { get; set; }
    }
}

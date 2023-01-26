using FluentValidation;

namespace ToDo.API.Dtos.ToDoItems
{
    public class ToDoItemCreateDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
    }

    public class ToDoItemValidator : AbstractValidator<ToDoItemCreateDto>
    {
        public ToDoItemValidator()
        {
            RuleFor(i => i.Name).NotEmpty();
            RuleFor(i => i.Name).Length(3, 200);
            RuleFor(i => i.Description).MaximumLength(500);
        }
    }
}

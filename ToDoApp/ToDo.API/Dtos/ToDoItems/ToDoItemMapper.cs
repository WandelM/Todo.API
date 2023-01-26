using AutoMapper;
using ToDo.Domain.Models.ToDoItems;

namespace ToDo.API.Dtos.ToDoItems
{
    public class ToDoItemMapper : Profile
    {
        public ToDoItemMapper(): base()
        {
            CreateMap<ToDoItemCreateDto, ToDoItem>();
            CreateMap<ToDoItem, ToDoItemGetDto>();
        }
    }
}

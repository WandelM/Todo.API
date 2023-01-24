using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDo.API.Dtos.ToDoItem;
using ToDo.API.Services;
using ToDo.Domain.Models.ToDoItems;
using ToDo.Domain.Repositories;

namespace ToDo.API.Controllers
{
    [Route("api/todoitems")]
    [ApiController]
    public class ToDoItemsController : ControllerBase
    {
        private readonly IToDoItemsRepository _itemsRepository;

        public ToDoItemsController(IToDoItemsRepository itemsRepository)
        {
            _itemsRepository = itemsRepository;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IReadOnlyList<ToDoItemGetDto>>> GetAllAsync()
        {
            var userId = User.Claims.First(c => c.Type == ClaimNames.UserId).Value;

            var items = await _itemsRepository.GetAllItemsAsync(int.Parse(userId));

            if (!items.Any())
                return NotFound();

            var mappedItems = items.Select(i =>
            {
                return new ToDoItemGetDto()
                {
                    Id = i.Id,
                    Name = i.Name,
                    Description = i.Description,
                    DueDate = i.DueDate,
                    IsDone = i.IsDone
                };
            });

            return Ok(mappedItems);
        }

        [HttpPost("create")]
        [Authorize]
        public async Task<IActionResult> CreateAsync(ToDoItemCreateDto toDoItem)
        {
            var userId = User.Claims.First(c => c.Type == ClaimNames.UserId).Value;

            var mappedItem = new ToDoItem()
            {
                Name = toDoItem.Name,
                Description = toDoItem.Description,
                DueDate = toDoItem.DueDate,
                UserId = int.Parse(userId)
            };

            _itemsRepository.AddItem(mappedItem);
            await _itemsRepository.SaveChangesAsync();

            return NoContent();
        }
    }
}

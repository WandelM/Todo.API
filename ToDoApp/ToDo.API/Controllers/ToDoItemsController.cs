using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDo.API.Dtos.ToDoItems;
using ToDo.Domain.Models.ToDoItems;
using ToDo.Domain.Repositories;

namespace ToDo.API.Controllers
{
    [Route("api/todoitems")]
    [ApiController]
    public class ToDoItemsController : AppControllerBase
    {
        private readonly IToDoItemsRepository _itemsRepository;
        private readonly IValidator<ToDoItemCreateDto> _toDoValidator;
        private readonly IMapper _mapper;

        public ToDoItemsController(IToDoItemsRepository itemsRepository, IValidator<ToDoItemCreateDto> toDoValidator, IMapper mapper)
        {
            _itemsRepository = itemsRepository;
            _toDoValidator = toDoValidator;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IReadOnlyList<ToDoItemGetDto>>> GetAllAsync()
        {
            var userId = GetAuthorizedUserId();

            var items = await _itemsRepository.GetAllItemsAsync(userId);

            if (!items.Any())
                return NotFound();

            var mappedItems = _mapper.Map<IReadOnlyList<ToDoItemGetDto>>(items);

            return Ok(mappedItems);
        }

        [HttpPost("create")]
        [Authorize]
        public async Task<IActionResult> CreateAsync(ToDoItemCreateDto toDoItem)
        {
            var result = await _toDoValidator.ValidateAsync(toDoItem);

            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                return BadRequest(ModelState);
            }

            var userId = GetAuthorizedUserId();

            var mappedItem = _mapper.Map<ToDoItem>(toDoItem, opt => opt.AfterMap((source, dest) => dest.UserId = userId));

            _itemsRepository.AddItem(mappedItem);
            await _itemsRepository.SaveChangesAsync();

            return NoContent();
        }
    }
}

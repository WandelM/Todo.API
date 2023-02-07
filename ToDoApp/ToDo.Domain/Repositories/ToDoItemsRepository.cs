using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Contexts;
using ToDo.Domain.Models;
using ToDo.Domain.Models.ToDoItems;

namespace ToDo.Domain.Repositories
{
    public interface IToDoItemsRepository
    {
        Task<IReadOnlyList<ToDoItem>> GetAllItemsAsync(int userId);
        void AddItem(ToDoItem toDoItem);
        Task<PagedModel<ToDoItem>> GetPaged(int pageSize, int pageNumber);
        Task SaveChangesAsync();
    }

    public class ToDoItemsRepository : IToDoItemsRepository
    {
        private readonly ToDoContext _toDoContext;

        public ToDoItemsRepository(ToDoContext toDoContext)
        {
            _toDoContext = toDoContext;
        }

        public async Task<IReadOnlyList<ToDoItem>> GetAllItemsAsync(int userId)
        {
            var items = await _toDoContext.ToDoItems.Where(i => i.UserId == userId).ToListAsync();

            return items;
        }

        public void AddItem(ToDoItem toDoItem)
        {
            _toDoContext.Add(toDoItem);
        }

        public async Task SaveChangesAsync()
        {
            await _toDoContext.SaveChangesAsync();
        }

        public async Task<PagedModel<ToDoItem>> GetPaged(int userId, int pageSize, int pageNumber)
        {
            var totalCount = _toDoContext.ToDoItems.Count(item => item.UserId == userId);

            if (totalCount == 0)
                return new PagedModel<ToDoItem>(new List<ToDoItem>(), 0, 0);

            var entities = await _toDoContext.ToDoItems.Where(item => item.UserId == userId)
                .Skip(pageSize * pageNumber)
                .Take(pageNumber)
                .ToListAsync();

            return new PagedModel<ToDoItem>(entities, totalCount, pageSize);
        }
    }
}

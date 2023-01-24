using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Contexts;
using ToDo.Domain.Models.ToDoItems;

namespace ToDo.Domain.Repositories
{
    public interface IToDoItemsRepository
    {
        Task<IReadOnlyList<ToDoItem>> GetAllItemsAsync(int userId);
        void AddItem(ToDoItem toDoItem);
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
    }
}

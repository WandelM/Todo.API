using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Contexts;
using ToDo.Domain.Models.Users;

namespace ToDo.Domain.Repositories
{
    public interface IUsersRepository
    {
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetByIdAsync(int id);
        void Add(User user);
        Task SaveChangesAsync();
    }

    public class UsersRepository : IUsersRepository
    {
        private readonly ToDoContext _toDoContext;

        public UsersRepository(ToDoContext toDoContext)
        {
            _toDoContext = toDoContext ?? throw new NullReferenceException(nameof(ToDoContext));
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            var user = await _toDoContext.Users.FirstOrDefaultAsync(u => u.Email == email);
            return user;
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            var user = await _toDoContext.Users.FindAsync(id);
            return user;
        }

        public void Add(User user)
        {
            _toDoContext.Users.Add(user);
        }

        public async Task SaveChangesAsync()
        {
            await _toDoContext.SaveChangesAsync();
        }
    }
}

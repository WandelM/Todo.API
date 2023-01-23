using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Contexts.EntityConfigurations;
using ToDo.Domain.Models.ToDoItems;
using ToDo.Domain.Models.Users;

namespace ToDo.Domain.Contexts
{
    public class ToDoContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ToDoItem> ToDoItems { get; set; }

        public ToDoContext(DbContextOptions<ToDoContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new UserEntityTypeConfiguration().Configure(modelBuilder.Entity<User>());
            new ToDoItemEntityTypeConfiguration().Configure(modelBuilder.Entity<ToDoItem>());
            base.OnModelCreating(modelBuilder);
        }
    }
}

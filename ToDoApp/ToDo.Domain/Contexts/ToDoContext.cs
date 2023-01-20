using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Contexts.EntityConfigurations;
using ToDo.Domain.Models.Users;

namespace ToDo.Domain.Contexts
{
    public class ToDoContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public ToDoContext(DbContextOptions<ToDoContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new UserEntityTypeConfiguration().Configure(modelBuilder.Entity<User>());

            base.OnModelCreating(modelBuilder);
        }
    }
}

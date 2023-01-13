using Microsoft.EntityFrameworkCore;
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
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            
            modelBuilder.Entity<User>().Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(200);

            modelBuilder.Entity<User>().Property(u => u.Password)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<User>().Property(u => u.Role)
                .IsRequired()
                .HasMaxLength(100);

            base.OnModelCreating(modelBuilder);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Domain.Models.ToDoItems;

namespace ToDo.Domain.Contexts.EntityConfigurations
{
    internal class ToDoItemEntityTypeConfiguration : IEntityTypeConfiguration<ToDoItem>
    {
        public void Configure(EntityTypeBuilder<ToDoItem> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(i => i.IsDone)
                .HasDefaultValue(false);

            builder.Property(i => i.CreateDate)
                .IsRequired()
                .HasDefaultValueSql<DateTime>("DATE('now')");

            builder.Property(i => i.LastUpdateDate)
                .IsRequired()
                .HasDefaultValueSql<DateTime>("DATE('now')")
                .ValueGeneratedOnUpdate();
        }
    }
}

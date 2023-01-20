using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Domain.Models.Users;

namespace ToDo.Domain.Contexts.EntityConfigurations
{
    internal class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(u => u.Password)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.Role)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.CreateDate)
                .IsRequired()
                .HasDefaultValueSql<DateTime>("DATE('now')");

            builder.Property(u => u.LastUpdateDate)
                .IsRequired()
                .HasDefaultValueSql<DateTime>("DATE('now')")
                .ValueGeneratedOnUpdate();
        }
    }
}

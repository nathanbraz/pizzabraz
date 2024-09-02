using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaBraz.Domain.Entities;

namespace PizzaBraz.Infra.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id")
                .HasColumnType("UUID");

            builder.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("name")
                .HasColumnType("VARCHAR(100)");

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("email")
                .HasColumnType("VARCHAR(100)");

            builder.HasIndex(u => u.Email)
                .IsUnique();

            builder.Property(u => u.Password)
                .IsRequired()
                .HasMaxLength(256)
                .HasColumnName("password")
                .HasColumnType("VARCHAR(256)");

            builder.Property(u => u.Role)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("role")
                .HasColumnType("VARCHAR(50)");

            builder.Property(x => x.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("created_at")
                .HasColumnType("TIMESTAMP");

            builder.Property(x => x.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("updated_at")
                .HasColumnType("TIMESTAMP");

        }
    }
}

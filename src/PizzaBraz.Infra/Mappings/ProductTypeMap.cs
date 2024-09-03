using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PizzaBraz.Domain.Entities;
namespace PizzaBraz.Infra.Mappings
{
    public class ProductTypeMap : IEntityTypeConfiguration<ProductType>
    {
        public void Configure(EntityTypeBuilder<ProductType> builder)
        {
            builder.ToTable("product_type");

            builder.HasKey(pt => pt.Id);

            builder.Property(pt => pt.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id")
                .HasColumnType("UUID");

            builder.Property(pt => pt.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("name")
                .HasColumnType("VARCHAR(100)");

            builder.Property(pt => pt.Type)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("type")
                .HasColumnType("VARCHAR(50)");

            builder.Property(pt => pt.Description)
                .HasMaxLength(500)
                .HasColumnName("description")
                .HasColumnType("VARCHAR(500)");

            builder.Property(c => c.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("created_at")
                .HasColumnType("TIMESTAMP");

            builder.Property(c => c.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("TIMESTAMP");
        }
    }
}

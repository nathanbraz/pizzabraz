using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaBraz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBraz.Infra.Mappings
{
    public class CustomerAddressMap : IEntityTypeConfiguration<CustomerAddress>
    {
        public void Configure(EntityTypeBuilder<CustomerAddress> builder)
        {
            builder.ToTable("customer_address"); // Nome da tabela no banco de dados

            builder.HasKey(x => x.Id); // Chave primária

            builder.Property(x => x.Id)
                .HasDefaultValueSql("gen_random_uuid()") // Gera UUID automatixmente
                .HasColumnName("id")
                .HasColumnType("UUID");

            builder.Property(x => x.CustomerId)
                .HasColumnName("customer_id")
                .HasColumnType("UUID");

            builder.Property(x => x.Street)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("street")
                .HasColumnType("VARCHAR(50)");

            builder.Property(x => x.Number)
                .HasMaxLength(10)
                .HasColumnName("number")
                .HasColumnType("VARCHAR(10)");

            builder.Property(x => x.Complement)
                .HasMaxLength(80)
                .HasColumnName("complement")
                .HasColumnType("VARCHAR(80)");

            builder.Property(x => x.Neighborhood)
                .IsRequired()
                .HasMaxLength(80)
                .HasColumnName("neighborhood")
                .HasColumnType("VARCHAR(80)");

            builder.Property(x => x.City)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("city")
                .HasColumnType("VARCHAR(100)");

            builder.Property(x => x.State)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("state")
                .HasColumnType("VARCHAR(100)");

            builder.Property(x => x.ZipCode)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("zip_code")
                .HasColumnType("VARCHAR(20)");

            builder.Property(x => x.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("created_at")
                .HasColumnType("TIMESTAMP");

            builder.Property(x => x.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("TIMESTAMP");

            // Configuração de relacionamento com Customer
            builder.HasOne(x => x.Customer)
                .WithMany(c => c.CustomerAddresses)
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

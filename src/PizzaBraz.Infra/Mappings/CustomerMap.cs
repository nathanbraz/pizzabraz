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
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("customer");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id")
                .HasColumnType("UUID");

            builder.Property(x => x.CompanyId)
                .HasColumnName("company_id")
                .HasColumnType("UUID");

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("name")
                .HasColumnType("VARCHAR(100)");

            builder.Property(c => c.WhatsAppNumber)
                .HasMaxLength(20)
                .HasColumnName("whatsapp_number")
                .HasColumnType("VARCHAR(20)");

            builder.HasIndex(u => u.WhatsAppNumber)
                .IsUnique();

            builder.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("email")
                .HasColumnType("VARCHAR(100)");

            builder.HasIndex(c => c.Email)
                .IsUnique();

            builder.Property(x => x.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("timestamp with time zone");

            builder.Property(x => x.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("timestamp with time zone")
                .IsRequired(false);

            // Configuração de relacionamento com Company
            builder.HasOne(c => c.Company)
                .WithMany(co => co.Customers)
                .HasForeignKey(c => c.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuração de relacionamento com CustomerAddress
            builder.HasMany(c => c.CustomerAddresses)
                .WithOne(ca => ca.Customer)
                .HasForeignKey(ca => ca.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuração de relacionamento com Orders
            builder.HasMany(c => c.Orders)
            .WithOne(o => o.Customer)
            .HasForeignKey(o => o.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

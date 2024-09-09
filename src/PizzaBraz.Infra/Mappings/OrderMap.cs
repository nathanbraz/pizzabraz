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
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("order");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id")
                .HasColumnType("UUID");

            builder.Property(o => o.CustomerId)
                .HasColumnName("customer_id")
                .HasColumnType("UUID");

            builder.Property(o => o.CompanyId)
                .HasColumnName("company_id")
                .HasColumnType("UUID");

            builder.Property(o => o.Date)
                .IsRequired()
                .HasColumnName("date")
                .HasColumnType("TIMESTAMP");

            builder.Property(o => o.Status)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("status")
                .HasColumnType("VARCHAR(50)");

            builder.Property(o => o.Total)
                .IsRequired()
                .HasColumnName("total")
                .HasColumnType("DECIMAL(18, 2)");

            builder.Property(x => x.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("timestamp with time zone");

            builder.Property(x => x.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("timestamp with time zone")
                .IsRequired(false);

            // Configuração do relacionamento com Customer
            builder.HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuração do relacionamento com Company
            builder.HasOne(o => o.Company)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuração do relacionamento com OrderItem
            builder.HasMany(o => o.OrderItems)
                .WithOne(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

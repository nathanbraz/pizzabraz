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
    public class CompanyMap : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("company");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id")
                .HasColumnType("UUID");

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("name")
                .HasColumnType("VARCHAR(100)");

            builder.Property(c => c.Description)
                .HasMaxLength(255)
                .HasColumnName("description")
                .HasColumnType("VARCHAR(255)");

            builder.Property(c => c.CNPJ)
                .IsRequired()
                .HasMaxLength(14)
                .HasColumnName("cnpj")
                .HasColumnType("VARCHAR(14)");

            builder.HasIndex(u => u.CNPJ)
                .IsUnique();

            builder.Property(c => c.Address)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("address")
                .HasColumnType("VARCHAR(255)");

            builder.Property(c => c.Phone)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("phone")
                .HasColumnType("VARCHAR(20)");

            builder.HasIndex(u => u.Phone)
                .IsUnique();

            builder.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("email")
                .HasColumnType("VARCHAR(100)");

            builder.HasIndex(u => u.Email)
                .IsUnique();

            builder.Property(c => c.Subdomain)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("subdomain")
                .HasColumnType("VARCHAR(50)");

            builder.HasIndex(u => u.Subdomain)
                .IsUnique();

            builder.Property(x => x.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("timestamp with time zone");

            builder.Property(x => x.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("timestamp with time zone")
                .IsRequired(false);

            // Relacionamentos
            builder.HasMany(c => c.Products)
                .WithOne(p => p.Company)
                .HasForeignKey(p => p.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.Customers)
                .WithOne(c => c.Company)
                .HasForeignKey(c => c.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.Users)
                .WithOne(u => u.Company)
                .HasForeignKey(u => u.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.Orders)
                .WithOne(o => o.Company)
                .HasForeignKey(o => o.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}

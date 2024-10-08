﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaBraz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBraz.Infra.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("product");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id")
                .HasColumnType("UUID");

            builder.Property(x => x.CompanyId)
                .HasColumnName("company_id")
                .HasColumnType("UUID");

            builder.Property(x => x.ProductTypeId)
                .HasColumnName("product_type_id")
                .HasColumnType("UUID");

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("name")
                .HasColumnType("VARCHAR(100)");

            builder.Property(p => p.Description)
                .HasMaxLength(500)
                .HasColumnName("description")
                .HasColumnType("VARCHAR(500)");

            builder.Property(p => p.Price)
                .IsRequired()
                .HasColumnName("price")
                .HasColumnType("DECIMAL(18,2)");

            builder.Property(x => x.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("timestamp with time zone");

            builder.Property(x => x.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("timestamp with time zone")
                .IsRequired(false);

            // Configuração das chaves estrangeiras
            builder.HasOne(p => p.ProductType)
                .WithMany()
                .HasForeignKey(p => p.ProductTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuração da relação com Company
            builder.HasOne(p => p.Company)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuração da coleção de OrderItems
            builder.HasMany(p => p.OrderItems)
                .WithOne(oi => oi.Product)
                .HasForeignKey(oi => oi.ProductId);
        }
    }
}

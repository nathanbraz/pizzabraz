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
    public class CustomerPhotoMap : IEntityTypeConfiguration<CustomerPhoto>
    {
        public void Configure(EntityTypeBuilder<CustomerPhoto> builder)
        {
            builder.ToTable("customer_photo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id")
                .HasColumnType("UUID");

            builder.Property(up => up.PhotoPath)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(up => up.FileName)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(up => up.FileType)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(up => up.IsMain)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(up => up.DisplayOrder)
                .IsRequired();

            builder.Property(x => x.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("timestamp with time zone");

            builder.Property(x => x.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("timestamp with time zone")
                .IsRequired(false);

            builder.HasOne(up => up.Customer)
                .WithMany(u => u.CustomerPhotos)
                .HasForeignKey(up => up.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
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
    public class CustomerTokenMap : IEntityTypeConfiguration<CustomerToken>
    {
        public void Configure(EntityTypeBuilder<CustomerToken> builder)
        {
            builder.ToTable("customer_tokens");

            builder.HasKey(ct => ct.Id);

            builder.Property(ct => ct.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id")
                .HasColumnType("UUID");

            builder.Property(ct => ct.CustomerId)
                .HasColumnName("customer_id")
                .HasColumnType("UUID");

            builder.Property(ct => ct.Token)
                .HasColumnName("token")
                .HasColumnType("UUID");

            builder.Property(ct => ct.TokenCreatedAt)
                .HasColumnName("token_created_at")
                .HasColumnType("TIMESTAMP");

            builder.Property(ct => ct.TokenExpiresAt)
                .HasColumnName("token_expires_at")
                .HasColumnType("TIMESTAMP");

            builder.Property(ct => ct.IsUsed)
                .HasColumnName("is_used")
                .HasColumnType("BOOLEAN");

            builder.Property(x => x.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("timestamp with time zone");

            builder.Property(x => x.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("timestamp with time zone")
                .IsRequired(false);

            // Configuração do relacionamento com Customer
            builder.HasOne(ct => ct.Customer)
                .WithMany(c => c.CustomerTokens) // Supondo que você tenha uma propriedade ICollection<CustomerToken> na entidade Customer
                .HasForeignKey(ct => ct.CustomerId)
                .OnDelete(DeleteBehavior.Restrict); // Ajuste conforme necessário
        }
    }
}

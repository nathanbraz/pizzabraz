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
            builder.ToTable("customer_token");
        }
    }
}

using Microsoft.EntityFrameworkCore;
using PizzaBraz.Domain.Entities;
using PizzaBraz.Infra.Mappings;

namespace PizzaBraz.Infra.Context
{
    public class PizzaBrazContext : DbContext
    {
        public PizzaBrazContext() { }

        public PizzaBrazContext(DbContextOptions<PizzaBrazContext> options) : base(options) { }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserMap());
        }
    }
}

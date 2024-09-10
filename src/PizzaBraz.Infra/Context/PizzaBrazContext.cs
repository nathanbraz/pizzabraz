using Microsoft.EntityFrameworkCore;
using PizzaBraz.Domain.Entities;
using PizzaBraz.Infra.Mappings;
using System.Reflection.Emit;

namespace PizzaBraz.Infra.Context
{
    public class PizzaBrazContext : DbContext
    {
        public PizzaBrazContext() { }

        public PizzaBrazContext(DbContextOptions<PizzaBrazContext> options) : base(options) { }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerToken> CustomerTokens { get; set; }
        public virtual DbSet<CustomerAddress> CustomerAddresses { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductType> ProductTypes { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<RolePermission> RolePermissions { get; set; }
        public virtual DbSet<UserPhoto> UserPhotos { get; set; }
        public virtual DbSet<ProductPhoto> ProductPhotos { get; set; }
        public virtual DbSet<CustomerPhoto> CustomerPhotos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserMap());
            builder.ApplyConfiguration(new CompanyMap());
            builder.ApplyConfiguration(new CustomerMap());
            builder.ApplyConfiguration(new CustomerTokenMap());
            builder.ApplyConfiguration(new CustomerAddressMap());
            builder.ApplyConfiguration(new ProductMap());
            builder.ApplyConfiguration(new ProductTypeMap());
            builder.ApplyConfiguration(new OrderMap());
            builder.ApplyConfiguration(new OrderItemMap());
            builder.ApplyConfiguration(new RoleMap());
            builder.ApplyConfiguration(new PermissionMap());
            builder.ApplyConfiguration(new UserRoleMap());
            builder.ApplyConfiguration(new RolePermissionMap());
            builder.ApplyConfiguration(new UserPhotoMap());
            builder.ApplyConfiguration(new ProductPhotoMap());
            builder.ApplyConfiguration(new CustomerPhotoMap());
        }
    }
}

using ErpaHolding.DataAccess.Configurations;
using ErpaHolding.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpaHolding.DataAccess.Contexts
{
    public class ErpaHoldingDBContext:DbContext
    {
        public ErpaHoldingDBContext(DbContextOptions<ErpaHoldingDBContext> opt) :base(opt)
        {
               
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new CartDetailConfiguration());
            modelBuilder.ApplyConfiguration(new CartConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguriton());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new UserRolesConfiguration());
            modelBuilder.ApplyConfiguration(new BrandConfiguration());
            modelBuilder.ApplyConfiguration(new ProductImageConfiguration());
            modelBuilder.ApplyConfiguration(new ModelConfiguraiton());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<CartDetailsEntity> CartDetails => Set<CartDetailsEntity>();
        public DbSet<CartEntity> Carts => Set<CartEntity>();
        public DbSet<CategoryEntity> Categories => Set<CategoryEntity>();
        public DbSet<OrderDetailsEntity> OrderDetails => Set<OrderDetailsEntity>();
        public DbSet<OrderEntity> Orders => Set<OrderEntity>();
        public DbSet<ProductEntity> Products => Set<ProductEntity>();
        public DbSet<RoleEntity> Roles => Set<RoleEntity>();
        public DbSet<UserEntity> Users => Set<UserEntity>();
        public DbSet<UserRolesEntity> UserRoles => Set<UserRolesEntity>();
        public DbSet<BrandEntity>Brands => Set<BrandEntity>();
        public DbSet<ProductImagesEntity> ProductImages => Set<ProductImagesEntity>();

        public DbSet<ModelEntity> Models => Set<ModelEntity>();

    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata;
using Domain.Entities;
using Data.Mapping;

namespace Data.Context
{
    public class CartDbContext : DbContext
    {
        public static readonly ILoggerFactory _loggerFactory = LoggerFactory.Create(builder =>
        {
            //builder.AddConsole();
        });

        public CartDbContext(DbContextOptions<CartDbContext> options) : base(options)
        {
        }


        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> subCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Image> Images { get; set; }
        //public DbSet<ProductImage> ProductImages { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(_loggerFactory);
            optionsBuilder.EnableSensitiveDataLogging();

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMapping());
            modelBuilder.ApplyConfiguration(new CategoryMapping());
            modelBuilder.ApplyConfiguration(new SubCategoryMapping());
            //modelBuilder.ApplyConfiguration(new ProductImageMapping());
            modelBuilder.ApplyConfiguration(new CartMapping());
            modelBuilder.ApplyConfiguration(new CartItemMapping());

            modelBuilder
              .Entity<Product>()
              .Property(e => e.CreateDate).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            modelBuilder
              .Entity<Category>()
              .Property(e => e.CreateDate).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            modelBuilder
              .Entity<SubCategory>()
              .Property(e => e.CreateDate).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);




        }

        public async Task<int> SaveChangesAsync()
        {
            ChangeTracker.DetectChanges();

            foreach (var entry in ChangeTracker.Entries<ITrackableEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CreateDate").CurrentValue = DateTime.Now;
                    entry.Property("Inactive").CurrentValue = false;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("ModifyDate").CurrentValue = DateTime.Now;
                }
            }
            return await base.SaveChangesAsync();

        }

        public async Task<int> RemoveAsync()
        {
            ChangeTracker.DetectChanges();

            foreach (var entry in ChangeTracker.Entries<ITrackableEntity>())
            {
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("Inactive").CurrentValue = true;
                }
            }

            return await base.SaveChangesAsync();
        }
    }
}

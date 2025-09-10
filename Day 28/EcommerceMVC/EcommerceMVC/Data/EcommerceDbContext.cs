using EcommerceMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceMVC.Data
{
    public class EcommerceDbContext : DbContext
    {
        public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        // ✅ Seed sample products
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "iPhone 15", Price = 79999, ImageUrl = "/images/iphone16.jpeg" },
                new Product { Id = 2, Name = "Samsung S23", Price = 74999, ImageUrl = "/images/S23.jpg" },
                new Product { Id = 3, Name = "Pixel 9", Price = 69999, ImageUrl = "/images/Pixel.png" },
                new Product { Id = 4, Name = "OnePlus 12", Price = 58999, ImageUrl = "/images/OnePlus.jpeg" }
            );
        }
    }
}

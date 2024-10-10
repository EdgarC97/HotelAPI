using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductsAPI.Models;
using ProductsAPI.Seeders;

namespace ProductsAPI.Data
{
    // DbContext class representing the database context for the Hotel API.
    public class AppDbContext : DbContext
    {
        // Constructor that accepts DbContextOptions for configuring the context.
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }

        // Method called when the model for a derived context is being created.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed the database with initial data for Products, Orders, Categories.
            CategorySeeder.Seed(modelBuilder);
            ProductSeeder.Seed(modelBuilder);
            OrderSeeder.Seed(modelBuilder);
            OrderProductSeeder.Seed(modelBuilder);
            
            // Call the base class implementation.
            base.OnModelCreating(modelBuilder);
        }
    }
}
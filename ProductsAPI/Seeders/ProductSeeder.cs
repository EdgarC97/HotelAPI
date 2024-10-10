using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductsAPI.Models;

namespace ProductsAPI.Seeders
{
    public class ProductSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Smartphone", Description = "Latest model smartphone", Price = 699.99m, Stock = 50, CategoryId = 1 },
                new Product { Id = 2, Name = "Laptop", Description = "Powerful laptop for work and play", Price = 999.99m, Stock = 30, CategoryId = 1 },
                new Product { Id = 3, Name = "Jeans", Description = "Comfortable denim jeans", Price = 49.99m, Stock = 100, CategoryId = 2 },
                new Product { Id = 4, Name = "Blender", Description = "High-speed blender", Price = 89.99m, Stock = 20, CategoryId = 3 },
                new Product { Id = 5, Name = "Basketball", Description = "Durable basketball", Price = 29.99m, Stock = 150, CategoryId = 4 },
                new Product { Id = 6, Name = "Fiction Novel", Description = "Bestselling fiction book", Price = 19.99m, Stock = 200, CategoryId = 5 },
                new Product { Id = 7, Name = "Action Figure", Description = "Collectible action figure", Price = 14.99m, Stock = 75, CategoryId = 6 },
                new Product { Id = 8, Name = "Car Battery", Description = "Reliable car battery", Price = 129.99m, Stock = 25, CategoryId = 7 },
                new Product { Id = 9, Name = "Face Cream", Description = "Hydrating face cream", Price = 24.99m, Stock = 40, CategoryId = 8 },
                new Product { Id = 10, Name = "Office Chair", Description = "Ergonomic office chair", Price = 199.99m, Stock = 15, CategoryId = 9 }
            );
        }
    }
}
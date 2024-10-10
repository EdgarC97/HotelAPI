using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductsAPI.Models;

namespace ProductsAPI.Seeders
{
    public class CategorySeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Electronics", Description = "Devices and gadgets" },
                new Category { Id = 2, Name = "Clothing", Description = "Apparel and accessories" },
                new Category { Id = 3, Name = "Home & Kitchen", Description = "Home appliances and kitchenware" },
                new Category { Id = 4, Name = "Sports", Description = "Sporting goods and equipment" },
                new Category { Id = 5, Name = "Books", Description = "Literature and reading material" },
                new Category { Id = 6, Name = "Toys", Description = "Children's toys and games" },
                new Category { Id = 7, Name = "Automotive", Description = "Car parts and accessories" },
                new Category { Id = 8, Name = "Health & Beauty", Description = "Health products and cosmetics" },
                new Category { Id = 9, Name = "Office Supplies", Description = "Stationery and office equipment" },
                new Category { Id = 10, Name = "Pet Supplies", Description = "Products for pets" }
            );
        }
    }
}
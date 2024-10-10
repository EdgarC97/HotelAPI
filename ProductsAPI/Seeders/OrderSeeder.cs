using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductsAPI.Models;

namespace ProductsAPI.Seeders
{
    public class OrderSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasData(
                    new Order { Id = 1, OrderDate = DateTime.Now, CustomerName = "John Doe", CustomerAddress = "123 Elm St", CustomerContact = "555-1234" },
                    new Order { Id = 2, OrderDate = DateTime.Now, CustomerName = "Jane Smith", CustomerAddress = "456 Oak St", CustomerContact = "555-5678" }
                );
        }
    }
}
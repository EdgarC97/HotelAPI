using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductsAPI.Models;

namespace ProductsAPI.Seeders
{
    public class OrderProductSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderProduct>().HasData(
                    new OrderProduct { Id = 1, OrderId = 1, ProductId = 1, Quantity = 1 },
                    new OrderProduct { Id = 2, OrderId = 1, ProductId = 3, Quantity = 2 },
                    new OrderProduct { Id = 3, OrderId = 2, ProductId = 4, Quantity = 1 },
                    new OrderProduct { Id = 4, OrderId = 2, ProductId = 5, Quantity = 1 }

            );
        }
    }
}
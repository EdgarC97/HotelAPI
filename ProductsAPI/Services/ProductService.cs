using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductsAPI.Data;
using ProductsAPI.DTOS;
using ProductsAPI.Interfaces;

namespace ProductsAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<(List<ProductDTO> products, string message)> GetAllProductsAsync()
        {
            var products = await _context.Products
                .Select(c => new ProductDTO
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    Price = c.Price,
                    Stock = c.Stock,
                    CategoryId = c.CategoryId
                })
                .ToListAsync();

            if (products == null || products.Count == 0)
            {
                return (null, "No products found. Please check back later!");
            }

            return (products, "Products retrieved successfully!");
        }

        public async Task<(ProductDTO product, string message)> GetProductByIdAsync(int id)
        {
            var product = await _context.Products
                .Where(c => c.Id == id)
                .Select(c => new ProductDTO
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    Price = c.Price,
                    Stock = c.Stock,
                    CategoryId = c.CategoryId
                })
                .FirstOrDefaultAsync();

            if (product == null)
            {
                return (null, $"Product with ID {id} not found. Please check the ID and try again.");
            }

            return (product, "Product retrieved successfully!");
        }
    }
}
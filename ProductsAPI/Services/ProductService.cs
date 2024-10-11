using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductsAPI.Data;
using ProductsAPI.DTOS;
using ProductsAPI.Interfaces;
using ProductsAPI.Models;

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
                    CategoryId = c.CategoryId,
                    CategoryName = c.Category.Name
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

        // Asynchronously creates a new product based on the provided CreateProductDTO.
        public async Task<(bool IsSuccess, ProductDTO Product, string Message)> CreateProductAsync(CreateProductDTO createProductDto)
        {
            // Validate input data
            if (string.IsNullOrWhiteSpace(createProductDto.Name))
            {
                return (false, null, "Product name is required.");
            }

            if (createProductDto.Price <= 0)
            {
                return (false, null, "Price must be greater than zero.");
            }

            if (createProductDto.Stock < 0)
            {
                return (false, null, "Stock cannot be negative.");
            }

            if (createProductDto.CategoryId <= 0)
            {
                return (false, null, "Invalid category ID.");
            }

            // Check if category exists
            var categoryExists = await _context.Categories.AnyAsync(c => c.Id == createProductDto.CategoryId);
            if (!categoryExists)
            {
                return (false, null, "Category does not exist.");
            }

            // Create a new Product entity from the provided DTO.
            var product = new Product
            {
                Name = createProductDto.Name,
                Description = createProductDto.Description,
                Price = createProductDto.Price,
                Stock = createProductDto.Stock,
                CategoryId = createProductDto.CategoryId  // Asignar CategoryId
            };

            // Add the new product to the context and save changes to the database.
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            // Map the new Product entity to ProductDTO for the response.
            var productDto = new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
                CategoryId = product.CategoryId
            };

            return (true, productDto, "Product created successfully.");
        }

        // Asynchronously deletes a product by its ID.
        public async Task<(bool IsSuccess, string Message)> DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id); // Find the product by ID.
            if (product == null)
            {
                return (false, "Product not found."); // Return failure if product is not found.
            }

            // Remove the product from the context and save changes to the database.
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return (true, "Product deleted successfully."); // Return success result.
        }

        public async Task<(bool IsSuccess, ProductDTO Product, string Message)> UpdateProductAsync(int id, UpdateProductDTO updateProductDto)
        {
            var product = await _context.Products.FindAsync(id); // Find the product by ID.
            if (product == null)
            {
                return (false, null, "Product not found."); // Return failure if the product is not found.
            }

            // Update the product properties with the new values from the DTO.
            product.Name = updateProductDto.Name;
            product.Description = updateProductDto.Description;
            product.Price = updateProductDto.Price;
            product.Stock = updateProductDto.Stock;
            product.CategoryId = updateProductDto.CategoryId;

            // Save changes to the database.
            await _context.SaveChangesAsync();

            // Map the updated Product entity to ProductDTO for the response.
            var productDto = new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
                CategoryId = product.CategoryId
            };

            return (true, productDto, "Product updated successfully."); // Return success result.
        }

        public async Task<List<ProductDTO>> SearchProductsAsync(string keyword)
        {
            return await _context.Products
                .Where(p => p.Name.Contains(keyword) || p.Description.Contains(keyword))
                .Select(p => new ProductDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    Stock = p.Stock,
                    CategoryId = p.CategoryId
                })
                .ToListAsync();
        }

        public async Task<List<ProductDTO>> GetLowStockProductsAsync(int threshold)
        {
            var lowStockProducts = await _context.Products
                .Where(p => p.Stock <= threshold)
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

            if (lowStockProducts == null || lowStockProducts.Count == 0)
            {
                return null; // Or return an empty list
            }

            return lowStockProducts;
        }
        public async Task<List<ProductDTO>> GetProductsByCategoryAsync(int categoryId)
        {
            return await _context.Products
                .Where(p => p.CategoryId == categoryId)
                .Select(p => new ProductDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    Stock = p.Stock,
                    CategoryId = p.CategoryId
                })
                .ToListAsync();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductsAPI.DTOS;

namespace ProductsAPI.Interfaces
{
    public interface IProductService
    {
        Task<(List<ProductDTO> products, string message)> GetAllProductsAsync();
        Task<(ProductDTO product, string message)> GetProductByIdAsync(int id);

        // Asynchronously creates a new product and returns a tuple indicating success, the created ProductDTO, and a message.
        Task<(bool IsSuccess, ProductDTO Product, string Message)> CreateProductAsync(CreateProductDTO createProductDto);

        // Asynchronously deletes a product by its ID and returns a tuple indicating success and a message.
        Task<(bool IsSuccess, string Message)> DeleteProductAsync(int id);

        Task<(bool IsSuccess, ProductDTO Product, string Message)> UpdateProductAsync(int id, UpdateProductDTO updateProductDto);

        // Search for products by keyword
        Task<List<ProductDTO>> SearchProductsAsync(string keyword);

        // Get low stock products
        Task<List<ProductDTO>> GetLowStockProductsAsync(int threshold);

        // // Get products by category
        Task<List<ProductDTO>> GetProductsByCategoryAsync(int categoryId);
    }
}
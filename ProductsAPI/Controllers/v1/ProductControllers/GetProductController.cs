using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductsAPI.DTOS;
using ProductsAPI.Interfaces;

namespace ProductsAPI.Controllers.v1.ProductControllers
{
    [ApiController]
    [Route("api/v1/products")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class GetProductController : ProductBaseController
    {
        public GetProductController(IProductService productService) : base(productService)
        {
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDTO>>> GetProducts()
        {
            var (products, message) = await _productService.GetAllProductsAsync();
            if (products == null)
            {
                return NotFound(new { message });
            }
            return Ok(new { message, data = products });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProduct(int id)
        {
            var (product, message) = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound(new { message });
            }
            return Ok(new { message, data = product });
        }

        [HttpGet("search/{keyword}")]
        public async Task<ActionResult<List<ProductDTO>>> SearchProducts(string keyword)
        {
            var products = await _productService.SearchProductsAsync(keyword);
            if (products == null || !products.Any())
            {
                return NotFound(new { message = "No products found matching the search criteria." });
            }
            return Ok(new { message = "Products retrieved successfully.", data = products });
        }

        [HttpGet("low-stock/{threshold}")]
        public async Task<ActionResult<List<ProductDTO>>> GetLowStockProducts(int threshold)
        {
            var products = await _productService.GetLowStockProductsAsync(threshold);
            if (products == null || products.Count == 0)
            {
                return NotFound(new { message = "No low stock products found." });
            }
            return Ok(new { message = "Low stock products retrieved successfully.", data = products });
        }

        [HttpGet("categories/{id}/products")]
        public async Task<ActionResult<List<ProductDTO>>> GetProductsByCategory(int id)
        {
            var products = await _productService.GetProductsByCategoryAsync(id);
            if (products == null || !products.Any())
            {
                return NotFound(new { message = $"No products found for category ID {id}." });
            }
            return Ok(new { message = "Products retrieved successfully.", data = products });
        }
    }
}
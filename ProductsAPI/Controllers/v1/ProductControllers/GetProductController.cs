using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductsAPI.DTOS;
using ProductsAPI.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

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

        // GET: api/v1/products
        [SwaggerOperation(Summary = "Get all products", Description = "Retrieves a list of all products in the system.")]
        [SwaggerResponse(200, "Returns a list of products.", typeof(IEnumerable<ProductDTO>))]
        [SwaggerResponse(204, "No products found.")]
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

        // GET: api/v1/products/{id}
        [SwaggerOperation(Summary = "Get product by ID", Description = "Retrieves a specific product by its ID.")]
        [SwaggerResponse(200, "Returns the requested product.", typeof(ProductDTO))]
        [SwaggerResponse(404, "Product not found.")]
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

        // GET: api/v1/products/search/{keyword}
        [SwaggerOperation(Summary = "Search products by keyword", Description = "Retrieves products that match the search criteria.")]
        [SwaggerResponse(200, "Products retrieved successfully.", typeof(IEnumerable<ProductDTO>))]
        [SwaggerResponse(404, "No products found matching the search criteria.")]
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

        // GET: api/v1/products/low-stock/{threshold}
        [SwaggerOperation(Summary = "Get low stock products", Description = "Retrieves products that are below the specified stock threshold.")]
        [SwaggerResponse(200, "Low stock products retrieved successfully.", typeof(IEnumerable<ProductDTO>))]
        [SwaggerResponse(404, "No low stock products found.")]
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

        // GET: api/v1/products/categories/{id}/products
        [SwaggerOperation(Summary = "Get products by category ID", Description = "Retrieves products that belong to a specific category.")]
        [SwaggerResponse(200, "Products retrieved successfully.", typeof(IEnumerable<ProductDTO>))]
        [SwaggerResponse(404, "No products found for the specified category.")]
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
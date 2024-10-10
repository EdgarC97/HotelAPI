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
    }
}
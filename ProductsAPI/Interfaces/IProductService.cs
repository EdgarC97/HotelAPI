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
    }
}
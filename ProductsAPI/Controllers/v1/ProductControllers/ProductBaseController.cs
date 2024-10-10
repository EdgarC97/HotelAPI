using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Interfaces;

namespace ProductsAPI.Controllers.v1
{
    public class ProductBaseController : ControllerBase
    {
        protected readonly IProductService _productService;
        public ProductBaseController(IProductService productService)
        {
            _productService = productService;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Interfaces;

namespace ProductsAPI.Controllers.v1
{
    public class CategoryBaseController : ControllerBase
    {
        protected readonly ICategoryService _categoryService;
        public CategoryBaseController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
    }
}
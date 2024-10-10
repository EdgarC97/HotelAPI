using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Interfaces;

namespace ProductsAPI.Controllers.v1.OrderControllers
{
    public class OrderBaseController : ControllerBase
    {
        protected readonly IOrderService _orderService;
        public OrderBaseController(IOrderService orderService)
        {
            _orderService = orderService;
        }
    }
}
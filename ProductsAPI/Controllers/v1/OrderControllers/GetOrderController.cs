using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Interfaces;

namespace ProductsAPI.Controllers.v1.OrderControllers
{
    [ApiController]
    [Route("api/v1/orders")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class GetOrderController : OrderBaseController
    {
        public GetOrderController(IOrderService orderService) : base(orderService)
        {
        }

        // GET: api/v1/orders
        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var (orders, message) = await _orderService.GetAllOrdersAsync();
            if (orders == null)
            {
                return NotFound(message);
            }
            return Ok(orders);
        }

        // GET: api/v1/orders/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var (order, message) = await _orderService.GetOrderByIdAsync(id);
            if (order == null)
            {
                return NotFound(message);
            }
            return Ok(order);
        }
    }
}
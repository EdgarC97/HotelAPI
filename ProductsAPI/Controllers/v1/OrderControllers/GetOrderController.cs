using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductsAPI.DTOS;
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

        [HttpGet("customer/{customerName}")]
        public async Task<ActionResult<List<OrderDTO>>> GetOrdersByCustomerName(string customerName)
        {
            var (orders, message) = await _orderService.GetOrdersByCustomerNameAsync(customerName);
            if (orders == null)
            {
                return NotFound(new { message });
            }
            return Ok(new { message, data = orders });
        }

        [HttpGet("date/{date}")]
        public async Task<ActionResult<List<OrderDTO>>> GetOrdersByDate(DateTime date)
        {
            var (orders, message) = await _orderService.GetOrdersByDateAsync(date);
            if (orders == null)
            {
                return NotFound(new { message });
            }
            return Ok(new { message, data = orders });
        }
    }
}
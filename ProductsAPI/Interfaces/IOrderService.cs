using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductsAPI.DTOS;

namespace ProductsAPI.Interfaces
{
    public interface IOrderService
    {
        Task<(List<OrderDTO> orders, string message)> GetAllOrdersAsync();
        Task<(OrderDTO order, string message)> GetOrderByIdAsync(int id);
        Task<(bool IsSuccess, OrderDTO Order, string Message)> CreateOrderAsync(CreateOrderDTO createOrderDto);
        Task<(bool IsSuccess, string Message)> DeleteOrderAsync(int id);
        Task<(bool IsSuccess, OrderDTO Order, string Message)> UpdateOrderAsync(int id, UpdateOrderDTO updateOrderDto);
        Task<(List<OrderDTO> orders, string message)> GetOrdersByCustomerNameAsync(string customerName);
        Task<(List<OrderDTO> orders, string message)> GetOrdersByDateAsync(DateTime date);
    }
}
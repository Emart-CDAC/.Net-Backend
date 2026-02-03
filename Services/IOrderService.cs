using Emart_DotNet.Models;
using Emart_DotNet.DTOs;

namespace Emart_DotNet.Services
{
    public interface IOrderService
    {
        Task<Order> PlaceOrderAsync(PlaceOrderRequestDTO req);
        
        Task<Order> UpdateOrderStatusAsync(int orderId, string status);
        
        Task<List<Order>> GetOrdersByUserIdAsync(int userId);
        
        Task<Order> GetOrderByIdAsync(int orderId);
    }
}
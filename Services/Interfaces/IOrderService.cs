using DigitalConstructal.DTOs;
using DigitalConstructal.Entities;

namespace DigitalConstructal.Services.Interfaces
{
    public interface IOrderService
    {
        Task<Order> GetByIdAsync(int id);
        Task<IEnumerable<Order>> GetByCustomerAsync(int customerId);
        Task<IEnumerable<Order>> GetBySellerAsync(int sellerId);
        Task InsertAsync(OrderDto orderDto);
        Task AddProductToOrderAsync(int orderId, int productId, int quantity);
        Task UpdateAsync(int orderId, OrderDto order);
        Task DeleteAsync(int id);
    }
}

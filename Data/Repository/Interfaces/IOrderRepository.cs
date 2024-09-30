using DigitalConstructal.Entities;

namespace DigitalConstructal.Data.Repository.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<List<Order>> GetByCustomerAsync(int customerId);
        Task<List<Order>> GetBySellerAsync(int sellerId);
        Task<decimal> CalculateTotalAmountAsync(Order order);
        Task AddProductToOrderAsync(OrderProduct orderProduct);
    }
}

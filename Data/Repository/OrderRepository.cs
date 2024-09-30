using DigitalConstructal.Data.Repository.Interfaces;
using DigitalConstructal.Entities;
using Microsoft.EntityFrameworkCore;

namespace DigitalConstructal.Data.Repository
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly DigitalContext _context;

        public OrderRepository(DigitalContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetByCustomerAsync(int customerId)
        {
            return await _context.Orders
                                 .Where(p => p.UserLoginId == customerId)
                                 .ToListAsync();
        }

        public async Task<List<Order>> GetBySellerAsync(int sellerId)
        {
            return await _context.Orders
                                 .Where(p => p.SellerId == sellerId)
                                 .ToListAsync();
        }

        public async Task<decimal> CalculateTotalAmountAsync(Order order)
        {
            decimal totalAmount = 0;
            foreach (var orderProduct in order.OrderProducts)
            {
                var product = await _context.Products.FindAsync(orderProduct.ProductId);
                if (product != null)
                {
                    totalAmount += orderProduct.Quantity * product.Price;
                }
            }

            return totalAmount;
        }

        public async Task AddProductToOrderAsync(OrderProduct orderProduct)
        {
            _context.OrderProducts.Add(orderProduct);
            await SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

using AutoMapper;
using DigitalConstructalWeb.Data.Repository.Interfaces;
using DigitalConstructalWeb.DTOs;
using DigitalConstructalWeb.Entities;
using DigitalConstructalWeb.Services.Interfaces;

namespace DigitalConstructalWeb.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IProductRepository productRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            return await _orderRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Order>> GetByCustomerAsync(int customerId)
        {
            return await _orderRepository.GetByCustomerAsync(customerId);
        }

        public async Task<IEnumerable<Order>> GetBySellerAsync(int sellerId)
        {
            return await _orderRepository.GetBySellerAsync(sellerId);
        }

        public async Task InsertAsync(OrderDto orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);

            await _orderRepository.AddAsync(order);
        }

        public async Task AddProductToOrderAsync(int orderId, int productId, int quantity)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order == null)
            {
                throw new Exception("Order not found");
            }

            var product = await _productRepository.GetByIdAsync(productId);
            if (product == null)
            {
                throw new Exception("Product not found");
            }

            // Cria um novo registro de OrderProduct
            var orderProduct = new OrderProduct
            {
                OrderId = orderId,
                ProductId = productId,
                Quantity = quantity
            };

            // Adiciona o produto à ordem
            await _orderRepository.AddProductToOrderAsync(orderProduct);

            order.TotalAmount += await _orderRepository.CalculateTotalAmountAsync(order);

            await _orderRepository.UpdateAsync(order);
        }

        public async Task UpdateAsync(int id, OrderDto orderDto)
        {
            var order = await _orderRepository.GetByIdAsync(id);

            if (order == null)
            {
                throw new Exception($"Order with ID {id} not found.");
            }

            order.OrderStatusId = orderDto.OrderStatusId;
            order.TotalAmount = await _orderRepository.CalculateTotalAmountAsync(order);

            await _orderRepository.UpdateAsync(order);
        }

        public async Task DeleteAsync(int id)
        {
            await _orderRepository.DeleteAsync(id);
        }
    }
}

using MobileStoreManager.Entities;
using MobileStoreManager.Entities.DTO;
using MobileStoreManager.Repository;
using MobileStoreManager.Repository.Interfaces;
using MobileStoreManager.Services.Interfaces;

namespace MobileStoreManager.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public int AddOrder(Order order)
        {
           return _orderRepository.AddOrder(order); 
        }

        public int UpdateOrder(Order order)
        {
            return _orderRepository.UpdateOrder(order);
        }

        public async Task BulkAddOrdersAsync(List<Order> orderList)
        {
            foreach (var order in orderList)
            {
                await _orderRepository.BulkAddOrdersAsync(order);
            }
        }

        public async Task BulkUpdateOrdersAsync(List<Order> orderList)
        {
            foreach (var order in orderList)
            {
                await _orderRepository.BulkUpdateOrdersAsync(order);
            }
        }

        public int DeleteOrder(int orderId)
        {
           return _orderRepository.DeleteOrder(orderId);
        }

        public IEnumerable<OrderDTO> GetAllOrders()
        {
           return _orderRepository.GetAllOrders();
        }

        public Order GetOrderById(int orderId)
        {
           return _orderRepository.GetOrderById(orderId);
        }

       
    }
}

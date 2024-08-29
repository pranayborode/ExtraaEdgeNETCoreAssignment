using MobileStoreManager.Entities.DTO;
using MobileStoreManager.Entities;

namespace MobileStoreManager.Services.Interfaces
{
    public interface IOrderService
    {
        int AddOrder(Order order);
        int UpdateOrder(Order order);

        Task BulkAddOrdersAsync(List<Order> orderList);

        Task BulkUpdateOrdersAsync(List<Order> orderList);

        IEnumerable<OrderDTO> GetAllOrders();

        Order GetOrderById(int orderId);

        int DeleteOrder(int orderId);
    }
}

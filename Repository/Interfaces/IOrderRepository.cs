using MobileStoreManager.Entities.DTO;
using MobileStoreManager.Entities;

namespace MobileStoreManager.Repository.Interfaces
{
    public interface IOrderRepository
    {

        int AddOrder(Order order);
        int UpdateOrder(Order order);

        Task BulkAddOrdersAsync(Order order);

        Task BulkUpdateOrdersAsync(Order order);

        IEnumerable<OrderDTO> GetAllOrders();

        Order GetOrderById(int orderId);

        int DeleteOrder(int orderId);
    }
}

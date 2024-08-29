using Microsoft.EntityFrameworkCore;
using MobileStoreManager.Data;
using MobileStoreManager.Entities;
using MobileStoreManager.Entities.DTO;
using MobileStoreManager.Repository.Interfaces;

namespace MobileStoreManager.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;
        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public int AddOrder(Order order)
        {
            order.IsActive = 1;
            order.OrderDate = DateTime.Now;
            _context.Orders.Add(order);
            int result = _context.SaveChanges();
            return result;
        }

        public int UpdateOrder(Order order)
        {
            int result = 0;
            var _order = _context.Orders.Where(o => o.OrderId == order.OrderId).FirstOrDefault();

            if (_order != null)
            {   
                _order.ProductId = order.ProductId;
                _order.SalePrice = order.SalePrice;
                _order.Discount = order.Discount;
                _order.Quantity = order.Quantity;
                _order.OrderDate = order.OrderDate;
                _order.IsActive = 1;

                result = _context.SaveChanges();
            }
            return result;
        }

        public async Task BulkAddOrdersAsync(Order order)
        {
          
            order.IsActive = 1;
            order.OrderDate = DateTime.Now;
            _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            
        }

        public async Task BulkUpdateOrdersAsync(Order order)
        {
            var _order = await _context.Orders
                                 .FirstOrDefaultAsync(o => o.OrderId == order.OrderId);

            if (_order != null)
            {   
                _order.ProductId = order.ProductId;
                _order.SalePrice = order.SalePrice;
                _order.Discount = order.Discount;
                _order.Quantity = order.Quantity;
                _order.OrderDate = order.OrderDate;
                _order.IsActive = 1;

                await _context.SaveChangesAsync();
            }
        }

        public int DeleteOrder(int orderId)
        {
            int result = 0;
            var order = _context.Orders.Where(o => o.OrderId == orderId).FirstOrDefault();

            if (order != null)
            {
                order.IsActive = 0;
                result = _context.SaveChanges();
            }
            return result;
        }

        public IEnumerable<OrderDTO> GetAllOrders()
        {
            var orderList =
               from o in _context.Orders
               join p in _context.Products
               on o.ProductId equals p.ProductId
               join b in _context.Brands
               on p.BrandId equals b.BrandId
               where o.IsActive == 1
               select new OrderDTO
               {
                   OrderId = o.OrderId,
                   ProductId = o.ProductId,
                   BrandName = b.BrandName,
                   Model = p.Model,
                   Price = p.Price,
                   SalePrice = o.SalePrice,
                   Discount = o.Discount,
                   Quantity = o.Quantity,
                   OrderDate = o.OrderDate,
                   IsActive = o.IsActive,   
     
               };
            return orderList;
        }

        public Order GetOrderById(int orderId)
        {
            var order = _context.Orders.Where(o => o.OrderId == orderId).FirstOrDefault();
            return order;
        }

       
    }
}

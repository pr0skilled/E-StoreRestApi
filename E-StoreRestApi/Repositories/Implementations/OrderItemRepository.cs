using System.Collections.Generic;
using System.Linq;
using E_StoreRestApi.Database;
using E_StoreRestApi.Models.Order;

namespace E_StoreRestApi.Repositories.Implementations
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private EStoreDbContext _context;

        public OrderItemRepository(EStoreDbContext context)
        {
            _context = context;
        }

        public OrderItem FindOrderItemById(long id)
        {
            var orderItem = _context.OrderItems.Find(id);
            return orderItem;
        }

        public IEnumerable<OrderItem> FindOrderItemByOrderId(long orderId)
        {
            var orderItems = _context.OrderItems.Where(o => o.OrderId == orderId);
            return orderItems;
        }

        public IEnumerable<OrderItem> GetAllOrderItems()
        {
            var orderItems = _context.OrderItems;
            return orderItems;
        }

        public void SaveOrderItem(OrderItem orderItem)
        {
            _context.OrderItems.Add(orderItem);
        }

        public void UpdateOrderItem(OrderItem orderItem)
        {
            _context.OrderItems.Update(orderItem);
        }

        public void DeleteOrderItem(OrderItem orderItem)
        {
            _context.OrderItems.Remove(orderItem);
        }
    }
}

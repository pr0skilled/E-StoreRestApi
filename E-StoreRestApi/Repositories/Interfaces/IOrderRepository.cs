using System.Collections.Generic;
using E_StoreRestApi.Models.Order;

namespace E_StoreRestApi.Repositories
{
    public interface IOrderRepository
    {
        Order FindOrderById(long id);
        IEnumerable<Order> GetAllOrders();
        void SaveOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(Order order);
    }
}

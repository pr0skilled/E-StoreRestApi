using E_StoreRestApi.Models.Product;
using E_StoreRestApi.Models.Shared;

namespace E_StoreRestApi.Models.Order
{
    public class OrderItem: BaseObject
    {
        public long OrderId { get; set; }
        public Order Order { get; set; }
        public long ProductId { get; set; }
        public Product.Product Product { get; set; }
        public int Quantity { get; set; }
    }
}

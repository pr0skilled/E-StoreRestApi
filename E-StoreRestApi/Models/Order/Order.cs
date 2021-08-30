using E_StoreRestApi.Models.Shared;
using E_StoreRestApi.Models.Order;
using System.Collections.Generic;

namespace E_StoreRestApi.Models.Order
{
    public class Order : BaseObject
    {
        public decimal OrderTotal { get; set; }
        public decimal OrderItemTotal { get; set; }
        public decimal ShippingCharge { get; set; }
        public long CustomerId { get; set; }
        public Customer.Customer Customer { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public long AddressId { get; set; }
        public Address.Address DeliveryAddress { get; set; }
        public IEnumerable<OrderItem> OrderItems { get; set; }
    }
}

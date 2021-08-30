using E_StoreRestApi.Messages.Request.Order;
using E_StoreRestApi.Messages.Response.Order;
using E_StoreRestApi.Repositories;

namespace E_StoreRestApi.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public GetOrderResponse GetOrder(GetOrderRequest getOrderRequest)
        {
            return new GetOrderResponse();
        }

        public FetchOrdersResponse GetOrders(FetchOrdersRequest fetchOrdersRequest)
        {
            return new FetchOrdersResponse();
        }
    }
}

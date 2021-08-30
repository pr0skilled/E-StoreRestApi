using E_StoreRestApi.Messages.Request.Order;
using E_StoreRestApi.Messages.Response.Order;

namespace E_StoreRestApi.Services
{
    public interface IOrderService
    {
        GetOrderResponse GetOrder(GetOrderRequest getOrderRequest);
        FetchOrdersResponse GetOrders(FetchOrdersRequest fetchOrdersRequest);
    }
}

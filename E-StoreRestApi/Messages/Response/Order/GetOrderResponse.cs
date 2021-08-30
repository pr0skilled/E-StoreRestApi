namespace E_StoreRestApi.Messages.Response.Order
{
    using DataTransferObjects.Order;
    public class GetOrderResponse : ResponseBase
    {
        public OrderDTO Order { get; set; }
    }
}

using E_StoreRestApi.Messages.Request.Order;
using E_StoreRestApi.Messages.Response.Order;
using E_StoreRestApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_StoreRestApi.Controllers
{
    [Authorize(Roles = "Administrator")]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("{id}")]
        public ActionResult<GetOrderResponse> GetOrder(long id)
        {
            var getOrderRequest = new GetOrderRequest
                                        {
                                            Id = id
                                        };
            var getOrderResponse = _orderService.GetOrder(getOrderRequest);
            return getOrderResponse;
        }

        [HttpGet()]
        public ActionResult<FetchOrdersResponse> GetOrders()
        {
            var fetchOrdersRequest = new FetchOrdersRequest { };
            var fetchOrdersResponse = _orderService.GetOrders(fetchOrdersRequest);
            return fetchOrdersResponse;
        }
    }
}
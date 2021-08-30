using E_StoreRestApi.Messages.Request.Checkout;
using E_StoreRestApi.Messages.Response.Checkout;
using E_StoreRestApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_StoreRestApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CheckoutController : ControllerBase
    {
        private readonly ICheckoutService _checkoutService;
        public CheckoutController(ICheckoutService checkoutService)
        {
            _checkoutService = checkoutService;
        }

        [HttpPost]
        public ActionResult<CheckoutResponse> Checkout(CheckoutRequest checkoutRequest)
        {
            var checkoutResponse = _checkoutService.ProcessCheckout(checkoutRequest);
            return checkoutResponse;
        }
    }
}
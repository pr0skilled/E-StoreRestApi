using Microsoft.AspNetCore.Mvc;
using E_StoreRestApi.Messages.Response.Cart;
using E_StoreRestApi.Services.Interfaces;
using E_StoreRestApi.Messages.Request.Cart;

namespace E_StoreRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet]
        public ActionResult<FetchCartResponse> GetCart()
        {
            var fetchCartResponse = _cartService.FetchCart();
            return fetchCartResponse;
        }

        [HttpPost]
        public ActionResult<AddItemToCartResponse> AddItemToCart(AddItemToCartRequest addItemToCartRequest)
        {
            var addItemToCartResponse = _cartService.AddItemToCart(addItemToCartRequest);
            return addItemToCartResponse;
        }

        [HttpDelete("{cartId}/{cartItemId}")]
        public ActionResult<RemoveItemFromCartResponse> RemoveItemFromCart(long cartId, long cartItemId)
        {
            var removeItemFromCartRequest = new RemoveItemFromCartRequest { CartId = cartId, CartItemId = cartItemId };
            var removeItemFromCartResponse = _cartService.RemoveItemFromCart(removeItemFromCartRequest);
            return removeItemFromCartResponse;
        }
    }
}
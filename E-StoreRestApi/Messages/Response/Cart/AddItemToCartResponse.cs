using E_StoreRestApi.Messages.DataTransferObjects.Cart;

namespace E_StoreRestApi.Messages.Response.Cart
{
    public class AddItemToCartResponse : ResponseBase
    {
        public CartItemDTO CartItem { get; set; }
    }
}

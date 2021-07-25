using E_StoreRestApi.Messages.DataTransferObjects.Cart;

namespace E_StoreRestApi.Messages.Request.Cart
{
    public class AddItemToCartRequest
    {
        public long CartId { get; set; }
        public CartItemDTO CartItem { get; set; }
        public long ProductId { get; set; }
    }
}

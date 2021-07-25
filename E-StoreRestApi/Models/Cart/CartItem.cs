using E_StoreRestApi.Models.Shared;

namespace E_StoreRestApi.Models.Cart
{
    public class CartItem : BaseObject
    {
        public long CartId { get; set; }
        public long ProductId { get; set; }
        public Product.Product Product { get; set; }
        public int Quantity { get; set; }
    }
}

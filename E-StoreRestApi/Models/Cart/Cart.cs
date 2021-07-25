using System.Collections.Generic;
using E_StoreRestApi.Models.Shared;

namespace E_StoreRestApi.Models.Cart
{
    public class Cart : BaseObject
    {
        public Cart()
        {
            CartItems = new List<CartItem>();
        }

        public string UniqueCartId { get; set; }
        public IEnumerable<CartItem> CartItems { get; set; }
        public CartStatus CartStatus { get; set; }
    }
}

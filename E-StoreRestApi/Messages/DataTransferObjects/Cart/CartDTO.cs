using System.Collections.Generic;
using E_StoreRestApi.Models.Shared;

namespace E_StoreRestApi.Messages.DataTransferObjects.Cart
{
    public class CartDTO : BaseObject
    {
        public CartDTO()
        {
            CartItems = new List<CartItemDTO>();
        }

        public string UniqueCartId { get; set; }
        public IEnumerable<CartItemDTO> CartItems { get; set; }
        public int CartStatus { get; set; }
    }
}

using System.Collections.Generic;
using E_StoreRestApi.Messages.Request.Cart;
using E_StoreRestApi.Messages.Response.Cart;
using E_StoreRestApi.Models.Cart;

namespace E_StoreRestApi.Services.Interfaces
{
    public interface ICartService
    {
        Cart GetCart();
        AddItemToCartResponse AddItemToCart(AddItemToCartRequest request);
        RemoveItemFromCartResponse RemoveItemFromCart(RemoveItemFromCartRequest request);
        int CartItemsCount();
        string UniqueCartId();
        FetchCartResponse FetchCart();
        IEnumerable<CartItem> GetCartItems();
        decimal GetCartTotal();
    }
}

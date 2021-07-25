using System.Collections.Generic;
using System.Linq;
using E_StoreRestApi.Database;
using E_StoreRestApi.Models.Cart;
using E_StoreRestApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_StoreRestApi.Repositories.Implementations
{
    public class CartItemRepository : ICartItemRepository
    {
        private EStoreDbContext context;

        public CartItemRepository(EStoreDbContext context_)
        {
            context = context_;
        }

        public CartItem FindCartItemById(long id)
        {
            var cartItem = context.CartItems.Find(id);

            return cartItem;
        }

        public IEnumerable<CartItem> FindCartItemsByCartId(long cartId)
        {
            var cartItems = context.CartItems.Where(cartItem => cartItem.CartId == cartId).Include(c => c.Product);
            return cartItems;
        }

        public void SaveCartItem(CartItem cartItem)
        {
            context.CartItems.Add(cartItem);
            context.SaveChanges();
        }

        public void UpdateCartItem(CartItem cartItem)
        {
            context.CartItems.Update(cartItem);
            context.SaveChanges();
        }

        public void DeleteCartItem(CartItem cartItem)
        {
            context.CartItems.Remove(cartItem);
            context.SaveChanges();
        }
    }
}

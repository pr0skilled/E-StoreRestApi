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
        private EStoreDbContext db;

        public CartItemRepository(EStoreDbContext context_)
        {
            db = context_;
        }

        public CartItem FindCartItemById(long id)
        {
            var cartItem = db.CartItems.Find(id);

            return cartItem;
        }

        public IEnumerable<CartItem> FindCartItemsByCartId(long cartId)
        {
            var cartItems = db.CartItems.Where(cartItem => cartItem.CartId == cartId).Include(c => c.Product);
            return cartItems;
        }

        public void SaveCartItem(CartItem cartItem)
        {
            db.CartItems.Add(cartItem);
            db.SaveChanges();
        }

        public void UpdateCartItem(CartItem cartItem)
        {
            db.CartItems.Update(cartItem);
            db.SaveChanges();
        }

        public void DeleteCartItem(CartItem cartItem)
        {
            db.CartItems.Remove(cartItem);
            db.SaveChanges();
        }
    }
}

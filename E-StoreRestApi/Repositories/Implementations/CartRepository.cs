using System.Collections.Generic;
using E_StoreRestApi.Database;
using E_StoreRestApi.Models.Cart;
using E_StoreRestApi.Repositories.Interfaces;

namespace E_StoreRestApi.Repositories.Implementations
{
    public class CartRepository : ICartRepository
    {
        private EStoreDbContext context;

        public CartRepository(EStoreDbContext context_)
        {
            context = context_;
        }

        public Cart FindCartById(long id)
        {
            var cart = context.Carts.Find(id);
            return cart;
        }

        public IEnumerable<Cart> GetAllCarts()
        {
            var carts = context.Carts;
            return carts;
        }

        public void SaveCart(Cart cart)
        {
            context.Carts.Add(cart);
            context.SaveChanges();
        }

        public void UpdateCart(Cart cart)
        {
            context.Carts.Update(cart);
            context.SaveChanges();
        }

        public void DeleteCart(Cart cart)
        {
            context.Carts.Remove(cart);
            context.SaveChanges();
        }
    }
}

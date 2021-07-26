using System.Collections.Generic;
using E_StoreRestApi.Database;
using E_StoreRestApi.Models.Cart;
using E_StoreRestApi.Repositories.Interfaces;

namespace E_StoreRestApi.Repositories.Implementations
{
    public class CartRepository : ICartRepository
    {
        private EStoreDbContext db;

        public CartRepository(EStoreDbContext context_)
        {
            db = context_;
        }

        public Cart FindCartById(long id)
        {
            var cart = db.Carts.Find(id);
            return cart;
        }

        public IEnumerable<Cart> GetAllCarts()
        {
            var carts = db.Carts;
            return carts;
        }

        public void SaveCart(Cart cart)
        {
            db.Carts.Add(cart);
            db.SaveChanges();
        }

        public void UpdateCart(Cart cart)
        {
            db.Carts.Update(cart);
            db.SaveChanges();
        }

        public void DeleteCart(Cart cart)
        {
            db.Carts.Remove(cart);
            db.SaveChanges();
        }
    }
}

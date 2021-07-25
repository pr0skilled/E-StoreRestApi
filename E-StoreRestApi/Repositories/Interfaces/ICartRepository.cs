using System.Collections.Generic;
using E_StoreRestApi.Models.Cart;

namespace E_StoreRestApi.Repositories.Interfaces
{
    public interface ICartRepository
    {
        Cart FindCartById(long id);
        IEnumerable<Cart> GetAllCarts();
        void SaveCart(Cart cart);
        void UpdateCart(Cart cart);
        void DeleteCart(Cart cart);
    }
}

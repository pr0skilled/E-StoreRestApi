using E_StoreRestApi.Models.Address;
using E_StoreRestApi.Models.Cart;
using E_StoreRestApi.Models.Product;
using Microsoft.EntityFrameworkCore;

namespace E_StoreRestApi.Database
{
    public class EStoreDbContext : DbContext
    {
        public EStoreDbContext(DbContextOptions<EStoreDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}

using E_StoreRestApi.Models.Address;
using E_StoreRestApi.Models.Cart;
using E_StoreRestApi.Models.Customer;
using E_StoreRestApi.Models.Order;
using E_StoreRestApi.Models.Product;
using E_StoreRestApi.Models.Shared;
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
        public DbSet<Person> People { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}

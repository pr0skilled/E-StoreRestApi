using E_StoreRestApi.Database;
using E_StoreRestApi.Models.Product;
using E_StoreRestApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_StoreRestApi.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private EStoreDbContext db;

        public ProductRepository(EStoreDbContext context_)
        {
            db = context_;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            var products = db.Products
                .Include(p => p.Category)
                .Include(p => p.Brand);
            return products;
        }

        public Product GetProductById(long id)
        {
            var product = db.Products.Find(id);
            return product;
        }

        public void AddProduct(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            db.Products.Remove(product);
            db.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            db.Products.Update(product);
            db.SaveChanges();
        }
    }
}

using E_StoreRestApi.Models.Product;
using System.Linq;

namespace E_StoreRestApi.Repositories.Interfaces
{
    public interface IProductRepository
    {
        IQueryable<Product> GetAllProducts();
        Product GetProductById(long id);
        void AddProduct(Product product);
        void DeleteProduct(Product product);
        void UpdateProduct(Product product);
    }
}

using E_StoreRestApi.Models.Product;
using System.Collections.Generic;

namespace E_StoreRestApi.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAllCategories();
        Category GetCategoryById(long id);
        void AddCategory(Category category);
        void DeleteCategory(Category category);
        void UpdateCategory(Category category);
    }
}

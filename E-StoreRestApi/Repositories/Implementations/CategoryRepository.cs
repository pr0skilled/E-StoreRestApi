using E_StoreRestApi.Database;
using E_StoreRestApi.Models.Product;
using E_StoreRestApi.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_StoreRestApi.Repositories.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {
        private EStoreDbContext db;

        public CategoryRepository(EStoreDbContext context_)
        {
            db = context_;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            var categories = db.Categories;
            return categories;
        }

        public Category GetCategoryById(long id)
        {
            var category = db.Categories.Find(id);
            return category;
        }

        public void AddCategory(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
        }

        public void DeleteCategory(Category category)
        {
            db.Categories.Remove(category);
            db.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            db.Categories.Update(category);
            db.SaveChanges();
        }
    }
}

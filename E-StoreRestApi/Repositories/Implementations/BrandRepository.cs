using E_StoreRestApi.Database;
using E_StoreRestApi.Models.Product;
using E_StoreRestApi.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_StoreRestApi.Repositories.Implementations
{
    public class BrandRepository : IBrandRepository
    {
        private EStoreDbContext db;

        public BrandRepository(EStoreDbContext context_)
        {
            db = context_;
        }

        public IEnumerable<Brand> GetAllBrands()
        {
            var brands = db.Brands;
            return brands;
        }

        public Brand GetBrandById(long id)
        {
            var brand = db.Brands.Find(id);
            return brand;
        }

        public void AddBrand(Brand brand)
        {
            db.Brands.Add(brand);
            db.SaveChanges();
        }

        public void DeleteBrand(Brand brand)
        {
            db.Brands.Remove(brand);
            db.SaveChanges();
        }

        public void UpdateBrand(Brand brand)
        {
            db.Brands.Update(brand);
            db.SaveChanges();
        }
    }
}

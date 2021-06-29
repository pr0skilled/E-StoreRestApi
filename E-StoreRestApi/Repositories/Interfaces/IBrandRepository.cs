using E_StoreRestApi.Models.Product;
using System.Collections.Generic;

namespace E_StoreRestApi.Repositories.Interfaces
{
    public interface IBrandRepository
    {
        IEnumerable<Brand> GetAllBrands();
        Brand GetBrandById(long id);
        void AddBrand(Brand brand);
        void DeleteBrand(Brand brand);
        void UpdateBrand(Brand brand);
    }
}

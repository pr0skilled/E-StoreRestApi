using E_StoreRestApi.Messages.Request.Brand;
using E_StoreRestApi.Messages.Response.Brand;

namespace E_StoreRestApi.Services.Interfaces
{
    public interface IBrandService
    {
        CreateBrandResponse SaveBrand(CreateBrandRequest brandRequest);
        UpdateBrandResponse EditBrand(UpdateBrandRequest updateBrandRequest);
        GetBrandResponse GetBrand(GetBrandRequest getBrandRequest);
        FetchBrandsResponse GetBrands(FetchBrandsRequest fetchBrandsRequest);
        DeleteBrandResponse DeleteBrand(DeleteBrandRequest deleteBrandRequest);
    }
}

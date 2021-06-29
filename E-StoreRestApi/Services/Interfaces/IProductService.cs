using E_StoreRestApi.Messages.Request.Product;
using E_StoreRestApi.Messages.Response.Product;

namespace E_StoreRestApi.Services.Interfaces
{
    public interface IProductService
    {
        CreateProductResponse SaveProduct(CreateProductRequest createProductRequest);
        UpdateProductResponse EditProduct(UpdateProductRequest updateProductRequest);
        GetProductResponse GetProduct(GetProductRequest getProductRequest);
        FetchProductsResponse GetProducts(FetchProductsRequest fetchProductsRequest);
        DeleteProductResponse DeleteProduct(DeleteProductRequest deleteProductRequest);
    }
}

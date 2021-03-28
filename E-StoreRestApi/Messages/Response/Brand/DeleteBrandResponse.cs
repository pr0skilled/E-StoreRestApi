using E_StoreRestApi.Messages.DataTransferObjects.Product;

namespace E_StoreRestApi.Messages.Response.Brand
{
    public class DeleteBrandResponse: ResponseBase
    {
        public BrandDTO Brand { get; set; }
    }
}

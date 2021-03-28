namespace E_StoreRestApi.Messages.Response.Product
{
    using DataTransferObjects.Product;
    public class GetProductResponse: ResponseBase
    {
        public ProductDTO Product { get; set; }
    }
}

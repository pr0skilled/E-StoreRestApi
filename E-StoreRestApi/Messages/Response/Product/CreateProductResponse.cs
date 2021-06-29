namespace E_StoreRestApi.Messages.Response.Product
{
    using DataTransferObjects.Product;
    public class CreateProductResponse : ResponseBase
    {
        public ProductDTO Product { get; set; }
    }
}

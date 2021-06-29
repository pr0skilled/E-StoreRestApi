namespace E_StoreRestApi.Messages.Response.Product
{
    using DataTransferObjects.Product;
    public class DeleteProductResponse : ResponseBase
    {
        public ProductDTO Product { get; set; }
    }
}

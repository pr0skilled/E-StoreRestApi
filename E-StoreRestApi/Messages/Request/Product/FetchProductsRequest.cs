namespace E_StoreRestApi.Messages.Request.Product
{
    public class FetchProductsRequest
    {
        public int PageNumber { get; set; }
        public int ProductsPerPage { get; set; }
        public string CategorySlug { get; set; }
        public string BrandSlug { get; set; }
    }
}

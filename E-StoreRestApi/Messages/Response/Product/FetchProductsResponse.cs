namespace E_StoreRestApi.Messages.Response.Product
{
    using DataTransferObjects.Product;
    using System.Collections.Generic;
    public class FetchProductsResponse : ResponseBase
    {
        public int ProductsPerPage { get; set; }
        public bool HasPreviousPages { get; set; }
        public bool HasNextPages { get; set; }
        public int CurrentPage { get; set; }
        public int[] Pages { get; set; }
        public IEnumerable<ProductDTO> Products { get; set; }
    }
}

using E_StoreRestApi.Messages.DataTransferObjects.Product;
using System.Collections.Generic;

namespace E_StoreRestApi.Messages.Response.Brand
{
    public class FetchBrandsResponse : ResponseBase
    {
        public int BrandsPerPage { get; set; }
        public bool HasPreviousPages { get; set; }
        public bool HasNextPages { get; set; }
        public int CurrentPage { get; set; }
        public int[] Pages { get; set; }
        public IEnumerable<BrandDTO> Brands { get; set; }
    }
}

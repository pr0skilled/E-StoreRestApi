using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_StoreRestApi.Messages.Request.Product;
using E_StoreRestApi.Messages.Response.Product;

namespace E_StoreRestApi.Services.Interfaces
{
    public interface ICatalogueService
    {
        public FetchProductsResponse FetchProducts(FetchProductsRequest fetchProductsRequest);
    }
}

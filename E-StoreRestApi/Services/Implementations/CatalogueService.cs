﻿using E_StoreRestApi.Messages;
using E_StoreRestApi.Messages.Request.Product;
using E_StoreRestApi.Messages.Response.Product;
using E_StoreRestApi.Models.Product;
using E_StoreRestApi.Repositories.Interfaces;
using E_StoreRestApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace E_StoreRestApi.Services.Implementations
{
    public class CatalogueService : ICatalogueService
    {
        private IProductRepository _productRepository;
        private MessageMapper _messageMapper;

        public CatalogueService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _messageMapper = new MessageMapper();
        }
        public FetchProductsResponse FetchProducts(FetchProductsRequest fetchProductsRequest)
        {
            IEnumerable<Product> products = new List<Product>();

            int productCount = 0;

            if (fetchProductsRequest.CategorySlug == "all-categories" && fetchProductsRequest.BrandSlug == "all-brands")
            {
                productCount = _productRepository.GetAllProducts().Count();
                products = _productRepository.GetAllProducts()
                   .Where(product => product.ProductStatus == ProductStatus.Active)
                   .Skip((fetchProductsRequest.PageNumber - 1) * fetchProductsRequest.ProductsPerPage)
                   .Take(fetchProductsRequest.ProductsPerPage);
            }

            if (fetchProductsRequest.CategorySlug != "all-categories" && fetchProductsRequest.BrandSlug != "all-brands")
            {
                var filteredProducts = _productRepository.GetAllProducts()
                                                         .Where(product => product.ProductStatus == ProductStatus.Active &&
                                                                           product.Category.Slug == fetchProductsRequest.CategorySlug &&
                                                                           product.Brand.Slug == fetchProductsRequest.BrandSlug);
                productCount = filteredProducts.Count();
                products = filteredProducts.Skip((fetchProductsRequest.PageNumber - 1) * fetchProductsRequest.ProductsPerPage)
                                           .Take(fetchProductsRequest.ProductsPerPage);
            }

            if (fetchProductsRequest.CategorySlug != "all-categories" && fetchProductsRequest.BrandSlug == "all-brands")
            {
                var filteredProducts = _productRepository.GetAllProducts()
                                                         .Where(product => product.ProductStatus == ProductStatus.Active &&
                                                                           product.Category.Slug == fetchProductsRequest.CategorySlug);
                productCount = filteredProducts.Count();
                products = filteredProducts.Skip((fetchProductsRequest.PageNumber - 1) * fetchProductsRequest.ProductsPerPage)
                                           .Take(fetchProductsRequest.ProductsPerPage);
            }

            if (fetchProductsRequest.CategorySlug == "all-categories" && fetchProductsRequest.BrandSlug != "all-brands")
            {
                var filteredProducts = _productRepository.GetAllProducts()
                                                         .Where(product => product.ProductStatus == ProductStatus.Active &&
                                                                           product.Brand.Slug == fetchProductsRequest.BrandSlug);
                productCount = filteredProducts.Count();
                products = filteredProducts.Skip((fetchProductsRequest.PageNumber - 1) * fetchProductsRequest.ProductsPerPage)
                                           .Take(fetchProductsRequest.ProductsPerPage);
            }

            var totalPages = (int)Math.Ceiling((decimal)productCount / fetchProductsRequest.ProductsPerPage);

            int[] pages = Enumerable.Range(1, totalPages).ToArray();

            var productDTOs = _messageMapper.MapToProductDTOs(products);

            var fetchProductsResponse = new FetchProductsResponse()
            {
                ProductsPerPage = fetchProductsRequest.ProductsPerPage,
                Products = productDTOs,
                HasPreviousPages = fetchProductsRequest.PageNumber > 1,
                CurrentPage = fetchProductsRequest.PageNumber,
                HasNextPages = fetchProductsRequest.PageNumber < totalPages,
                Pages = pages
            };

            if (fetchProductsResponse.CurrentPage > pages.Length)
            {
                fetchProductsResponse.StatusCode = HttpStatusCode.NoContent;
            }

            return fetchProductsResponse;
        }
    }
}

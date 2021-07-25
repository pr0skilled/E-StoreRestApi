using System;
using System.Net;
using E_StoreRestApi.Messages;
using E_StoreRestApi.Messages.DataTransferObjects.Product;
using E_StoreRestApi.Messages.Request.Product;
using E_StoreRestApi.Messages.Response.Product;
using E_StoreRestApi.Models.Product;
using E_StoreRestApi.Repositories.Interfaces;
using E_StoreRestApi.Services.Interfaces;

namespace E_StoreRestApi.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly ICatalogueService catalogueService;
        private MessageMapper messageMapper;
        public ProductService(IProductRepository productRepository_, ICatalogueService catalogueService_)
        {
            productRepository = productRepository_;
            catalogueService = catalogueService_;
            messageMapper = new MessageMapper();
        }

        public DeleteProductResponse DeleteProduct(DeleteProductRequest deleteProductRequest)
        {
            var response = new DeleteProductResponse();
            try
            {
                Product product = productRepository.GetProductById(deleteProductRequest.Id);
                if (product == null) throw new Exception();
                productRepository.DeleteProduct(product);
                ProductDTO productDTO = messageMapper.MapToProductDTO(product);
                response.Product = productDTO;
                response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.NotFound;
                response.Messages.Add(ex.ToString());
            }
            return response;
        }

        public UpdateProductResponse EditProduct(UpdateProductRequest updateProductRequest)
        {
            var response = new UpdateProductResponse();
            try
            {
                Product product = messageMapper.MapToProduct(updateProductRequest.Product);
                if (product == null) throw new Exception();
                product.ModifiedDate = DateTimeOffset.Now;
                productRepository.UpdateProduct(product);
                response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.NotFound;
                response.Messages.Add(ex.ToString());
            }
            return response;
        }

        public GetProductResponse GetProduct(GetProductRequest getProductRequest)
        {
            var response = new GetProductResponse();
            try
            {
                Product product = productRepository.GetProductById(getProductRequest.Id);
                if (product == null) throw new Exception();
                ProductDTO productDTO = messageMapper.MapToProductDTO(product);
                response.Product = productDTO;
                response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.NotFound;
                response.Messages.Add(ex.ToString());
            }
            return response;
        }

        public FetchProductsResponse GetProducts(FetchProductsRequest fetchProductsRequest)
        {
            var response = new FetchProductsResponse();
            try
            {
                response = catalogueService.FetchProducts(fetchProductsRequest);
                if (response == null) throw new Exception();
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.NotFound;
                response.Messages.Add(ex.Message);
            }
            return response;
        }

        public CreateProductResponse SaveProduct(CreateProductRequest createProductRequest)
        {
            var response = new CreateProductResponse();
            try
            {
                if (createProductRequest.Product != null) throw new Exception();
                Product product = messageMapper.MapToProduct(createProductRequest.Product);
                product.CreateDate = DateTimeOffset.Now;
                product.ModifiedDate = DateTimeOffset.Now;
                productRepository.AddProduct(product);
                ProductDTO productDTO = messageMapper.MapToProductDTO(product);
                response.Product = productDTO;
                response.StatusCode = HttpStatusCode.Created;
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.Messages.Add(ex.Message);
            }
            return response;
        }
    }
}

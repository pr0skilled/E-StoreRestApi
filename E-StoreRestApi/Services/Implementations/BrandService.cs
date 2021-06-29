using E_StoreRestApi.Messages;
using E_StoreRestApi.Messages.DataTransferObjects.Product;
using E_StoreRestApi.Messages.Request.Brand;
using E_StoreRestApi.Messages.Response.Brand;
using E_StoreRestApi.Models.Product;
using E_StoreRestApi.Repositories.Interfaces;
using E_StoreRestApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace E_StoreRestApi.Services.Implementations
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository brandRepository;
        private MessageMapper messageMapper;
        public BrandService(IBrandRepository brandRepository_)
        {
            brandRepository = brandRepository_;
            messageMapper = new MessageMapper();
        }

        public DeleteBrandResponse DeleteBrand(DeleteBrandRequest deleteBrandRequest)
        {
            var response = new DeleteBrandResponse();
            try
            {
                Brand brand = brandRepository.GetBrandById(deleteBrandRequest.Id);
                if (brand == null) throw new Exception();
                brandRepository.DeleteBrand(brand);
                BrandDTO brandDTO = messageMapper.MapToBrandDTO(brand);
                response.Brand = brandDTO;
                response.StatusCode = HttpStatusCode.OK;
            }
            catch
            {
                response.StatusCode = HttpStatusCode.NotFound;
                response.Messages.Add("Brand you want to delete doesn't exist.");
            }
            return response;
        }

        public UpdateBrandResponse EditBrand(UpdateBrandRequest updateBrandRequest)
        {
            var response = new UpdateBrandResponse();
            try
            {
                Brand brand = messageMapper.MapToBrand(updateBrandRequest.Brand);
                if (brand == null) throw new Exception();
                brandRepository.UpdateBrand(brand);
                response.StatusCode = HttpStatusCode.OK;
            }
            catch
            {
                response.StatusCode = HttpStatusCode.NotFound;
                response.Messages.Add("Brand you want to update doesn't exist.");
            }
            return response;
        }

        public GetBrandResponse GetBrand(GetBrandRequest getBrandRequest)
        {
            var response = new GetBrandResponse();
            try
            {
                Brand brand = brandRepository.GetBrandById(getBrandRequest.Id);
                if (brand == null) throw new Exception();
                BrandDTO brandDTO = messageMapper.MapToBrandDTO(brand);
                response.Brand = brandDTO;
                response.StatusCode = HttpStatusCode.OK;
            }
            catch
            {
                response.StatusCode = HttpStatusCode.NotFound;
                response.Messages.Add("Brand doesn't exist.");
            }
            return response;
        }

        public FetchBrandsResponse GetBrands(FetchBrandsRequest fetchBrandsRequest)
        {
            var response = new FetchBrandsResponse();
            try
            {
                IEnumerable<Brand> brands = brandRepository.GetAllBrands();
                if (brands == null) throw new Exception();
                List<BrandDTO> brandDTOs = messageMapper.MapToBrandDTOs(brands);
                int totalBrands = brandDTOs.Count;
                int totalPages = (int)Math.Ceiling((decimal)totalBrands / 3); // ... / fetchBrandsRequest.BrandsPerPage
                int[] pages = Enumerable.Range(1, totalPages).ToArray();
                response.BrandsPerPage = fetchBrandsRequest.BrandsPerPage;
                response.HasPreviousPages = (fetchBrandsRequest.PageNumber > 1);
                response.HasNextPages = (fetchBrandsRequest.PageNumber < totalPages);
                response.CurrentPage = fetchBrandsRequest.PageNumber;
                response.Pages = pages;
                response.Brands = brandDTOs;
                response.StatusCode = HttpStatusCode.OK;
            }
            catch
            {
                response.StatusCode = HttpStatusCode.NotFound;
                response.Messages.Add("No any brands in the DB.");
            }
            return response;
        }

        public CreateBrandResponse SaveBrand(CreateBrandRequest brandRequest)
        {
            var response = new CreateBrandResponse();
            if (brandRequest.Brand != null) 
            {
                Brand brand = messageMapper.MapToBrand(brandRequest.Brand);
                brand.CreateDate = DateTime.Now;
                brand.ModifiedDate = DateTime.Now;
                brandRepository.AddBrand(brand);
                BrandDTO brandDTO = messageMapper.MapToBrandDTO(brand);
                response.Brand = brandDTO;
                response.StatusCode = HttpStatusCode.Created;
            }
            else
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.Messages.Add("Brand is null");
            }
            return response;
        }
    }
}

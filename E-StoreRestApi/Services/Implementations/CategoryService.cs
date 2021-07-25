using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using E_StoreRestApi.Messages;
using E_StoreRestApi.Messages.DataTransferObjects.Product;
using E_StoreRestApi.Messages.Request.Category;
using E_StoreRestApi.Messages.Response.Category;
using E_StoreRestApi.Models.Product;
using E_StoreRestApi.Repositories.Interfaces;
using E_StoreRestApi.Services.Interfaces;

namespace E_StoreRestApi.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly MessageMapper messageMapper;
        private ICategoryRepository categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository_)
        {
            categoryRepository = categoryRepository_;
            messageMapper = new MessageMapper();
        }

        public DeleteCategoryResponse DeleteCategory(DeleteCategoryRequest deleteCategoryRequest)
        {
            var response = new DeleteCategoryResponse();
            try
            {
                Category category = categoryRepository.GetCategoryById(deleteCategoryRequest.Id);
                if (category == null) throw new Exception();
                categoryRepository.DeleteCategory(category);
                CategoryDTO categoryDTO = messageMapper.MapToCategoryDTO(category);
                response.Category = categoryDTO;
                response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.NotFound;
                response.Messages.Add(ex.ToString());
            }
            return response;
        }

        public UpdateCategoryResponse EditCategory(UpdateCategoryRequest updateCategoryRequest)
        {
            var response = new UpdateCategoryResponse();
            try
            {
                Category category = messageMapper.MapToCategory(updateCategoryRequest.Category);
                if (category == null) throw new Exception();
                category.ModifiedDate = DateTimeOffset.Now;
                categoryRepository.UpdateCategory(category);
                response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.NotFound;
                response.Messages.Add(ex.ToString());
            }
            return response;
        }

        public FetchCategoriesResponse GetCategories(FetchCategoryRequest fetchCategoryRequest)
        {
            var response = new FetchCategoriesResponse();
            try
            {
                IEnumerable<Category> categories = categoryRepository.GetAllCategories();
                if (categories == null) throw new Exception();
                List<CategoryDTO> categoryDTOs = messageMapper.MapToCategoryDTOs(categories);
                int totalCategories = categoryDTOs.Count;
                int totalPages = (int)Math.Ceiling((decimal)totalCategories / 3); // fetchCategoryRequest.CategoriesPerPage
                int[] pages = Enumerable.Range(1, totalPages).ToArray();
                response.CategoriesPerPage = fetchCategoryRequest.CategoriesPerPage;
                response.HasPreviousPages = (fetchCategoryRequest.PageNumber > 1);
                response.HasNextPages = (fetchCategoryRequest.PageNumber < totalPages);
                response.CurrentPage = fetchCategoryRequest.PageNumber;
                response.Pages = pages;
                response.Categories = categoryDTOs;
                response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.NotFound;
                response.Messages.Add(ex.Message);
            }
            return response;
        }

        public GetCategoryResponse GetCategory(GetCategoryRequest getCategoryRequest)
        {
            var response = new GetCategoryResponse();
            try
            {
                Category category = categoryRepository.GetCategoryById(getCategoryRequest.Id);
                if (category == null) throw new Exception();
                CategoryDTO categoryDTO = messageMapper.MapToCategoryDTO(category);
                response.Category = categoryDTO;
                response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.NotFound;
                response.Messages.Add(ex.ToString());
            }
            return response;
        }

        public CreateCategoryResponse SaveCategory(CreateCategoryRequest createCategoryRequest)
        {
            var response = new CreateCategoryResponse();
            if (createCategoryRequest.Category != null)
            {
                Category category = messageMapper.MapToCategory(createCategoryRequest.Category);
                category.CreateDate = DateTimeOffset.Now;
                category.ModifiedDate = DateTimeOffset.Now;
                categoryRepository.AddCategory(category);
                CategoryDTO categoryDTO = messageMapper.MapToCategoryDTO(category);
                response.Category = categoryDTO;
                response.StatusCode = HttpStatusCode.Created;
            }
            else
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.Messages.Add("Category is null");
            }
            return response;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_StoreRestApi.Messages.Request.Category;
using E_StoreRestApi.Messages.Response.Category;
using E_StoreRestApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_StoreRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("{id}")]
        public ActionResult<GetCategoryResponse> GetCategory(long id)
        {
            var getCategoryRequest = new GetCategoryRequest
            {
                Id = id
            };
            var getCategoryResponse = _categoryService.GetCategory(getCategoryRequest);
            return getCategoryResponse;
        }

        [HttpGet]
        public ActionResult<FetchCategoriesResponse> GetCategories()
        {
            var fetchCategoryRequest = new FetchCategoryRequest { };
            var fetchCategoriesResponse = _categoryService.GetCategories(fetchCategoryRequest);
            return fetchCategoriesResponse;
        }

        [HttpPost]
        public ActionResult<CreateCategoryResponse> PostCategory(CreateCategoryRequest createCategoryRequest)
        {
            var createCategoryResponse = _categoryService.SaveCategory(createCategoryRequest);
            return createCategoryResponse;
        }

        [HttpPut()]
        public ActionResult<UpdateCategoryResponse> PutCategory(UpdateCategoryRequest updateCategoryRequest)
        {
            var updateCategoryResponse = _categoryService.EditCategory(updateCategoryRequest);
            return updateCategoryResponse;
        }

        [HttpDelete("{id}")]
        public ActionResult<DeleteCategoryResponse> DeleteCategory(long id)
        {
            var deleteCategoryRequest = new DeleteCategoryRequest
            {
                Id = id
            };
            var deleteCategoryResponse = _categoryService.DeleteCategory(deleteCategoryRequest);
            return deleteCategoryResponse;
        }
    }
}

using E_StoreRestApi.Messages.Request.Category;
using E_StoreRestApi.Messages.Response.Category;

namespace E_StoreRestApi.Services.Interfaces
{
    public interface ICategoryService
    {
        CreateCategoryResponse SaveCategory(CreateCategoryRequest createCategoryRequest);
        UpdateCategoryResponse EditCategory(UpdateCategoryRequest updateCategoryRequest);
        GetCategoryResponse GetCategory(GetCategoryRequest getCategoryRequest);
        FetchCategoriesResponse GetCategories(FetchCategoryRequest fetchCategoryRequest);
        DeleteCategoryResponse DeleteCategory(DeleteCategoryRequest deleteCategoryRequest);
    }
}

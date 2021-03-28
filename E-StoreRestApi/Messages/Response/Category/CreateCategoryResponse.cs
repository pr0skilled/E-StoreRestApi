namespace E_StoreRestApi.Messages.Response.Category
{
    using DataTransferObjects.Product;
    public class CreateCategoryResponse:ResponseBase
    {
        public CategoryDTO Category { get; set; }
    }
}

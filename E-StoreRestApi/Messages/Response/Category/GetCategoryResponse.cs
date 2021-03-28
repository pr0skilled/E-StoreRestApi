namespace E_StoreRestApi.Messages.Response.Category
{
    using DataTransferObjects.Product;
    public class GetCategoryResponse:ResponseBase
    {
        public CategoryDTO Category { get; set; }
    }
}

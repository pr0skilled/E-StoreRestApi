namespace E_StoreRestApi.Messages.Response.Category
{
    using DataTransferObjects.Product;
    public class DeleteCategoryResponse : ResponseBase
    {
        public CategoryDTO Category { get; set; }
    }
}

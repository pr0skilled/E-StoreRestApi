﻿namespace E_StoreRestApi.Messages.Request.Category
{
    public class FetchCategoryRequest
    {
        public int PageNumber { get; set; }
        public int CategoriesPerPage { get; set; }
    }
}

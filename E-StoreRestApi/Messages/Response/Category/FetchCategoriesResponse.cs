﻿namespace E_StoreRestApi.Messages.Response.Category
{
    using DataTransferObjects.Product;
    using System.Collections.Generic;
    public class FetchCategoriesResponse : ResponseBase
    {
        public int CategoriesPerPage { get; set; }
        public bool HasPreviousPages { get; set; }
        public bool HasNextPages { get; set; }
        public int CurrentPage { get; set; }
        public int[] Pages { get; set; }
        public IEnumerable<CategoryDTO> Categories { get; set; }
    }
}

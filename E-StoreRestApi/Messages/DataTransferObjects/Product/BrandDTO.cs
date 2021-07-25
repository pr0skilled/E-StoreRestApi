﻿using E_StoreRestApi.Models.Shared;

namespace E_StoreRestApi.Messages.DataTransferObjects.Product
{
    public class BrandDTO : BaseObject
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeywords { get; set; }
        public int BrandStatus { get; set; }
    }
}

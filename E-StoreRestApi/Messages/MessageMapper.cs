using E_StoreRestApi.Messages.DataTransferObjects.Product;
using E_StoreRestApi.Models.Product;
using System.Collections.Generic;

namespace E_StoreRestApi.Messages
{
    public class MessageMapper
    {
        public Brand MapToBrand(BrandDTO brandDTO)
        {
            var brand = new Brand
            {
                Id = brandDTO.Id,
                Name = brandDTO.Name,
                Slug = brandDTO.Slug,
                Description = brandDTO.Description,
                MetaDescription = brandDTO.MetaDescription,
                MetaKeywords = brandDTO.MetaKeywords,
                BrandStatus = (BrandStatus)brandDTO.BrandStatus,
                ModifiedDate = brandDTO.ModifiedDate,
                CreateDate = brandDTO.CreateDate,
                IsDeleted = brandDTO.IsDeleted
            };

            return brand;
        }

        public BrandDTO MapToBrandDTO(Brand brand)
        {
            var brandDTO = new BrandDTO();

            if (brand != null)
            {
                brandDTO.Id = brand.Id;
                brandDTO.Name = brand.Name;
                brandDTO.Slug = brand.Slug;
                brandDTO.Description = brand.Description;
                brandDTO.MetaDescription = brand.MetaDescription;
                brandDTO.MetaKeywords = brand.MetaKeywords;
                brandDTO.BrandStatus = (int)brand.BrandStatus;
                brandDTO.CreateDate = brand.CreateDate;
                brandDTO.ModifiedDate = brand.ModifiedDate;
                brandDTO.IsDeleted = brand.IsDeleted;
            }

            return brandDTO;
        }

        public Category MapToCategory(CategoryDTO categoryDTO)
        {
            var category = new Category
            {
                Id = categoryDTO.Id,
                Name = categoryDTO.Name,
                Slug = categoryDTO.Slug,
                Description = categoryDTO.Description,
                MetaDescription = categoryDTO.MetaDescription,
                MetaKeywords = categoryDTO.MetaKeywords,
                CategoryStatus = (CategoryStatus)categoryDTO.CategoryStatus,
                ModifiedDate = categoryDTO.ModifiedDate,
                CreateDate = categoryDTO.CreateDate,
                IsDeleted = categoryDTO.IsDeleted
            };

            return category;
        }

        public CategoryDTO MapToCategoryDTO(Category category)
        {
            return new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
                Slug = category.Slug,
                Description = category.Description,
                MetaDescription = category.MetaDescription,
                MetaKeywords = category.MetaKeywords,
                CategoryStatus = (int)category.CategoryStatus,
                ModifiedDate = category.ModifiedDate,
                CreateDate = category.CreateDate,
                IsDeleted = category.IsDeleted
            };
        }

        public Product MapToProduct(ProductDTO productDTO)
        {
            var product = new Product
            {
                Id = productDTO.Id,
                Name = productDTO.Name,
                Slug = productDTO.Slug,
                Description = productDTO.Description,
                MetaDescription = productDTO.MetaDescription,
                MetaKeywords = productDTO.MetaKeywords,
                SKU = productDTO.MetaDescription,
                Model = productDTO.MetaKeywords,
                Price = productDTO.Price,
                SalePrice = productDTO.SalePrice,
                OldPrice = productDTO.OldPrice,
                ImageUrl = productDTO.ImageUrl,
                QuantityInStock = productDTO.QuantityInStock,
                IsBestseller = productDTO.IsBestseller,
                CategoryId = productDTO.CategoryId,
                BrandId = productDTO.BrandId,
                ProductStatus = (ProductStatus)productDTO.ProductStatus,
                CreateDate = productDTO.CreateDate,
                ModifiedDate = productDTO.ModifiedDate,
                IsDeleted = productDTO.IsDeleted
            };

            return product;
        }

        public ProductDTO MapToProductDTO(Product product)
        {
            var productDTO = new ProductDTO();

            if (product != null)
            {
                productDTO.Id = product.Id;
                productDTO.Name = product.Name;
                productDTO.Slug = product.Slug;
                productDTO.Description = product.Description;
                productDTO.MetaDescription = product.MetaDescription;
                productDTO.MetaKeywords = product.MetaKeywords;
                productDTO.SKU = product.MetaDescription;
                productDTO.Model = product.MetaKeywords;
                productDTO.Price = product.Price;
                productDTO.SalePrice = product.SalePrice;
                productDTO.OldPrice = product.OldPrice;
                productDTO.ImageUrl = product.ImageUrl;
                productDTO.QuantityInStock = product.QuantityInStock;
                productDTO.IsBestseller = product.IsBestseller;
                productDTO.CategoryId = product.CategoryId;
                productDTO.BrandId = product.BrandId;
                productDTO.ProductStatus = (int)product.ProductStatus;
                productDTO.CreateDate = product.CreateDate;
                productDTO.ModifiedDate = product.ModifiedDate;
                productDTO.IsDeleted = product.IsDeleted;
            };

            return productDTO;
        }

        public List<BrandDTO> MapToBrandDTOs(IEnumerable<Brand> brands)
        {
            List<BrandDTO> brandDTOs = new List<BrandDTO>();

            if(brands != null)
            {
                foreach(Brand brand in brands)
                {
                    brandDTOs.Add(MapToBrandDTO(brand));
                }
            }
            return brandDTOs;   
        }

        public List<CategoryDTO> MapToCategoryDTOs(IEnumerable<Category> categories)
        {
            List<CategoryDTO> categoryDTOs = new List<CategoryDTO>();

            if (categories != null)
            {
                foreach (Category category in categories)
                {
                    categoryDTOs.Add(MapToCategoryDTO(category));
                }
            }
            return categoryDTOs;
        }

        public List<ProductDTO> MapToProductDTOs(IEnumerable<Product> products)
        {
            List<ProductDTO> productDTOs = new List<ProductDTO>();

            if (products != null)
            {
                foreach (Product product in products)
                {
                    productDTOs.Add(MapToProductDTO(product));
                }
            }
            return productDTOs;
        }
    }
}

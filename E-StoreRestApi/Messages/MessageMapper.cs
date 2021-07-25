using E_StoreRestApi.Messages.DataTransferObjects.Address;
using E_StoreRestApi.Messages.DataTransferObjects.Cart;
using E_StoreRestApi.Messages.DataTransferObjects.Product;
using E_StoreRestApi.Models.Address;
using E_StoreRestApi.Models.Cart;
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

        public CartDTO MapToCartDTO(Cart cart)
        {
            var cartDTO = new CartDTO();
            if (cart != null)
            {
                cartDTO.Id = cart.Id;
                cartDTO.UniqueCartId = cart.UniqueCartId;
                cartDTO.CartStatus = (int)cart.CartStatus;
                cartDTO.CreateDate = cart.CreateDate;
                cartDTO.ModifiedDate = cart.ModifiedDate;
                cartDTO.IsDeleted = cart.IsDeleted;
            }
            return cartDTO;
        }

        public Cart MapToCart(CartDTO cartDTO)
        {
            var cart = new Cart();

            if (cartDTO != null)
            {
                cart.Id = cartDTO.Id;
                cart.UniqueCartId = cartDTO.UniqueCartId;
                cart.CartStatus = (CartStatus)cartDTO.CartStatus;
                cart.CreateDate = cartDTO.CreateDate;
                cart.ModifiedDate = cartDTO.ModifiedDate;
                cart.IsDeleted = cartDTO.IsDeleted;
            };

            return cart;
        }

        public CartItemDTO MapToCartItemDTO(CartItem cartItem)
        {
            CartItemDTO cartItemDTO = null;

            if (cartItem.Product != null)
            {
                var productDTO = MapToProductDTO(cartItem.Product);

                cartItemDTO = new CartItemDTO
                {
                    Id = cartItem.Id,
                    CartId = cartItem.CartId,
                    Product = productDTO,
                    Quantity = cartItem.Quantity
                };
            }

            return cartItemDTO;
        }

        public CartItem MapToCartItem(CartItemDTO cartItemDTO)
        {
            return new CartItem
            {
                CartId = cartItemDTO.CartId,
                ProductId = cartItemDTO.Product.Id,
                Quantity = cartItemDTO.Quantity
            };
        }

        public AddressDTO MapToAddressDto(Address address)
        {
            var addressDto = new AddressDTO();

            if (address != null)
            {
                addressDto.Id = address.Id;
                addressDto.Name = address.Name;
                addressDto.AddressLine1 = address.AddressLine1;
                addressDto.AddressLine2 = address.AddressLine2;
                addressDto.City = address.City;
                addressDto.Country = address.Country;
                addressDto.State = address.State;
                addressDto.ZipCode = address.ZipCode;
                addressDto.CreateDate = address.CreateDate;
                addressDto.ModifiedDate = address.ModifiedDate;
                addressDto.IsDeleted = address.IsDeleted;

            };

            return addressDto;
        }

        public Address MapToAddress(AddressDTO addressDto)
        {
            var address = new Address();
            if (addressDto != null)
            {
                address.Id = addressDto.Id;
                address.Name = addressDto.Name;
                address.AddressLine1 = addressDto.AddressLine1;
                address.AddressLine2 = addressDto.AddressLine2;
                address.City = addressDto.City;
                address.Country = addressDto.Country;
                address.State = addressDto.State;
                address.ZipCode = addressDto.ZipCode;
                address.CreateDate = addressDto.CreateDate;
                address.ModifiedDate = addressDto.ModifiedDate;
                address.IsDeleted = addressDto.IsDeleted;
            };
            return address;
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

        public List<CartItemDTO> MapToCartItemDTOs(IEnumerable<CartItem> cartItems)
        {
            var cartItemDTOs = new List<CartItemDTO>();
            foreach (var cartItem in cartItems)
            {
                var cartItemDTO = MapToCartItemDTO(cartItem);
                cartItemDTOs.Add(cartItemDTO);
            }
            return cartItemDTOs;
        }

        public List<AddressDTO> MapToAddressDtos(IEnumerable<Address> addresses)
        {
            var addressDtos = new List<AddressDTO>();
            foreach (var address in addresses)
            {
                var addressDto = MapToAddressDto(address);
                addressDtos.Add(addressDto);
            }
            return addressDtos;
        }
    }
}

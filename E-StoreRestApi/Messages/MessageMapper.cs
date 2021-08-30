using E_StoreRestApi.Messages.DataTransferObjects.Address;
using E_StoreRestApi.Messages.DataTransferObjects.Cart;
using E_StoreRestApi.Messages.DataTransferObjects.Customer;
using E_StoreRestApi.Messages.DataTransferObjects.Order;
using E_StoreRestApi.Messages.DataTransferObjects.Product;
using E_StoreRestApi.Messages.DataTransferObjects.Shared;
using E_StoreRestApi.Models.Address;
using E_StoreRestApi.Models.Cart;
using E_StoreRestApi.Models.Customer;
using E_StoreRestApi.Models.Order;
using E_StoreRestApi.Models.Product;
using E_StoreRestApi.Models.Shared;
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

        public AddressDTO MapToAddressDTO(Address address)
        {
            var addressDTO = new AddressDTO();

            if (address != null)
            {
                addressDTO.Id = address.Id;
                addressDTO.Name = address.Name;
                addressDTO.AddressLine1 = address.AddressLine1;
                addressDTO.AddressLine2 = address.AddressLine2;
                addressDTO.City = address.City;
                addressDTO.Country = address.Country;
                addressDTO.State = address.State;
                addressDTO.ZipCode = address.ZipCode;
                addressDTO.CreateDate = address.CreateDate;
                addressDTO.ModifiedDate = address.ModifiedDate;
                addressDTO.IsDeleted = address.IsDeleted;

            };

            return addressDTO;
        }

        public Address MapToAddress(AddressDTO addressDTO)
        {
            var address = new Address();
            if (addressDTO != null)
            {
                address.Id = addressDTO.Id;
                address.Name = addressDTO.Name;
                address.AddressLine1 = addressDTO.AddressLine1;
                address.AddressLine2 = addressDTO.AddressLine2;
                address.City = addressDTO.City;
                address.Country = addressDTO.Country;
                address.State = addressDTO.State;
                address.ZipCode = addressDTO.ZipCode;
                address.CreateDate = addressDTO.CreateDate;
                address.ModifiedDate = addressDTO.ModifiedDate;
                address.IsDeleted = addressDTO.IsDeleted;
            };
            return address;
        }

        public CustomerDTO MapToCustomerDTO(Customer customer)
        {
            var customerDTO = new CustomerDTO
            {
                Id = customer.Id,
                FirstName = customer.Person.FirstName,
                MiddleName = customer.Person.MiddleName,
                LastName = customer.Person.LastName,
                EmailAddress = customer.Person.EmailAddress,
                PhoneNumber = customer.Person.PhoneNumber,
                Gender = (int)customer.Person.Gender,
                DateOfBirth = customer.Person.DateOfBirth,
                CreateDate = customer.CreateDate,
                ModifiedDate = customer.ModifiedDate,
                IsDeleted = customer.IsDeleted
            };

            return customerDTO;
        }
        public Customer MapToCustomer(CustomerDTO customerDTO)
        {
            var person = new Person
            {
                Id = customerDTO.Id,
                FirstName = customerDTO.FirstName,
                MiddleName = customerDTO.MiddleName,
                LastName = customerDTO.LastName,
                EmailAddress = customerDTO.EmailAddress,
                PhoneNumber = customerDTO.PhoneNumber,
                Gender = (Gender)customerDTO.Gender,
                DateOfBirth = customerDTO.DateOfBirth,
                CreateDate = customerDTO.CreateDate,
                ModifiedDate = customerDTO.ModifiedDate,
                IsDeleted = customerDTO.IsDeleted
            };

            return new Customer
            {
                Id = customerDTO.Id,
                Person = person
            };
        }

        public PersonDTO MapToPersonDTO(Person person)
        {
            var personDTO = new PersonDTO
            {
                Id = person.Id,
                FirstName = person.FirstName,
                MiddleName = person.MiddleName,
                LastName = person.LastName,
                EmailAddress = person.EmailAddress,
                PhoneNumber = person.PhoneNumber,
                Gender = (int)person.Gender,
                DateOfBirth = person.DateOfBirth,
                CreateDate = person.CreateDate,
                ModifiedDate = person.ModifiedDate,
                IsDeleted = person.IsDeleted
            };

            return personDTO;
        }

        public Person MapToPerson(PersonDTO personDTO)
        {
            return new Person
            {
                Id = personDTO.Id,
                FirstName = personDTO.FirstName,
                MiddleName = personDTO.MiddleName,
                LastName = personDTO.LastName,
                EmailAddress = personDTO.EmailAddress,
                PhoneNumber = personDTO.PhoneNumber,
                Gender = (Gender)personDTO.Gender,
                DateOfBirth = personDTO.DateOfBirth,
                CreateDate = personDTO.CreateDate,
                ModifiedDate = personDTO.ModifiedDate,
                IsDeleted = personDTO.IsDeleted
            };
        }

        public OrderDTO MapToOrderDTO(Order order)
        {
            var orderDTO = new OrderDTO
            {
                Id = order.Id,
                OrderTotal = order.OrderTotal,
                OrderItemTotal = order.OrderTotal,
                ShippingCharge = order.ShippingCharge,
                CustomerId = order.CustomerId,
                OrderStatus = (int)order.OrderStatus,
                CreateDate = order.CreateDate,
                ModifiedDate = order.ModifiedDate,
                IsDeleted = order.IsDeleted
            };

            return orderDTO;
        }

        public Order MapToOrder(OrderDTO orderDTO)
        {
            return new Order
            {
                Id = orderDTO.Id,
                OrderTotal = orderDTO.OrderTotal,
                OrderItemTotal = orderDTO.OrderTotal,
                ShippingCharge = orderDTO.ShippingCharge,
                CustomerId = orderDTO.CustomerId,
                OrderStatus = (OrderStatus)orderDTO.OrderStatus,
                CreateDate = orderDTO.CreateDate,
                ModifiedDate = orderDTO.ModifiedDate,
                IsDeleted = orderDTO.IsDeleted
            };
        }

        public OrderItemDTO MapToOrderItemDTO(OrderItem orderItem)
        {
            OrderItemDTO orderItemDTO = null;

            if (orderItem?.Product != null)
            {
                var productDTO = MapToProductDTO(orderItem.Product);

                orderItemDTO = new OrderItemDTO
                {
                    Id = orderItem.Id,
                    OrderId = orderItem.OrderId,
                    Product = productDTO,
                    Quantity = orderItem.Quantity
                };
            }

            return orderItemDTO;
        }

        public OrderItem MapToOrderItem(OrderItemDTO orderItemDTO)
        {
            return new OrderItem
            {
                OrderId = orderItemDTO.OrderId,
                ProductId = orderItemDTO.Product.Id,
                Quantity = orderItemDTO.Quantity
            };
        }

        public List<BrandDTO> MapToBrandDTOs(IEnumerable<Brand> brands)
        {
            var brandDTOs = new List<BrandDTO>();
            foreach (var brand in brands)
            {
                var brandDTO = MapToBrandDTO(brand);
                brandDTOs.Add(brandDTO);
            }
            return brandDTOs;
        }

        public List<CategoryDTO> MapToCategoryDTOs(IEnumerable<Category> categories)
        {
            var categoryDTOs = new List<CategoryDTO>();
            foreach (var category in categories)
            {
                var categoryDTO = MapToCategoryDTO(category);
                categoryDTOs.Add(categoryDTO);
            }
            return categoryDTOs;
        }

        public List<ProductDTO> MapToProductDTOs(IEnumerable<Product> products)
        {
            var productDTOs = new List<ProductDTO>();
            foreach (var product in products)
            {
                var productDTO = MapToProductDTO(product);
                productDTOs.Add(productDTO);
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
        public List<AddressDTO> MapToAddressDTOs(IEnumerable<Address> addresses)
        {
            var addressDTOs = new List<AddressDTO>();
            foreach (var address in addresses)
            {
                var addressDTO = MapToAddressDTO(address);
                addressDTOs.Add(addressDTO);
            }
            return addressDTOs;
        }
    }
}
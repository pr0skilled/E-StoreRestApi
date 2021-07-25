using System;
using System.Collections.Generic;
using System.Linq;
using E_StoreRestApi.Messages;
using E_StoreRestApi.Messages.Request.Cart;
using E_StoreRestApi.Messages.Response.Cart;
using E_StoreRestApi.Models.Cart;
using E_StoreRestApi.Models.Product;
using E_StoreRestApi.Repositories.Interfaces;
using E_StoreRestApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;

namespace E_StoreRestApi.Services.Implementations
{
    public class CartService : ICartService
    {
        private const string UniqueCartIdSessionKey = "UniqueCartId";
        private readonly ICartRepository cartRepository;
        private readonly ICartItemRepository cartItemRepository;
        private MessageMapper messageMapper;
        private readonly HttpContext httpContext;
        private readonly IProductRepository productRepository;
        public CartService( 
            IHttpContextAccessor httpContextAccessor_,
            ICartRepository cartRepository_,
            ICartItemRepository cartItemRepository_,
            IProductRepository productRepository_)
        {
            cartRepository = cartRepository_;
            cartItemRepository = cartItemRepository_;
            messageMapper = new MessageMapper();
            httpContext = httpContextAccessor_.HttpContext;
            productRepository = productRepository_;
        }

        public AddItemToCartResponse AddItemToCart(AddItemToCartRequest request)
        {
            var cart = GetCart();
            var response = new AddItemToCartResponse();
            Product product = productRepository.GetProductById(request.ProductId);
            try
            {
                if (product == null) throw new Exception("Product is null");
                if (cart != null)
                {
                    CartItem existingCartItem = cartItemRepository.FindCartItemsByCartId(cart.Id)
                                        .FirstOrDefault(c => c.ProductId == request.ProductId);
                    if (existingCartItem != null)
                    {
                        existingCartItem.Quantity++;
                        existingCartItem.ModifiedDate = DateTimeOffset.Now;
                        cartItemRepository.UpdateCartItem(existingCartItem);
                        response.CartItem = messageMapper.MapToCartItemDTO(existingCartItem);
                    }
                    else
                    {
                        CartItem cartItem = new CartItem
                        {
                            CartId = cart.Id,
                            ProductId = product.Id,
                            Product = product,
                            Quantity = 1,
                            CreateDate = DateTimeOffset.Now
                        };
                        cartItemRepository.SaveCartItem(cartItem);
                        response.CartItem = messageMapper.MapToCartItemDTO(cartItem);
                    }
                }
                else
                {
                    Cart newCart = new Cart
                    {
                        UniqueCartId = UniqueCartId(),
                        CartStatus = CartStatus.Open,
                        CreateDate = DateTimeOffset.Now
                    };

                    cartRepository.SaveCart(newCart);

                    CartItem newCartItem = new CartItem
                    {
                        CartId = newCart.Id,
                        ProductId = request.ProductId,
                        Product = product,
                        Quantity = 1,
                        CreateDate = DateTimeOffset.Now
                    };

                    cartItemRepository.SaveCartItem(newCartItem);
                    response.CartItem = messageMapper.MapToCartItemDTO(newCartItem);
                }
            }
            catch (Exception ex)
            {
                response.StatusCode = System.Net.HttpStatusCode.NotFound;
                response.Messages.Add(ex.ToString());
                return response;
            }
            response.StatusCode = System.Net.HttpStatusCode.OK;
            return response;
        }

        public int CartItemsCount()
        {
            var cartItems = GetCartItems();
            int count = 0;
            foreach (var item in cartItems)
                count += item.Quantity;
            return count;
        }

        public FetchCartResponse FetchCart()
        {
            FetchCartResponse response = new FetchCartResponse();
            Cart cart = GetCart();
            try
            {
                if (cart == null)
                    throw new Exception("Cart is null");
                var cartItems = cartItemRepository.FindCartItemsByCartId(cart.Id);
                var cartItemsDto = messageMapper.MapToCartItemDTOs(cartItems);
                var cartDto = messageMapper.MapToCartDTO(cart);
                cartDto.CartItems = cartItemsDto;
                response.Cart = cartDto;
                response.StatusCode = System.Net.HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                response.StatusCode = System.Net.HttpStatusCode.NotFound;
                response.Messages.Add(ex.ToString());
            }
            return response;
        }

        public Cart GetCart()
        {
            var uniqueId = UniqueCartId();
            var cart = cartRepository.GetAllCarts().FirstOrDefault(c => c.UniqueCartId == uniqueId);
            return cart;
        }

        public IEnumerable<CartItem> GetCartItems()
        {
            IList<CartItem> cartItems = new List<CartItem>();
            var cart = GetCart();
            if (cart != null)
            {
                cartItems = cartItemRepository.FindCartItemsByCartId(cart.Id).ToList();
            }
            return cartItems;
        }

        public decimal GetCartTotal()
        {
            var cartItems = GetCartItems();
            decimal total = 0;
            foreach (var item in cartItems)
                total += item.Product.Price * item.Quantity;
            return total;
        }

        public RemoveItemFromCartResponse RemoveItemFromCart(RemoveItemFromCartRequest request)
        {
            var response = new RemoveItemFromCartResponse();
            try
            {
                CartItem cartItem = cartItemRepository.FindCartItemById(request.CartItemId);
                cartItemRepository.DeleteCartItem(cartItem);
                response.StatusCode = System.Net.HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                response.StatusCode = System.Net.HttpStatusCode.NotFound;
                response.Messages.Add(ex.ToString());
            }
            return response;
        }

        public string UniqueCartId()
        {
            if (!string.IsNullOrWhiteSpace(httpContext.Session.GetString(UniqueCartIdSessionKey)))
            {
                return httpContext.Session.GetString(UniqueCartIdSessionKey);
            }
            else
            {
                var uniqueId = Guid.NewGuid().ToString();
                httpContext.Session.SetString(UniqueCartIdSessionKey, uniqueId);

                return httpContext.Session.GetString(UniqueCartIdSessionKey);
            }
        }
    }
}

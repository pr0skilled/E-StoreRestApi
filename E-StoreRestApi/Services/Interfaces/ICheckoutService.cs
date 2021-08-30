using E_StoreRestApi.Messages.Request.Checkout;
using E_StoreRestApi.Messages.Response.Checkout;

namespace E_StoreRestApi.Services
{
    public interface ICheckoutService
    {
        CheckoutResponse ProcessCheckout(CheckoutRequest checkoutRequest);
    }
}

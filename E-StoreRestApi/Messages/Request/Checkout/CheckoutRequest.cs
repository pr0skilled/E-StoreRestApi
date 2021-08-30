namespace E_StoreRestApi.Messages.Request.Checkout
{
    using DataTransferObjects.Address;
    using DataTransferObjects.Cart;
    using DataTransferObjects.Customer;
    public class CheckoutRequest
    {
        public CustomerDTO Customer { get; set; }

        public AddressDTO Address { get; set; }

        public CartDTO Cart { get; set; }
    }
}

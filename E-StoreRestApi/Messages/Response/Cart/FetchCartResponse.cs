using E_StoreRestApi.Messages.DataTransferObjects.Cart;

namespace E_StoreRestApi.Messages.Response.Cart
{
    public class FetchCartResponse : ResponseBase
    {
        public CartDTO Cart { get; set; }
    }
}

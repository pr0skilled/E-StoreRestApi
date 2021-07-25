namespace E_StoreRestApi.Messages.DataTransferObjects.Cart
{
    public class CartItemDTO
    {
        public long Id { get; set; }
        public long CartId { get; set; }
        public Product.ProductDTO Product { get; set; }
        public int Quantity { get; set; }
    }
}

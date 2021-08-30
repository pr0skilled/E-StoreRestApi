using E_StoreRestApi.Messages.DataTransferObjects.Product;

namespace E_StoreRestApi.Messages.DataTransferObjects.Order
{
    public class OrderItemDTO
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public long ProductId { get; set; }
        public ProductDTO Product { get; set; }
        public int Quantity { get; set; }
    }
}

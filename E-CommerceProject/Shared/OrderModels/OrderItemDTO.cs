namespace Shared.OrderModels
{
    public record OrderItemDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string PictureUrl { get; set; }
        public int Quantity { get; set; }
        public Decimal Price { get; set; }

    }
}

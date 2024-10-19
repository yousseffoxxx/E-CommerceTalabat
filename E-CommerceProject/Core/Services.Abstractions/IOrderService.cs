namespace Services.Abstractions
{
    public interface IOrderService
    {
        // Get Order By id => OrderResult(Guid id)
        public Task<OrderResult> GetOrderByIdAsync(Guid id);

        // Get Orders for user By Email => IEnumerable<OrderResult>(string email)
        public Task<IEnumerable<OrderResult>> GetOrderByEmailAsync(string email);

        // Create Order => OrderResult(OrderRequest, string email)
        public Task<OrderResult> CreateOrderAsync(OrderRequest request, string userEmail);
        // Get All delivery Methods
        public Task<IEnumerable<DeliveryMethodResult>> GetDeliveryMethodsAsync();
    }
}

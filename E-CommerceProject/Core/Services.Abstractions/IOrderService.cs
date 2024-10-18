using Shared.OrderModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IOrderService
    {
        // Get Order By id => OrderResult(Guid id)
        public Task<OrderResult> GetOrderById(Guid id);

        // Get Orders for user By Email => IEnumerable<OrderResult>(string email)
        public Task<IEnumerable<OrderResult>> GetOrderByEmail(string email);

        // Create Order => OrderResult(OrderRequest, string email)
        public Task<OrderResult> CreateOrderAsync(OrderRequest request, string userEmail);
        // Get All delivery Methods
        public Task<IEnumerable<DeliveryMethodResult>> GetDeliveryMethodsAsync();
    }
}

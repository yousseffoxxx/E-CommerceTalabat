using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.OrderModels
{
    public record OrderResult
    {
        // Id
        public Guid Id { get; set; }
        // user Email
        public string UserEmail { get; set; }
        // Address
        public AddressDTO ShippingAddress { get; set; }
        // order Items
        public ICollection<OrderItemDTO> OrderItems { get; set; } = new List<OrderItemDTO>();
        // Payment Status
        public string PaymentStatus { get; set; }
        // Delivery Method
        public string DeliveryMethod { get; set; }
        //subTotal => Items.Q * Price
        public decimal SubTotal { get; set; }
        // Payment
        public string PaymentIntentId { get; set; } = string.Empty;
        //OrderDate
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
        public decimal Total { get; set; }
    }
}

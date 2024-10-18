using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.OrderEntities
{
    public class Order : BaseEntity<Guid>
    {
        // user Email
        public string UserEmail { get; set; }
        // Address
        public OrderAddress ShippingAddress { get; set; }
        // order Items
        public ICollection<OrderItem> OrderItems { get; set; } // Collection Navigational Prop
        // Payment Status
        public OrderPaymentStatus PaymentStatus { get; set; }
        // Delivery Method
        public DeliveryMethod  DeliveryMethod { get; set; } // ref Navigational Prop
        public int? DeliveryMethodId { get; set; }
        //subTotal => Items.Q * Price
        public decimal SubTotal { get; set; }
        // Payment
        public string PaymentIntentId { get; set; } = string.Empty;
        //OrderDate
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
    }
}

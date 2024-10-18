using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.OrderEntities
{
    public class Order : BaseEntity<Guid>
    {
        public Order()
        {
            
        }
        public Order(string userEmail,
            OrderAddress shippingAddress,
            ICollection<OrderItem> orderItems,
            DeliveryMethod deliveryMethod,
            decimal subTotal)
        {
            id = Guid.NewGuid();
            UserEmail = userEmail;
            ShippingAddress = shippingAddress;
            OrderItems = orderItems;
            DeliveryMethod = deliveryMethod;
            SubTotal = subTotal;
        }

        // user Email
        public string UserEmail { get; set; }
        // Address
        public OrderAddress ShippingAddress { get; set; }
        // order Items
        public ICollection<OrderItem> OrderItems { get; set; } // Collection Navigational Prop
        // Payment Status
        public OrderPaymentStatus PaymentStatus { get; set; } = OrderPaymentStatus.Pending;
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

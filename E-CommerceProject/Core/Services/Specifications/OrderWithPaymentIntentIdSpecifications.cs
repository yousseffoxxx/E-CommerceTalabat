using System.Linq.Expressions;

namespace Services.Specifications
{
    internal class OrderWithPaymentIntentIdSpecifications : Specifications<Order>
    {
        public OrderWithPaymentIntentIdSpecifications(string PaymentIntentId)
            : base(order => order.PaymentIntentId == PaymentIntentId)
        {
        }
    }
}

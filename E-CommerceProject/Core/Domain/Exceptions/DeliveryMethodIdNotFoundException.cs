namespace Domain.Exceptions
{
    public class DeliveryMethodIdNotFoundException : NotFoundException
    {
        public DeliveryMethodIdNotFoundException(int id)
           : base($"No Delivery Method with ID {id} was found")
        {
        }
        public DeliveryMethodIdNotFoundException() : base("No Delivery Method was Selected")
        {
        }
    }
}

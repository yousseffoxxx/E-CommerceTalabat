namespace Domain.Exceptions
{
    public class DeliveryMethodIdNotFoundException(int id) : NotFoundException($"No Delivery Method with{id} was found")
    {
    }
}

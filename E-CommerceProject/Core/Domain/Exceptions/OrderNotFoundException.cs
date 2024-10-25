namespace Domain.Exceptions
{
    public class OrderNotFoundException(Guid id) : NotFoundException($"No Order with{id} was found")
    {
    }
}

namespace Domain.Exceptions
{
    public sealed class ProductNotFoundException : NotFoundException
    {
        public ProductNotFoundException(int id) : base($"Product With ID : {id} not found")
        {
        }
    }
}

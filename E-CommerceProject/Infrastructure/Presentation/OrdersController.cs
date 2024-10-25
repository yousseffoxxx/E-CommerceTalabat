namespace Presentation
{
    [Authorize]
    public class OrdersController(IServiceManager serviceManager) : ApiController
    {
        [HttpPost] // Post : api/Orders
        public async Task<ActionResult<OrderResult>> Create(OrderRequest request)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);

            var order = await serviceManager.OrderService.CreateOrUpdateOrderAsync(request, email);

            return Ok(order);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderResult>>> GetOrders()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);

            var order = await serviceManager.OrderService.GetOrderByEmailAsync(email);
            
            return Ok(order);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderResult>> GetOrder(Guid id)
        {
            var order = await serviceManager.OrderService.GetOrderByIdAsync(id);
            
            return Ok(order);
        }
        [AllowAnonymous]
        [HttpGet("DeliveryMethods")]
        public async Task<ActionResult<DeliveryMethodResult>> GetDeliveryMethods()
        {
            var methods = await serviceManager.OrderService.GetDeliveryMethodsAsync();
            
            return Ok(methods);
        }
    }
}
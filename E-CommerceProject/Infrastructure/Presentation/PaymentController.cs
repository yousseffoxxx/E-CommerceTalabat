namespace Presentation
{
    public class PaymentController (IServiceManager serviceManager)
        : ApiController
    {
        [HttpPost("{basketId}")]
        public async Task<ActionResult<BasketDTO>> CreateOrUpdatePaymentIntent(string basketId)
        {
            var result = await serviceManager.PaymentService.CreateOrUpdatePaymentIntentAsync(basketId);

            return Ok(result);
        }

    }
}

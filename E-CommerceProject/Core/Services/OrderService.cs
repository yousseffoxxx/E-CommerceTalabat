using Services.Specifications;

namespace Services
{
    internal class OrderService(IUnitOfWork unitOfWork,
        IMapper mapper ,
        IBasketRepository basketRepository): IOrderService
    {
        public async Task<OrderResult> CreateOrUpdateOrderAsync(OrderRequest request, string userEmail)
        {
            // 1. Address
            var address = mapper.Map<OrderAddress>(request.ShipToAddress);
            
            // 2. OrderItems => Basket => BasketItems => OrderItems
            var basket = await basketRepository.GetBasketAsync(request.BasketId)
                ?? throw new BasketNotFoundException(request.BasketId);

            var orderItems = new List<OrderItem>();

            foreach (var item in basket.Items)
            {
                var product = await unitOfWork.GetRepository<Product,int>()
                    .GetAsync(item.Id) ?? throw new ProductNotFoundException(item.Id);
                
                orderItems.Add(CreateOrderItem(item, product));
            }

            var orderRepo = unitOfWork.GetRepository<Order, Guid>();

            var existingOrder = await orderRepo.GetAsync(new OrderWithPaymentIntentIdSpecifications(basket.PaymentIntentId));

            if (existingOrder is not null)
                orderRepo.Delete(existingOrder);

            // 3. Delivery
            var deliveryMethod = await unitOfWork.GetRepository<DeliveryMethod, int>()
                .GetAsync(request.DeliveryMethodId) ?? throw new DeliveryMethodIdNotFoundException(request.DeliveryMethodId);
            
            // 4. SubTotal
            var subTotal = orderItems.Sum(item => item.Price * item.Quantity);

            // 5. Save To Db
            var order = new Order(userEmail, address, orderItems, deliveryMethod , subTotal, basket.PaymentIntentId);
            
            await orderRepo.AddAsync(order);

            await unitOfWork.SaveChangesAsync();

            // 6. Map & Return

            return mapper.Map<OrderResult>(order);
        }

        private OrderItem CreateOrderItem(BasketItem item, Product product)
            => new OrderItem(new ProductInOrderItem(product.Id, product.Name, product.PictureUrl),
                item.Quantity, product.Price);

        public async Task<IEnumerable<DeliveryMethodResult>> GetDeliveryMethodsAsync()
        {
            var methods = await unitOfWork.GetRepository<DeliveryMethod, int>()
                .GetAllAsync();
            return mapper.Map<IEnumerable<DeliveryMethodResult>>(methods);
        }
        
        public async Task<OrderResult> GetOrderByIdAsync(Guid id)
        {
            var order = await unitOfWork.GetRepository<Order, Guid>()
                .GetAsync(new OrderWithIncludeSpecifications(id))
                ?? throw new OrderNotFoundException(id);

            return mapper.Map<OrderResult>(order);

        }

        public async Task<IEnumerable<OrderResult>> GetOrderByEmailAsync(string email)
        {
            var orders = await unitOfWork.GetRepository<Order, Guid>()
                .GetAllAsync(new OrderWithIncludeSpecifications(email));
               
            return mapper.Map<IEnumerable<OrderResult>>(orders);

        }

    }
}

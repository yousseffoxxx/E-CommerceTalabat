using AutoMapper;
using Domain.Contracts;
using Domain.Entities.BasketEntities;
using Domain.Entities.OrderEntities;
using Domain.Entities.ProductEntities;
using Domain.Exceptions;
using Services.Abstractions;
using Shared.OrderModels;

namespace Services
{
    internal class OrderService(IUnitOfWork unitOfWork,
        IMapper mapper ,
        IBasketRepository basketRepository): IOrderService
    {
        public async Task<OrderResult> CreateOrderAsync(OrderRequest request, string userEmail)
        {
            // 1. Address
            var address = mapper.Map<OrderAddress>(request.ShippingAddress);
            
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

            // 3. Delivery
            var deliveryMethod = await unitOfWork.GetRepository<DeliveryMethod, int>()
                .GetAsync(request.DeliveryMethodId) ?? throw new DeliveryMethodIdNotFoundException(request.DeliveryMethodId);
            
            // 4. SubTotal
            var subTotal = orderItems.Sum(item => item.Price * item.Quantity);

            // 5. Save To Db
            var order = new Order(userEmail, address, orderItems, deliveryMethod , subTotal);
            
            await unitOfWork.GetRepository<Order , Guid>()
                .AddAsync(order);

            await unitOfWork.SaveChangesAsync();

            // 6. Map & Return

            return mapper.Map<OrderResult>(order);
        }

        private OrderItem CreateOrderItem(BasketItem item, Product product)
            => new OrderItem(new ProductInOrderItem(product.Id, product.Name, product.PictureUrl),
                item.Quantity, product.Price);

        public Task<IEnumerable<DeliveryMethodResult>> GetDeliveryMethodsAsync()
        {

        }

        public Task<IEnumerable<OrderResult>> GetOrderByEmail(string email)
        {

        }

        public Task<OrderResult> GetOrderById(Guid id)
        {


        }
    }
}

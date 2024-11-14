using Shared.BasketModels;

namespace Services.Abstractions
{
    public interface IBasketService
    {
        Task<BasketDTO?> GetBasketAsync(string id);
        Task<BasketDTO?> UpdateBasketAsync(BasketDTO basket);
        Task<bool> DeleteBasketAsync(string id);
    }
}

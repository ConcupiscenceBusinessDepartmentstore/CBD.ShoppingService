using CBD.ShoppingService.Core.Models;

namespace CBD.ShoppingService.Core.Repositories;

public interface IBasketRepository
{
    Task CreateBasketAsync(string Name, string Description, string Price, string Quantity);
    Task<List<Product>> GetBasketsAsync();
    Task<Product> GetBasketAsync(string Id);
    Task UpdateBasketAsync(string Id, string ProductId, string Quantity);
    Task EmptyBasketAsync(string Id);
}
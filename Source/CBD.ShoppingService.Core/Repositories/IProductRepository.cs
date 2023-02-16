using CBD.ShoppingService.Core.Models;
using CBD.ShoppingService.Core.Models;

namespace CBD.ShoppingService.Core.Repositories;

public interface IProductRepository
{
    Task CreateProductAsync(string Name, string Description, string Price, string Quantity);
    Task<List<Product>> GetProductsAsync();
    Task<Product> GetProductAsync(string Id);
    Task UpdateProductNameAsync(string Id, string Name);
    Task UpdateProductPriceAsync(string Id, string Price);
    Task UpdateProductQuantityAsync(string Id, string Quantity);
    Task DeleteProductAsync(string Id);
}
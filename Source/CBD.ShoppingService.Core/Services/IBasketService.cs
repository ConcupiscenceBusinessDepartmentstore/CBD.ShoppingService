using CBD.ShoppingService.Core.Contracts.Requests;
using CBD.ShoppingService.Core.Contracts.Responses;

namespace CBD.ShoppingService.Core.Services;

public interface IBasketService {
	Task<CreateProductResponse> CreateBasketAsync(CreateProductRequest request);
	Task<DeleteProductResponse> DeleteProductAsync(DeleteProductRequest request);
	Task<EditProductResponse> EditBasketAsync(EditProductRequest request);
	Task<GetProductResponse> GetBasketAsync(GetProductRequest request);
}
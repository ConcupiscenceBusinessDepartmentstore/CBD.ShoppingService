using CBD.ShoppingService.Core.Contracts.Requests;
using CBD.ShoppingService.Core.Contracts.Responses;

namespace CBD.ShoppingService.Core.Services;

public interface IProductService {
	Task<CreateProductResponse> CreateProductAsync(CreateProductRequest request);
	Task<DeleteProductResponse> DeleteProductAsync(DeleteProductRequest request);
	Task<EditProductResponse> EditProductAsync(EditProductRequest request);
	Task<GetProductResponse> GetProductAsync(GetProductRequest request);
}
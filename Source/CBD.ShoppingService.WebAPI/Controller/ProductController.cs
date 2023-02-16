using CBD.ShoppingService.Core.Repositories;
using Microsoft.AspNetCore.Mvc;
using CBD.ShoppingService.Core.Contracts.Requests;
using CBD.ShoppingService.Core.Contracts.Responses;
using CBD.ShoppingService.Core.Exceptions;
using CBD.ShoppingService.Core.Filters;
using CBD.ShoppingService.Core.Services;
using ShoppingService.WebAPI.Extensions;

namespace CBD.ShoppingService.WebAPI.Controllers;

[ApiController]
[Route("products")]
public class ProductController : ControllerBase {
	private readonly ILogger<ProductController> logController;
	private readonly IProductService serviceProduct;

	public ProductController(IProductRepository serviceProduct, ILogger<ProductController> logController) {
		serviceProduct = serviceProduct;
		logController = logController;
	}
	
	[HttpPost]
	[UserAuthorized]
	[ProducesResponseType(typeof(CreateProductResponse), 200)]
	[ProducesResponseType(401)]
	public async Task<IActionResult> CreateProduct(CreateProductRequest request) {
		try {
			var createPlantResponse = await serviceProduct.CreateProductAsync(request);
			return Ok(createPlantResponse);
		}
		catch (UnauthorizedException) {
			return Unauthorized();
		}
		catch (Exception e) {
			logController.LogError(e, $"{nameof(CreateProduct)} threw an exception");
			return this.ErrorResponse<CreateProductResponse>(e);
		}
	}

	[HttpDelete]
	[ProducesResponseType(typeof(DeleteProductResponse), 200)]
	public async Task<IActionResult> DeleteProduct(DeleteProductRequest request) {
		try {
			var deleteProductResponse = await serviceProduct.DeleteProductAsync(request);
			return Ok(deleteProductResponse);
		}
		catch (UnauthorizedException) {
			return Unauthorized();
		}
		catch (Exception e) {
			logController.LogError(e, $"{nameof(DeleteProduct)} threw an exception");
			return this.ErrorResponse<DeleteProductResponse>(e);
		}
	}

	[HttpGet]
	[Route("product")]
	[ProducesResponseType(typeof(GetProductResponse), 200)]
	public async Task<IActionResult> GetProduct(GetProductRequest request) {
		try {
			var getProductResponse = await serviceProduct.GetProductAsync(request);
			return Ok(getProductResponse);
		}
		catch (Exception e) {
			logController.LogError(e, $"{nameof(GetProductResponse)} threw an exception");
			return this.ErrorResponse<GetProductResponse>(e);
		}
	}

	[HttpPut]
	[UserAuthorized]
	[ProducesResponseType(typeof(EditProductResponse), 200)]
	[ProducesResponseType(401)]
	public async Task<IActionResult> EditProduct(EditProductRequest request) {
		try {
			var editProductResponse = await serviceProduct.EditProductAsync(request);
			return Ok(editProductResponse);
		}
		catch (Exception e) {
			logController.LogError(e, $"{nameof(EditProduct)} threw an exception");
			return this.ErrorResponse<EditProductResponse>(e);
		}
	}
}
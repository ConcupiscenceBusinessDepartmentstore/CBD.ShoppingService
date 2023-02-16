using System.ComponentModel;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using CBD.ShoppingService.Core.Contracts.Requests;
using CBD.ShoppingService.Core.Contracts.Responses;
using CBD.ShoppingService.Core.Enums;
using CBD.ShoppingService.Core.Exceptions;
using CBD.ShoppingService.Core.Models;
using CBD.ShoppingService.Core.Options;
using CBD.ShoppingService.Core.Services;
using CBD.ShoppingService.Port.Contexts;

namespace CBD.ShoppingService.Port.Services;

public class ProductService : IProductService {
	private readonly ShoppingContext ctxShopping;
	private readonly GatewayOptions optionsGateway;
	private readonly IHttpContextAccessor accessorHttpContext;
	private readonly IIdentityService serviceIdentity;
	private readonly IdentityServiceOptions optionsIdentityService;

	public ProductService(ShoppingContext ctxShopping, IIdentityService serviceIdentity, IOptions<IdentityServiceOptions> identityServiceOptions, IOptions<GatewayOptions> gatewayOptions,
		IHttpContextAccessor accessorHttpContext) {
		this.ctxShopping = ctxShopping;
		this.serviceIdentity = serviceIdentity;
		this.optionsIdentityService = identityServiceOptions.Value;
		this.optionsGateway = gatewayOptions.Value;
		this.accessorHttpContext = accessorHttpContext;
	}
	
	public async Task<CreateProductResponse> CreateProductAsync(CreateProductRequest request)
	{
		try {
			if ((!await serviceIdentity.CheckIfUserHasGlobalRole(
				    accessorHttpContext.HttpContext.Request.Headers[HeaderNames.Authorization], 
				    Roles.Administrator.ToString()
			    ))
			    || (!await serviceIdentity.CheckIfUserHasGlobalRole(
				    accessorHttpContext.HttpContext.Request.Headers[HeaderNames.Authorization], 
				    Roles.Trader.ToString()
			    ))
			   )
			{
				throw new UnauthorizedException();
			}

			var product = new Product(request.Name, request.Description, request.Price, request.Quantity);
			
			ctxShopping.Products.Add(product);
			await ctxShopping.SaveChangesAsync();

			return new CreateProductResponse() {
				Succeeded = true,
				ProductId = product.Id,
				Messages = new[]
				{
					CreateProductResponse.Message.ProductCreationSuccessfully
				}
			};
		}
		catch (Exception e) {
			if (e is DbUpdateException or DbUpdateConcurrencyException or OperationCanceledException)
				return new CreateProductResponse() {
					Succeeded = false,
					Errors = new[]
					{
						CreateProductResponse.Error.ProductCreationError
					}
				};

			throw;
		}
	}

	public async Task<DeleteProductResponse> DeleteProductAsync(DeleteProductRequest request)
	{
		try {
			if ((!await serviceIdentity.CheckIfUserHasGlobalRole(
				    accessorHttpContext.HttpContext.Request.Headers[HeaderNames.Authorization], 
				    Roles.Administrator.ToString()
			    ))
			    || (!await serviceIdentity.CheckIfUserHasGlobalRole(
				    accessorHttpContext.HttpContext.Request.Headers[HeaderNames.Authorization], 
				    Roles.Trader.ToString()
			    ))
			   )
			{
				throw new UnauthorizedException();
			}
			
			ctxShopping.Products.Remove(new Product() {Id = request.Id});
			await ctxShopping.SaveChangesAsync();

			return new DeleteProductResponse() {
				Succeeded = true,
				ProductId = request.Id,
				Messages = new[]
				{
					DeleteProductResponse.Message.ProductDeletionSuccessfully
				}
			};
		}
		catch (Exception e) {
			if (e is DbUpdateException or DbUpdateConcurrencyException or OperationCanceledException)
				return new DeleteProductResponse() {
					Succeeded = false,
					Errors = new[]
					{
						DeleteProductResponse.Error.ProductDeletionError
					}
				};

			throw;
		}
	}

	public async Task<EditProductResponse> EditProductAsync(EditProductRequest request)
	{
		try {
			if ((!await serviceIdentity.CheckIfUserHasGlobalRole(
				    accessorHttpContext.HttpContext.Request.Headers[HeaderNames.Authorization], 
				    Roles.Administrator.ToString()
			    ))
			    || (!await serviceIdentity.CheckIfUserHasGlobalRole(
				    accessorHttpContext.HttpContext.Request.Headers[HeaderNames.Authorization], 
				    Roles.Trader.ToString()
			    ))
			   )
			{
				throw new UnauthorizedException();
			}
			
			Product product = ctxShopping.Products.FirstOrDefault(p => p.Id == request.Id);
			
			

			if (product is null)
			{
				return new EditProductResponse() {
					Succeeded = false,
					Errors = new[]
					{
						GetProductResponse.Error.ProductNotFound
					}
				};
			}
			
			if (request.Name is not null)
			{
				product.Name = request.Name;
			}
			if (request.Description is not null)
			{
				product.Description = request.Description;
			}
			if (request.Quantity is not null)
			{
				product.Quantity = double.Parse(request.Quantity);
			}
			if (request.Price is not null)
			{
				product.Price = double.Parse(request.Price);
			}

			this.ctxShopping.Products.Update(product);
			await ctxShopping.SaveChangesAsync();

			return new EditProductResponse() {
				Succeeded = true,
				ProductId = product.Id,
				Messages = new[]
				{
					EditProductResponse.Message.ProductModificationSuccessfully
				}
			};
		}
		catch (Exception e) {
			if (e is DbUpdateException or DbUpdateConcurrencyException or OperationCanceledException)
				return new EditProductResponse() {
					Succeeded = false,
					Errors = new[]
					{
						EditProductResponse.Error.ProductModificationError
					}
				};

			throw;
		}
	}

	public async Task<GetProductResponse> GetProductAsync(GetProductRequest request)
	{
		try {
			var products = await ctxShopping.Products.ToListAsync();
			Product product = null;
			foreach (var tmpProduct in products)
			{
				if (request.Id is not null)
				{
					if (tmpProduct.Id == request.Id)
					{
						product = tmpProduct;
						break;
					}
				}
				if (request.Name is not null)
				{
					if (tmpProduct.Name == request.Name)
					{
						product = tmpProduct;
						break;
					}
				}
				if (request.Description is not null)
				{
					if (tmpProduct.Description == request.Description)
					{
						product = tmpProduct;
						break;
					}
				}
				if (request.DateTimePosted is not null)
				{
					if (tmpProduct.DateTimePosted == DateTime.Parse(request.DateTimePosted))
					{
						product = tmpProduct;
						break;
					}
				}
				if (request.Price is not null)
				{
					if (tmpProduct.Price == double.Parse(request.Price))
					{
						product = tmpProduct;
						break;
					}
				}
				if (request.Quantity is not null)
				{
					if (tmpProduct.Quantity == double.Parse(request.Quantity))
					{
						product = tmpProduct;
						break;
					}
				}
			}

			if (product is null)
			{
				return new GetProductResponse() {
					Succeeded = false,
					Errors = new[]
					{
						GetProductResponse.Error.ProductNotFound
					}
				};
			}
			
			return new GetProductResponse() {
				Succeeded = true,
				Id = product!.Id,
				Name = product.Name,
				Description = product.Description,
				Price = product.Price.ToString(),
				Quantity = product.Quantity.ToString(),
				DateTimePosted = product.DateTimePosted.ToString(),
				Messages = new[] {GetProductResponse.Message.ProductReturnSuccessfully}
			};
		}
		catch (Exception e) {
			if (e is DbUpdateException or DbUpdateConcurrencyException or OperationCanceledException)
				return new GetProductResponse() {
					Succeeded = false,
					Errors = new[]
					{
						GetProductResponse.Error.ProductReturnError
					}
				};

			throw;
		}
	}
}
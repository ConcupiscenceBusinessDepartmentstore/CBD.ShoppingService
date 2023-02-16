namespace CBD.ShoppingService.Core.Contracts.Requests;

public record CreateBasketRequest {
	public string UserId { get; set; }
	
}
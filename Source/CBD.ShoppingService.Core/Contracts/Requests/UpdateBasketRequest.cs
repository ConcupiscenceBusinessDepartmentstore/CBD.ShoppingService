namespace CBD.ShoppingService.Core.Contracts.Requests;

public record UpdateBasketRequest {
	public string UserId { get; set; }
	public string ProductId { get; set; }
	public string Quantity { get; set; }
	
}
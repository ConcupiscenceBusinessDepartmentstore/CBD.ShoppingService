namespace CBD.ShoppingService.Core.Contracts.Requests;

public record GetBasketRequest {
	public string Id { get; set; }
	public string UserId { get; set; }
	public string[] ProductIds { get; set; }
	public string[] Quantities { get; set; }
	public string[] Prices { get; set; }
	public string Total { get; set; }
	
}
using System.ComponentModel.DataAnnotations;

namespace CBD.ShoppingService.Core.Contracts.Requests;

public record GetProductRequest {
	[Required] public string Id { get; set; }
	[Required] public string Name { get; set; }
	[Required] public string Description { get; set; }
	[Required] public string Quantity { get; set; }
	[Required] public string Price { get; set; }
	[Required] public string DateTimePosted { get; set; }
}
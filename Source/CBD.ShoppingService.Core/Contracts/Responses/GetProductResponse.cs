namespace CBD.ShoppingService.Core.Contracts.Responses;

public class GetProductResponse : BaseResponse {
	public string Id { get; set; }
	public string Name { get; set; }
	public string Description { get; set; }
	public string Price { get; set; }
	public string Quantity { get; set; }
	public string DateTimePosted { get; set; }
	public static class Message {
		public static readonly ValueObjects.Message
			ProductReturnSuccessfully = new() {
				Code = nameof(ProductReturnSuccessfully),
				Description = "Das Produkt wurde erfolgreich zurückgegeben."
			};
	}

	public static class Error {
		public static readonly ValueObjects.Message
			ProductReturnError = new() {
				Code = nameof(ProductReturnError),
				Description = "Die Übertragung des Produkts war nicht erfolgreich."
			},
			ProductNotFound = new() {
				Code = nameof(ProductNotFound),
				Description = "Das Produkt wurde nicht gefunden."
			};
	}
}
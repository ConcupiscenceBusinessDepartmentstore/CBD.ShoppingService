namespace CBD.ShoppingService.Core.Contracts.Responses;

public class GetBasketResponse : BaseResponse {
	public string Id { get; set; }
	public string UserId { get; set; }
	public string[] ProductIds { get; set; }
	public string[] Quantities { get; set; }
	public string[] Prices { get; set; }
	public string Total { get; set; }
	public static class Message {
		public static readonly ValueObjects.Message
			ProductAddedSuccessfully = new() {
				Code = nameof(ProductAddedSuccessfully),
				Description = "Das Produkt wurde erfolgreich hinzugefügt."
			},
			ProductRemoveSuccessfully = new() {
				Code = nameof(ProductAddedSuccessfully),
				Description = "Das Produkt wurde erfolgreich entfernt."
			},
			ProductChangeQuantitySuccessfully = new() {
				Code = nameof(ProductAddedSuccessfully),
				Description = "Die Produktanzahl wurde erfolgreich geändert."
			};
	}

	public static class Error {
		public static readonly ValueObjects.Message
			ProductAddedError = new() {
				Code = nameof(ProductAddedError),
				Description = "Das Produkt konnte nicht hinzugefügt werden."
			},
			ProductRemoveError = new() {
				Code = nameof(ProductRemoveError),
				Description = "Das Produkt konnte nicht entfernt werden."
			},
			ProductChangeQuantityError = new() {
				Code = nameof(ProductChangeQuantityError),
				Description = "Die Produktanzahl konnte nicht erfolgreich geändert werden."
			},
			ProductNotFound = new() {
				Code = nameof(ProductNotFound),
				Description = "Das Produkt wurde nicht gefunden."
			};
	}
}
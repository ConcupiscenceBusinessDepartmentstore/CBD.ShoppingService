namespace CBD.ShoppingService.Core.Contracts.Responses;

public class DeleteProductResponse : BaseResponse {
	public string ProductId { get; set; }
	public static class Message {
		public static readonly ValueObjects.Message
			ProductDeletionSuccessfully = new() {
				Code = nameof(ProductDeletionSuccessfully),
				Description = "Das Produkt wurde erfolgreich gelöscht."
			};
	}

	public static class Error {
		public static readonly ValueObjects.Message
			ProductDeletionError = new() {
				Code = nameof(ProductDeletionError),
				Description = "Das Produkt wurde nicht erfolgreich gelöscht."
			};
		
		public static readonly ValueObjects.Message
			ProductDeletionErrorIdNotFound = new() {
				Code = nameof(ProductDeletionErrorIdNotFound),
				Description = "Die übergebene ProduktID hat keinen Eintrag in der Datenbank gefunden."
			};
	}
}
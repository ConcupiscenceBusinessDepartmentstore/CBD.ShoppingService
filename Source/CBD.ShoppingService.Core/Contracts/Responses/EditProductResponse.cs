namespace CBD.ShoppingService.Core.Contracts.Responses;

public class EditProductResponse : BaseResponse {
	public string ProductId { get; set; }
	public static class Message {
		public static readonly ValueObjects.Message
			ProductModificationSuccessfully = new() {
				Code = nameof(ProductModificationSuccessfully),
				Description = "Das Produkt wurde erfolgreich geändert."
			};
	}

	public static class Error {
		public static readonly ValueObjects.Message
			ProductModificationError = new() {
				Code = nameof(ProductModificationError),
				Description = "Die Änderung des Produkts war nicht erfolgreich."
			};

		public static readonly ValueObjects.Message ProductModificationErrorIdNotFound = new() {
			Code = nameof(ProductModificationErrorIdNotFound),
			Description = "Die übergebene ProduktID hat keinen Eintrag in der Datenbank gefunden."
		};
	}
}
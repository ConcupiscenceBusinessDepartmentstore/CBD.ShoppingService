namespace CBD.ShoppingService.Core.Contracts.Responses;

public class EmptyProductResponse : BaseResponse {
	public string Id { get; set; }
	public static class Message {
		public static readonly ValueObjects.Message
			BasketEmptySuccessfully = new() {
				Code = nameof(BasketEmptySuccessfully),
				Description = "Der Warenkorb wurde erfolgreich geleert."
			};
	}

	public static class Error {
		public static readonly ValueObjects.Message
			BasketEmptyError = new() {
				Code = nameof(BasketEmptyError),
				Description = "Die Löschung des Warenkorbinhalts ist fehlgeschlagen."
			},
			BasketEmptyErrorBasketIdNotFound = new() {
				Code = nameof(BasketEmptyErrorBasketIdNotFound),
				Description = "Die übergebene WarenkorbID hat keinen Eintrag in der Datenbank."
			},
			BasketEmptyErrorUserIdNotFound = new() {
				Code = nameof(BasketEmptyErrorUserIdNotFound),
				Description = "Die übergebene BenutzerID hat keinen Eintrag in der Datenbank."
			};
	}
}
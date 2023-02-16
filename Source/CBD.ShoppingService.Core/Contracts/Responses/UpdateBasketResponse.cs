namespace CBD.ShoppingService.Core.Contracts.Responses;

public class UpdateBasketResponse : BaseResponse {
	public string UserId { get; set; }
	public string ProductId { get; set; }
	public string Quantity { get; set; }
	public static class Message {
		public static readonly ValueObjects.Message
			BasketUpdateSuccessfully = new() {
				Code = nameof(BasketUpdateSuccessfully),
				Description = "Der Warenkorb wurde erfolgreich aktualisiert."
			};
	}

	public static class Error {
		public static readonly ValueObjects.Message
			BasketUpdateError = new() {
				Code = nameof(BasketUpdateError),
				Description = "Die Aktualisierung des Warenkorbs ist fehlgeschlagen."
			},
			BasketErrorBasketIdNotFound = new() {
				Code = nameof(BasketErrorBasketIdNotFound),
				Description = "Die übergebene WarenkorbID hat keinen Eintrag in der Datenbank."
		},
			BasketErrorProductIdNotFound = new() {
				Code = nameof(BasketErrorProductIdNotFound),
				Description = "Die übergebene ProduktID hat keinen Eintrag in der Datenbank."
		},
			BasketErrorUserIdNotFound = new() {
				Code = nameof(BasketErrorUserIdNotFound),
				Description = "Die übergebene BenutzerID hat keinen Eintrag in der Datenbank."
		};
	}
}
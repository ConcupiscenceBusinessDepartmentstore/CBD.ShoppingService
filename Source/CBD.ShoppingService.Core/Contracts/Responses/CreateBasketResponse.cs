namespace CBD.ShoppingService.Core.Contracts.Responses;

public class CreateBasketResponse : BaseResponse {
	public string UserId { get; set; }

	public static class Message {
		public static readonly ValueObjects.Message
			BasketCreationSuccessfully = new() {
				Code = nameof(BasketCreationSuccessfully),
				Description = "Der Warenkorb wurde erfolgreich erstellt."
			};
	}

	public static class Error {
		public static readonly ValueObjects.Message
			BasketCreationError = new() {
				Code = nameof(BasketCreationError),
				Description = "Die Erstellung des Warenkorbs war nicht erfolgreich."
			},
			MissingRoleError = new() {
				Code = nameof(MissingRoleError),
				Description = "Es gibt keine Rolle und die Erstellung ist somit fehlgeschlagen."
			};
	}
}
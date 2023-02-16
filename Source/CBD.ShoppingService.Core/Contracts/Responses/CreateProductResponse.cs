namespace CBD.ShoppingService.Core.Contracts.Responses;

public class CreateProductResponse : BaseResponse {
	public string ProductId { get; set; }

	public static class Message {
		public static readonly ValueObjects.Message
			ProductCreationSuccessfully = new() {
				Code = nameof(ProductCreationSuccessfully),
				Description = "Das Produkt wurde erfolgreich erstellt."
			};
	}

	public static class Error {
		public static readonly ValueObjects.Message
			ProductCreationError = new() {
				Code = nameof(ProductCreationError),
				Description = "Die Erstellung des Produkts war nicht erfolgreich."
			},
			MissingRoleError = new() {
				Code = nameof(MissingRoleError),
				Description = "Es gibt keine Rolle und die Erstellung ist somit fehlgeschlagen."
			};
	}
}
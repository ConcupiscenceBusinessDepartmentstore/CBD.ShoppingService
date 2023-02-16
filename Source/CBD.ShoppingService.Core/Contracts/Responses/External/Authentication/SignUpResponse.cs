using CBD.ShoppingService.Core.Contracts.ValueObjects;

namespace CBD.ShoppingService.Core.Contracts.Responses.External.Authentication;

public class SignUpResponse : BaseResponse<SignUpResponse.Body> {
	public class Body { }
	
	public static class Messages {
		public static readonly Message SignedUp = new() {
			Code = nameof(SignedUp),
			Description = "You have been signed up"
		};
	}
}
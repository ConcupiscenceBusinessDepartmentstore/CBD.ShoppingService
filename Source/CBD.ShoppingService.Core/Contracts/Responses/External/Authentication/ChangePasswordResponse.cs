using CBD.ShoppingService.Core.Contracts.ValueObjects;

namespace CBD.ShoppingService.Core.Contracts.Responses.External.Authentication;

public class ChangePasswordResponse : BaseResponse<ChangePasswordResponse.Body> {
	public class Body { }
	
	public static class Messages {
		public static readonly Message PasswordReset = new() {
			Code = nameof(PasswordReset),
			Description = "The password has been reset successfully"
		};
	}
	
	public static class Error {
		public static readonly Message UserNotFound = new() {
			Code = nameof(UserNotFound),
			Description = "The user for the provided email address was not found"
		};
	}
}
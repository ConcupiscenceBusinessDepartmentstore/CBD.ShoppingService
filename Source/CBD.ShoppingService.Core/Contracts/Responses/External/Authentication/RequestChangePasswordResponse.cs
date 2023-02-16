using CBD.ShoppingService.Core.Contracts.ValueObjects;

namespace CBD.ShoppingService.Core.Contracts.Responses.External.Authentication; 

public class RequestChangePasswordResponse : BaseResponse<RequestChangePasswordResponse.Body> {
	public class Body { }
	
	public static class Messages {
		public static readonly Message EmailSendIfRegistered = new() {
			Code = nameof(EmailSendIfRegistered),
			Description = "An email containing the reset token was send to the provided email if registered"
		};
	}
	
	public static class Error {
		public static readonly Message UserNotFound = new() {
			Code = nameof(UserNotFound),
			Description = "The user for the provided email address was not found"
		};
	}
}
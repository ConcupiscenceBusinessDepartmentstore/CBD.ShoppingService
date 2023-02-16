using CBD.ShoppingService.Core.Contracts.ValueObjects;

namespace CBD.ShoppingService.Core.Contracts.Responses.External.Authentication; 

public class LoginResponse : BaseResponse<LoginResponse.Body> {
	public class Body {
		public string Token { get; set; } = "";
	}

	public static class Messages {
		public static readonly Message LoggedIn = new() {
			Code = nameof(LoggedIn),
			Description = "User logged in successfully"
		};
	}
	
	public static class Error {
		public static readonly Message UsernameOrEmailNotRegistered = new() {
			Code = nameof(UsernameOrEmailNotRegistered),
			Description = "The username or email is not registered"
		};
		
		public static readonly Message PasswordNotCorrect = new() {
			Code = nameof(PasswordNotCorrect),
			Description = "The password is not correct"
		};
	}
}
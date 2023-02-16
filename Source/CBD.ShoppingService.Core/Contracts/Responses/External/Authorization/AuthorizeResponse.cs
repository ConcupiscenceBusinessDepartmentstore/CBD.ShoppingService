using CBD.ShoppingService.Core.Contracts.ValueObjects;

namespace CBD.ShoppingService.Core.Contracts.Responses.External.Authorization;

public class AuthorizeResponse : AuthorizeResponse<AuthorizeResponse.Body> {
	public new class Body : AuthorizeResponse<Body>.Body { }
	
	public static class Messages {
		public static readonly Message Authorized = new() {
			Code = nameof(Authorized),
			Description = "The User is authorized"
		};
		
		public static readonly Message Unauthorized = new() {
			Code = nameof(Authorized),
			Description = "The User is not authorized"
		};
	}
	
	public static class Error {
		public static readonly Message InvalidToken = new() {
			Code = nameof(InvalidToken),
			Description = "The provided token is not valid"
		};
		
		public static readonly Message ExpiredToken = new() {
			Code = nameof(ExpiredToken),
			Description = "The token expired and is not valid anymore"
		};
	}
}

public class AuthorizeResponse<TBody> : BaseResponse<TBody> where TBody : AuthorizeResponse<TBody>.Body {
	public class Body {
		public bool Authorized { get; set; }
	}
}
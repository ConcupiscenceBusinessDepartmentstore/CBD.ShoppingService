using CBD.ShoppingService.Core.Contracts.ValueObjects;

namespace CBD.ShoppingService.Core.Contracts.Responses.External.Authorization;

public class AuthorizeGlobalRoleResponse : AuthorizeResponse<AuthorizeGlobalRoleResponse.Body> {
	public new class Body : AuthorizeResponse<Body>.Body { }

	public static class Error {
		public static readonly Message UserNotFound = new() {
			Code = nameof(UserNotFound),
			Description = "No user was found for the provided token"
		};
		
		public static readonly Message UserNotInRole = new() {
			Code = nameof(UserNotInRole),
			Description = "The user does not belong to the provided global role"
		};
	}
}
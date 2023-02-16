using CBD.ShoppingService.Core.Contracts.ValueObjects;

namespace CBD.ShoppingService.Core.Contracts.Responses.External.Messagermation;

public class GetUserByIdResponse : BaseResponse<GetUserByIdResponse.Body> {
	public class Body {
	}

	public static class Messages {
		public static readonly Message UserReturnedSuccessfully = new Message {
			Code = nameof(UserReturnedSuccessfully),
			Description = "User was returned successfully"
		};
	}
	
	public static class Error {
		public static readonly Message UserNotFound = new Message {
			Code = nameof(UserNotFound),
			Description = "The id does not belong to an existing user"
		};
	}
}
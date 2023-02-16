using CBD.ShoppingService.Core.Contracts.ValueObjects;

namespace CBD.ShoppingService.Core.Contracts.Responses.External.Messagermation; 

public class GetUsersByNameOrEmailResponse : BaseResponse<GetUsersByNameOrEmailResponse.Body> {
	public class Body {
	}

	public static class Messages {
		public static readonly Message SuitableUsersReturned = new Message {
			Code = nameof(SuitableUsersReturned),
			Description = "All suitable user for the specified query where returned successfully"
		};
	}
}
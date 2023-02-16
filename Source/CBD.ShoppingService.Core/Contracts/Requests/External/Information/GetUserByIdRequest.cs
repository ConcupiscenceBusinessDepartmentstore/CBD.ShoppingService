using System.ComponentModel.DataAnnotations;

namespace CBD.ShoppingService.Core.Contracts.Requests.Information;

public class GetUserByIdRequest {
	[Required] public string UserId { get; set; }
}
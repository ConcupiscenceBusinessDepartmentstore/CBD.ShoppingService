using System.ComponentModel.DataAnnotations;

namespace CBD.ShoppingService.Core.Contracts.Requests.Information;

public class GetUserClaimsForUserRequest {
	[Required] public string UnitId { get; set; }
}
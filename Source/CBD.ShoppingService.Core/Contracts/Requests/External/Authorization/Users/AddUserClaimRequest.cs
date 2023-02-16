using System.ComponentModel.DataAnnotations;

namespace CBD.ShoppingService.Core.Contracts.Requests.Authorization.Users; 

public class AddUserClaimRequest {
	[Required] public string UnitId { get; set; }
	[Required] public string UserId { get; set; }
	[Required] public string Type { get; set; }
	[Required] public string Value { get; set; }
}
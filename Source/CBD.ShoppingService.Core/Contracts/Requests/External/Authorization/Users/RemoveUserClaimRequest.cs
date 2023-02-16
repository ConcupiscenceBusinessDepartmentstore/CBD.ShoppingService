using System.ComponentModel.DataAnnotations;

namespace CBD.ShoppingService.Core.Contracts.Requests.Authorization.Users;

public class RemoveUserClaimRequest {
	[Required] public string Id { get; set; }
}
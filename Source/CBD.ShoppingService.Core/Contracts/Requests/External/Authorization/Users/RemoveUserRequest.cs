using System.ComponentModel.DataAnnotations;

namespace CBD.ShoppingService.Core.Contracts.Requests.Authorization.Users;

public class RemoveUserRequest {
	[Required] public string Id { get; set; }
}
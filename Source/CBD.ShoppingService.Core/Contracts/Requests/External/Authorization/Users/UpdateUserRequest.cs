using System.ComponentModel.DataAnnotations;

namespace CBD.ShoppingService.Core.Contracts.Requests.Authorization.Users;

public class UpdateUserRequest {
	[Required] public string Id { get; set; }
	public string? Name { get; set; }
	public string? Type { get; set; }
}
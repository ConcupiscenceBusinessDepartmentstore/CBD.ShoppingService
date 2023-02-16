using System.ComponentModel.DataAnnotations;

namespace CBD.ShoppingService.Core.Contracts.Requests.Authorization.Users; 

public class AddUserRequest {
	[Required] public string RoleId { get; set; }
	[Required] public string Name { get; set; }
	[Required] public string Type { get; set; }
}
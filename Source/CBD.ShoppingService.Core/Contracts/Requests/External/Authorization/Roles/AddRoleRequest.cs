using System.ComponentModel.DataAnnotations;

namespace CBD.ShoppingService.Core.Contracts.Requests.Authorization.Roles; 

public class AddRoleRequest {
	[Required] public string Name { get; set; }
}
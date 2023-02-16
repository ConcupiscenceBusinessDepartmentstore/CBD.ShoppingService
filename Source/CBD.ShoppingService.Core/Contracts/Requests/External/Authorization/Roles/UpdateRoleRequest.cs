using System.ComponentModel.DataAnnotations;

namespace CBD.ShoppingService.Core.Contracts.Requests.Authorization.Roles; 

public class UpdateRoleRequest {
	[Required] public string Id { get; set; }
	[Required] public string Name { get; set; }
}
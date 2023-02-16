using System.ComponentModel.DataAnnotations;

namespace CBD.ShoppingService.Core.Contracts.Requests.Authorization.Roles; 

public class RemoveRoleRequest {
	[Required] public string Id { get; set; }
}
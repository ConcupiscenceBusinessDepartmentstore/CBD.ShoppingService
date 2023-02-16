using System.ComponentModel.DataAnnotations;

namespace CBD.ShoppingService.Core.Contracts.Requests.Information;

public class GetRoleByNameRequest {
	[Required] public string RoleName { get; set; }
}
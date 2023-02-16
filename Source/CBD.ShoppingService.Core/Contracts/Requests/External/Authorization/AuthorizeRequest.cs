using System.ComponentModel.DataAnnotations;

namespace CBD.ShoppingService.Core.Contracts.Requests.Authorization; 

public class AuthorizeRequest {
	[Required]
	public string Token { get; set; }
}
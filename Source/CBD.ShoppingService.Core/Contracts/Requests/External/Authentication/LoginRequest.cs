using System.ComponentModel.DataAnnotations;

namespace CBD.ShoppingService.Core.Contracts.Requests.Authentication; 

public class LoginRequest {
	[Required, EmailAddress]
	public string EmailAddress { get; set; }
	
	[Required]
	public string Password { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace CBD.ShoppingService.Core.Contracts.Requests.Authentication; 

public class RequestChangePasswordRequest {
	[Required, EmailAddress]
	public string Email { get; set; }
}
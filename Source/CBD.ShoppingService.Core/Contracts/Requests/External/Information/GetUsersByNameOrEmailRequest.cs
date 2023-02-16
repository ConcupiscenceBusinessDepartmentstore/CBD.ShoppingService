using System.ComponentModel.DataAnnotations;

namespace CBD.ShoppingService.Core.Contracts.Requests.Information;

public class GetUsersByNameOrEmailRequest {
	[Required, EmailAddress] public string EmailAddress { get; set; }
}
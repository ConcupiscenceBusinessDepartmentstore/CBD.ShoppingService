using System.ComponentModel.DataAnnotations;
using CBD.ShoppingService.Core.Contracts.Requests.Authorization;
using CBD.ShoppingService.Core.Contracts.ValueObjects;

namespace CBD.ShoppingService.Core.Contracts.Responses.External.Authorization;

public class AuthorizeGlobalRoleRequest : AuthorizeRequest {
		public string GlobalRole { get; set; }
}
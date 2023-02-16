using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using CBD.ShoppingService.Core.Contracts.Responses.External.Authorization;
using CBD.ShoppingService.Core.Enums;
using CBD.ShoppingService.Core.Options;
using CBD.ShoppingService.Core.Services;
using CBD.ShoppingService.Port.Extensions;
using AuthorizeGlobalRoleRequest = CBD.ShoppingService.Core.Contracts.Requests.Authorization.AuthorizeGlobalRoleRequest;

namespace CBD.ShoppingService.Port.Services;

public class IdentityService : IIdentityService {
	private readonly GatewayOptions optionsGateway;
	private readonly IdentityServiceOptions optionsIdentityService;

	public IdentityService(IOptions<GatewayOptions> gatewayOptions,
		IOptions<IdentityServiceOptions> identityServiceOptions) {
		this.optionsGateway = gatewayOptions.Value;
		optionsIdentityService = identityServiceOptions.Value;
	}

	public bool CheckUserHasId(string token, string userId) {
		var uid = GetUserIdFromToken(token);
		return (
			(uid is not null)
			&& (uid == userId)
		);
	}


	public async Task<bool> CheckIfUserHasGlobalRole(string token, string roleName)
	{
		using var httpClient = new HttpClient();
		var response = await httpClient.SendPostAsync<AuthorizeGlobalRoleRequest, AuthorizeGlobalRoleResponse>(this.optionsGateway.Routes.AuthorizeRole, new AuthorizeGlobalRoleRequest
		{
			Token = token,
			GlobalRole = roleName,
		});
		if (response is null || !response.Succeeded)
			return false;

		return response.Content!.Authorized;
	}

	private string? GetUserIdFromToken(string token) {
		var securityToken = new JwtSecurityTokenHandler().ReadToken(token);
		if (securityToken is not JwtSecurityToken jwtSecurityToken)
		{
			return null;
		}
		return jwtSecurityToken.Claims.FirstOrDefault(claim => claim.Type.Equals(JwtRegisteredClaimNames.Sub))?.Value;
	}
}
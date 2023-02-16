using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using CBD.ShoppingService.Core.Contracts.Requests.Authorization;
using CBD.ShoppingService.Core.Contracts.Responses.External.Authorization;
using CBD.ShoppingService.Core.Options;
using CBD.ShoppingService.Port.Extensions;

namespace CBD.ShoppingService.Core.Filters;

public class UserAuthorizedAttribute : Attribute, IAsyncAuthorizationFilter {
	public async Task OnAuthorizationAsync(AuthorizationFilterContext context) {
		if (!context.HttpContext.Request.Headers.ContainsKey(HeaderNames.Authorization)) {
			context.Result = new UnauthorizedResult();
			return;
		}

		var token = context.HttpContext.Request.Headers[HeaderNames.Authorization].ToString();
		var gatewayOptions = context.HttpContext.RequestServices.GetRequiredService<IOptions<GatewayOptions>>().Value;
		using var httpClient = new HttpClient();
		var response = await httpClient.SendPostAsync<AuthorizeRequest, AuthorizeResponse>(
			gatewayOptions.Routes.AuthorizeUser,
			new AuthorizeRequest {Token = token});
		if (response?.Content is null || !response.Content!.Authorized)
		{
			context.Result = new UnauthorizedResult();
		}
	}
}
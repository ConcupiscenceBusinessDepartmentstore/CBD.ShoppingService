namespace CBD.ShoppingService.Core.Services;

public interface IIdentityService {
	bool CheckUserHasId(string token, string userId);

	Task<bool> CheckIfUserHasGlobalRole(string token, string roleName);

}
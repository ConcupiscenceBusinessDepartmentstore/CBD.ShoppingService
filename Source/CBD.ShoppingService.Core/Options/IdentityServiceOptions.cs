namespace CBD.ShoppingService.Core.Options;

public class IdentityServiceOptions {
	public const string AppSettingsKey = nameof(IdentityServiceOptions);
	public string User { get; set; }
	public string Role { get; set; }
}
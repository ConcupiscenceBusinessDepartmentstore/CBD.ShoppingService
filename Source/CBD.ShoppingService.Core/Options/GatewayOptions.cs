namespace CBD.ShoppingService.Core.Options;

public class GatewayOptions {
	public const string AppSettingsKey = nameof(GatewayOptions);
	public Routes Routes { get; set; }
}

public class Routes {
	public string AuthorizeUser { get; set; }
	public string AuthorizeRole { get; set; }
}
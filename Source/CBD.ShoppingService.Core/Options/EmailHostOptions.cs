namespace CBD.ShoppingService.Core.Options; 

public class EmailHostOptions {
	public const string AppSettingsKey = nameof(EmailHostOptions);

	public string AuthEmailHost { get; set; }
	public int AuthEmailHostPort { get; set; }
	public string AuthEmailAddress { get; set; }
	public string AuthEmailPassword { get; set; }
}
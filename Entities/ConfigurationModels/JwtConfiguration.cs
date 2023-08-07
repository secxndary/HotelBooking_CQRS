namespace Entities.ConfigurationModels;

public class JwtConfiguration
{
    public string Section { get; set; } = "JwtSettings";
    public string? ValidIssuer { get; set; }
    public string? ValidAudience { get; set; }
    public bool ValidateLifetime { get; set; }
    public int AccessExpiresMinutes { get; set; }
    public int RefreshExpiresDays { get; set; }
}
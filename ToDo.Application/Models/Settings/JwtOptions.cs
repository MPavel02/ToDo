namespace ToDo.Application.Models.Settings;

public class JwtOptions
{
    public string TokenPrivateKey { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public int ExpiryMinutes { get; set; }
}
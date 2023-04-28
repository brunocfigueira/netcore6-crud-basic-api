namespace NetcoreCrudBaseApi.Infrastructure.Auth;

public class TokenConfiguration
{
    public string SecurityKey { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public int DurationInHours { get; set; }
    public int DurationInMinutes { get; set; }
}

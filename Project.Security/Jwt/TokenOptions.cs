namespace Project.Security.Jwt;

public class TokenOptions
{
    public string Audience { get; set; }
    public string Issuer { get; set; }
    public int AccessTokenExpiration { get; set; }
    public string SecurityKey { get; set; }

    // refresh token ne kadar süre kullanılabilir.
    public string RefresHTokenTTL { get; set; }

}

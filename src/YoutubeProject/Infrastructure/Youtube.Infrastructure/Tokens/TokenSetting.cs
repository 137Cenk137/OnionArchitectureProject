namespace Youtube.Infrastructure.Tokens;


public class TokenSetting 
{
    public string Audience { get; set; }
    public string Issuer { get; set; }
    public string Secret { get; set; }
    public int TokenValidityInMinutes { get; set; }

}
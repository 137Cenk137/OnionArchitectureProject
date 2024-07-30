using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Youtube.Application.Interfaces.Tokens;
using Youtube.Domain.Entities;

namespace Youtube.Infrastructure.Tokens;

public class TokenService : ITokenService
{
  private readonly TokenSetting _tokenSetting;
    private readonly UserManager<User> _userManager;
    public TokenService(IOptions<TokenSetting> options, UserManager<User> userManager)
    {
            _tokenSetting = options.Value;
            _userManager = userManager;
    } 
    public async Task<JwtSecurityToken> CreateToken(User user, IList<string> roles)
    {
        var claims = new List<Claim>()
        {
            new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email,user.Email),
        };
        
        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role,role));
        } 
    

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenSetting.Secret));
        var token = new JwtSecurityToken(
            issuer: _tokenSetting.Issuer,
            audience: _tokenSetting.Audience,
            expires: DateTime.Now.AddMinutes(_tokenSetting.TokenValidityInMinutes),
            claims : claims,
            signingCredentials: new SigningCredentials(key,SecurityAlgorithms.HmacSha256)
            );
        
            await _userManager.AddClaimsAsync(user,claims);
            return token;
    }
    public string GenerateRefreshToken()
    {
        var randomNumber = new byte[64];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber); 
    }
    public ClaimsPrincipal? GetPrincipalFromExpiredToken(string token)
    {
        TokenValidationParameters tokenValidationParameters = new()
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenSetting.Secret)),
            ValidateLifetime = false
        };

        JwtSecurityTokenHandler tokenHandler = new();

        var principal =  tokenHandler.ValidateToken(token,tokenValidationParameters,out SecurityToken securityToken);
        if(securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,StringComparison.InvariantCultureIgnoreCase))
        {throw new SecurityTokenException("Token could not find");}
        return principal; 

    }
}
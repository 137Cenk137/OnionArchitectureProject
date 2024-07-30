using System.Security.Claims;
using Youtube.Domain.Entities;

using System.IdentityModel.Tokens.Jwt;



namespace  Youtube.Application.Interfaces.Tokens;

public interface ITokenService 
{
    Task<JwtSecurityToken> CreateToken(User user, IList<string> roles);

    string GenerateRefreshToken();

    ClaimsPrincipal? GetPrincipalFromExpiredToken(string token);
}
using System.IdentityModel.Tokens.Jwt;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Youtube.Application.Bases;
using Youtube.Application.Features.Auth.Rules;
using Youtube.Application.Interfaces.AutoMapper;
using Youtube.Application.Interfaces.Tokens;
using Youtube.Application.Interfaces.UnitOfWorks;
using Youtube.Domain.Entities;

namespace Youtube.Application.Features.Auth.Command.Login;

public class LoginCommandHandler : BaseHandler,IRequestHandler<LoginCommandRequest, LoginCommandResponse>
{
    private readonly UserManager<User> _userManager;
    private readonly AuthRules _authRules;
    private readonly ITokenService _tokenService;
    //private readonly ITokenSetting _tokenSetting; dene bakalım
    private readonly IConfiguration _configuration;
    public LoginCommandHandler(IConfiguration configuration, ITokenService  tokenService,AuthRules authRules,UserManager<User> userManager,IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor contextAccessor) : base(mapper, unitOfWork, contextAccessor)
    {
        _userManager = userManager;
        _authRules = authRules;
         _tokenService = tokenService; 
         _configuration = configuration;

    }

    public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
    {


        User user = await _userManager.FindByEmailAsync(request.Email); 
        bool checkPassword = await _userManager.CheckPasswordAsync(user, request.Password);
        await _authRules.EmailOrPasswordShouldNotBeInvalid(user,checkPassword);

        IList<string> roles = await _userManager.GetRolesAsync(user);

        JwtSecurityToken token = await _tokenService.CreateToken(user, roles);

        string refreshToken =  _tokenService.GenerateRefreshToken();
        _ = int.TryParse (_configuration["JWT:RefreshTokenValidityInDays"],out int refreshTokenValidityInDays);

        user.RefreshToken = refreshToken;
        user.RefreshTokenExpiryTime = DateTime.Now.AddDays(refreshTokenValidityInDays);
        
        await _userManager.UpdateAsync(user);
        await _userManager.UpdateSecurityStampAsync(user);

        string _token = new JwtSecurityTokenHandler().WriteToken(token);

        await _userManager.SetAuthenticationTokenAsync(user,"Default","AccessToken",_token);

        return new LoginCommandResponse(){
            Token = _token,
            RefreshToken = refreshToken,
            Expiration = token.ValidTo
        };




        
    }
}
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Youtube.Application.Interfaces.Tokens;
using Youtube.Infrastructure.Tokens;

namespace Youtube.Infrastructure;

public static class Registration
{
    public static void AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
    {
        services.Configure<TokenSetting>(configuration.GetSection("JWT"));
        services.AddTransient<ITokenService,TokenService>(); 

        services.AddAuthentication(opt => {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;


                
        }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opt => {
            opt.SaveToken = false;
            opt.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                 IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"])),
                ValidateLifetime = false,
                ValidIssuer = configuration["JWT:Issuer"],
                ValidAudience = configuration["JWT:Audience"],
                ClockSkew = TimeSpan.Zero


            };
        });
    }
}
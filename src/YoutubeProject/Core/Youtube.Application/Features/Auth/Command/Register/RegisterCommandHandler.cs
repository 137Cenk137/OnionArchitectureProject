using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Youtube.Application.Bases;
using Youtube.Application.Features.Auth.Rules;
using Youtube.Application.Interfaces.AutoMapper;
using Youtube.Application.Interfaces.UnitOfWorks;
using Youtube.Domain.Entities;

namespace Youtube.Application.Features.Auth.Command.Register;

public class RegisterCommandHandler : BaseHandler, IRequestHandler<RegisterCommandRequest, Unit>
{
    private readonly AuthRules _authRules;
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<Role> _roleManager;
    public RegisterCommandHandler(AuthRules authRules,UserManager<User> userManager,RoleManager<Role> roleManager,IMapper mapper,IUnitOfWork unitOfWork,IHttpContextAccessor contextAccessor): base (mapper,unitOfWork,contextAccessor)
    {
            _authRules = authRules;
            _userManager = userManager;
                _roleManager = roleManager;
    }
    public async Task<Unit> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
    {
        
    
        await _authRules.UserShouldNotBeExist(await _userManager.FindByEmailAsync(request.Email));
        //User user  = _mapper.Map<User,RegisterCommandRequest>(request);
        User user = new(){
            FullName = request.FullName,
            PasswordHash = request.Password,

        };
        user.UserName = request.Email;
        user.SecurityStamp = Guid.NewGuid().ToString();

        IdentityResult result = await _userManager.CreateAsync(user,request.Password);
        if(result.Succeeded)
        {
            if(!await _roleManager.RoleExistsAsync("user"))
            {
                await _roleManager.CreateAsync(new Role(){
                    Id = Guid.NewGuid(),
                    Name = "user",
                    NormalizedName = "USER",
                    ConcurrencyStamp =  Guid.NewGuid().ToString()
                });
            }
            await _userManager.AddToRoleAsync(user,"user");
        }
        return Unit.Value;

    }
}
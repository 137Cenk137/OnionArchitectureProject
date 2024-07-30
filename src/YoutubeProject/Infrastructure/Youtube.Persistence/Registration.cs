using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Youtube.Application.Interfaces.Repositories;
using Youtube.Application.Interfaces.UnitOfWorks;
using Youtube.Domain.Entities;
using Youtube.Persistence.Context;
using Youtube.Persistence.Repositories;
using Youtube.Persistence.UnitOfWorks;

namespace Youtube.Persistence;

public static class Registration 
{
    public static void AddPersistence(this IServiceCollection services,IConfiguration configuration)
    {
        //ef core design packeti set a start up projelerinde inditilmeli
         services.AddDbContext<AppDbContext>(opt => opt.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        services.AddScoped(typeof(IReadRepository<>),typeof(ReadRepository<>));
        services.AddScoped(typeof(IWriteRepository<>),typeof(WriteRepository<>));
        services.AddScoped<IUnitOfWork,UnitOfWork>();
        //services.AddScoped(typeof(IUnitOfWork),typeof(UnitOfWork));
        services.AddIdentityCore<User>(opt => {
            opt.Password.RequireNonAlphanumeric = false;
            opt.Password.RequiredLength = 2;
            opt.Password.RequireLowercase = false;
            opt.Password.RequireUppercase = false;
            opt.Password.RequireDigit = false;
            opt.SignIn.RequireConfirmedEmail = false;


        })
                    .AddRoles<Role>()
                    .AddEntityFrameworkStores<AppDbContext>() ;
    }
} 
    
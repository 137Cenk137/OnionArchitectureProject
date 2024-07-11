using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Youtube.Persistence.Context;

namespace Youtube.Persistence;

public static class Registration 
{
    public static void AddPersistence(this IServiceCollection services,IConfiguration configuration)
    {
        //ef core design packeti set a start up projelerinde inditilmeli
         services.AddDbContext<AppDbContext>(opt => opt.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

    }
} 
    
using Microsoft.Extensions.DependencyInjection;
using Youtube.Application.Interfaces.AutoMapper;

namespace Youtube.Mapper;

public static class Registration
{
    public static void AddCustomMapper(this IServiceCollection services)
    {
        services.AddSingleton<IMapper,AutoMapper.Mapper>();
    }
}
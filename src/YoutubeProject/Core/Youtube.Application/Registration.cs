using System.Globalization;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Youtube.Application.Bases;
using Youtube.Application.Behaviors;
using Youtube.Application.Exceptions;
using Youtube.Application.Features.Products.Rules;

namespace Youtube.Application;

public static class Registration
{
    public static void AddApplication(this IServiceCollection services)
    {
        var assembly  = Assembly.GetExecutingAssembly();
        services.AddTransient<ExceptionsMiddleware>();
        //services.AddTransient<ProductRules>();

        services.AddRulesFromAssemblyContaning(assembly,typeof(BaseRules));
       // ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("tr-TR");

        services.AddMediatR(cfg =>cfg.RegisterServicesFromAssembly(assembly));

        services.AddValidatorsFromAssembly(assembly);
        services.AddTransient(typeof(IPipelineBehavior<,>),typeof(FluentValidationBehavior<,>));
    }

    private static IServiceCollection AddRulesFromAssemblyContaning(this IServiceCollection services,Assembly assembly,Type type)
    {
        var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type)&& type != t ).ToList();

        foreach (var item in types)
        {
            services.AddTransient(item);
        }
        return services;
    }

} 
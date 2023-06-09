using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ContactRegister.Configuration;

public static class MvcConfiguration
{
    public static void AddMvcConfiguration(this IServiceCollection services)
    {
        services
            .AddControllersWithViews()
            .AddFluentValidation(options => options.RegisterValidatorsFromAssembly(Assembly.Load("ContactRegister")));
    }
}
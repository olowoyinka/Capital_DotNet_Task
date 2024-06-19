using DynamicApplication.Service.Implementations;
using DynamicApplication.Service.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DynamicApplication.Service;


public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IApplicationProgramService, ApplicationProgramService>();

        return services;
    }
}
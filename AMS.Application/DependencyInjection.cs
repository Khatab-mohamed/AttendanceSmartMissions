using AMS.Application.Services.Location;
using Microsoft.Extensions.DependencyInjection;

namespace AMS.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddTransient<ILocationService,LocationService>();
        return services;
    }

}
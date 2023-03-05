using AMS.Application.Services.Authentication;
using Microsoft.AspNetCore.Http;
using System.Security.Principal;

namespace AMS.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddTransient<ILocationService,LocationService>();
        services.AddTransient<IUserService,UserService>();
        // Inject IPrincipal
        services.AddHttpContextAccessor();
        services.AddTransient<IPrincipal>(provider => provider.GetService<IHttpContextAccessor>()!.HttpContext.User);
        //services.AddScoped<IUrlHelper>(implementationFactory =>
        //{
        //    var actionContext = implementationFactory.GetService<IActionContextAccessor>()
        //        .ActionContext;
        //    return new UrlHelper(actionContext);
        //});


        return services;
    }

}
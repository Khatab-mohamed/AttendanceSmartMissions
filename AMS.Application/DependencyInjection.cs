using AMS.Application.Services.Authentication;

namespace AMS.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddTransient<ILocationService,LocationService>();
        services.AddTransient<IUserService,UserService>();
       
        //services.AddScoped<IUrlHelper>(implementationFactory =>
        //{
        //    var actionContext = implementationFactory.GetService<IActionContextAccessor>()
        //        .ActionContext;
        //    return new UrlHelper(actionContext);
        //});


        return services;
    }

}
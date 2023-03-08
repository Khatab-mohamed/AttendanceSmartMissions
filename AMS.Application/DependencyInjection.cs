using AMS.Application.Services.Attendance;

namespace AMS.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddTransient<ILocationService,LocationService>();
        services.AddTransient<IRoleService, RoleService>();
        services.AddTransient<IUserService,UserService>();
        services.AddTransient<IAttendanceService, AttendanceService>();
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
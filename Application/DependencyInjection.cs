using Application.Interfaces.Services;
using Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IActivityService, ActivityService>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IImageService, ImageService>();
        services.AddScoped<IRatingService, RatingService>();
        services.AddScoped<IRequestService, RequestService>();
        services.AddScoped<IUserService, UserService>();
        return services;
    }
}

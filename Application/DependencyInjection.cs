using Application.Interfaces;
using Application.Services;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IActivityService, ActivityService>();
        services.AddScoped<IImageService, ImageService>();
        services.AddScoped<IRequestService, RequestService>();
        services.AddScoped<IUserService, UserService>();
        return services;
    }
}

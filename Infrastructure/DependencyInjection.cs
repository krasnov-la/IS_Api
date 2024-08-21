using Application.Interfaces.Infrastructure;
using Application.Interfaces.Repositories;
using Infrastructure.Common;
using Infrastructure.Options.Authentication;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols.Configuration;

namespace Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddRepositories();
        services.AddCommon();
        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IActivityRepository, ActivityRepository>();
        services.AddScoped<IImageRepository, ImageRepository>();
        services.AddScoped<IRatingRepository, RatingRepository>();
        services.AddScoped<IRequestRepository, RequestRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }

    private static IServiceCollection AddCommon(this IServiceCollection services)
    {
        services.AddScoped<ITokenIssuer, TokenIssuer>();
        services.AddScoped<IOAuthHandler, OAuthHandler>();
        return services;
    }
}
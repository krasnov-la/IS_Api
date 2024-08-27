using Application.Interfaces.Infrastructure;
using Application.Interfaces.Repositories;
using Infrastructure.Common;
using Infrastructure.Persistance;
using Infrastructure.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPersistance(configuration);
        services.AddCommon();
        return services;
    }

    private static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ISDBContext>(p => p.UseNpgsql(configuration.GetConnectionString("Postgre")));
        services.AddScoped<DbContext, ISDBContext>();

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
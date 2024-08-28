using System.Security.Claims;
using System.Text;
using Application.Interfaces.Infrastructure;
using Application.Interfaces.Repositories;
using Domain.Enums;
using Infrastructure.Common;
using Infrastructure.Options.Authentication;
using Infrastructure.Persistance;
using Infrastructure.Persistance.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPersistance(configuration);
        services.AddCommon(configuration);
        services.AddISAuth(configuration);
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

    private static IServiceCollection AddCommon(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));
        services.AddScoped<ITokenIssuer, TokenIssuer>();
        services.AddScoped<IOAuthHandler, OAuthHandler>();
        return services;
    }

    private static IServiceCollection AddISAuth(this IServiceCollection services, IConfiguration configuration)
    {
        var jwt = configuration.GetSection("JwtOptions");
        services
        .AddAuthentication(o => {
            o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(o => {
            o.TokenValidationParameters = new TokenValidationParameters{
                ValidIssuer = jwt["Issuer"],
                ValidAudience = jwt["Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(jwt["Key"])),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true
            };
        });

        services
        .AddAuthorizationBuilder()
        .AddDefaultPolicy("NonBanned", o => 
        {
            o.RequireClaim(ClaimTypes.Role, [
                Role.Admin.ToString(), 
                Role.Student.ToString(), 
                Role.Unverified.ToString()]);
        })
        .AddPolicy("Admin", o => 
        {
            o.RequireClaim(ClaimTypes.Role, Role.Admin.ToString());
        })
        .AddPolicy("Student", o => {
            o.RequireClaim(ClaimTypes.Role, Role.Student.ToString());
        })
        .AddPolicy("Verificated", o => {
            o.RequireClaim(ClaimTypes.Role, [
                Role.Student.ToString(),
                Role.Admin.ToString()
            ]);
        });

        return services;
    }
}
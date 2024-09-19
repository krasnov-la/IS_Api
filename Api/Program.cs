using System.Text.Json.Serialization;
using Application;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

if (!builder.Environment.IsDevelopment())
    builder.Configuration.AddJsonFile("secrets.json", false);

builder.Services.AddCors(o => o.AddPolicy(
    name: "Default",
    policy => 
    {
        var origins = builder.Configuration.GetSection("AllowedOrigins");
        policy
        .WithOrigins(
            builder
            .Configuration
            .GetSection("AllowedOrigins")
            .GetChildren()
            .Select(c => c.Value ?? throw new ArgumentException("Allowed origin cannot be null"))
            .ToArray())
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();
    }
));

builder.Services.AddControllers();
builder.Services.AddApplication(builder.Configuration);
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => 
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
         Name = "Authorization",
         In = ParameterLocation.Header,
         Type = SecuritySchemeType.ApiKey,
         Scheme = "Bearer"
       });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Name = "Bearer",
                    In = ParameterLocation.Header,
                    Reference = new OpenApiReference
                    {
                        Id = "Bearer",
                        Type = ReferenceType.SecurityScheme
                    }
                },
                new List<string>()
            }
        });

});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(o => {
    o.DocumentTitle = "IS_Api";
});

app.UseHttpsRedirection();

app.UseCors("Default");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
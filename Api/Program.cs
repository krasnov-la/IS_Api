using System.Text.Json.Serialization;
using Application;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

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
builder.Services.AddSwaggerGen();

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
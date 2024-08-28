using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Text.Json;
using Application.DTO;
using Application.Errors;
using Application.Interfaces.Infrastructure;
using FluentResults;

namespace Infrastructure.Common;

public class OAuthHandler() : IOAuthHandler
{
    public async Task<Result<YandexUserData>> GetUserData(string oAuth)
    {
        var client = new HttpClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("OAuth", oAuth);
        var response = await client.GetAsync("https://login.yandex.ru/info?format=json");
        var token = await response.Content.ReadAsStringAsync();
        var deserialize = JsonSerializer.Deserialize<YandexUserData>(token);
        if (deserialize is null || deserialize.AvatarId is null || deserialize.Email is null) return Result.Fail(new OAuthError());
        return Result.Ok(deserialize);
    }
}
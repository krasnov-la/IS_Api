
using Application.DTO;
using FluentResults;

namespace Application.Interfaces.Infrastructure;

public interface IOAuthHandler
{
    Task<Result<YandexUserData>> GetUserData(string oAuth);
}
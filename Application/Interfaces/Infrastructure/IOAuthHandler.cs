
using Application.DTO;

namespace Application.Interfaces.Infrastructure;

public interface IOAuthHandler
{
    Task<YandexUserData> GetUserData(string oAuth);
}
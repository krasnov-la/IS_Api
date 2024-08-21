using Application.DTO;
using Application.Interfaces.Infrastructure;

namespace Infrastructure.Common;

public class OAuthHandler : IOAuthHandler
{
    public Task<YandexUserData> GetUserData(string oAuth)
    {
        throw new NotImplementedException();
    }
}
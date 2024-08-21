using Application.DTO;
using Application.Errors.Common;
using Application.Interfaces.Infrastructure;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;

namespace Application.Services;

public class AuthenticationService(
    ITokenIssuer tokenIssuer,
    IUserRepository userRepository,
    IOAuthHandler oAuth) : IAuthenticationService
{
    private readonly ITokenIssuer _tokenIssuer = tokenIssuer;
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IOAuthHandler _oAuth = oAuth;
    public async Task<string> Login(string oAuth)
    {
        YandexUserData userData = await _oAuth.GetUserData(oAuth);
        var userFetchResult = await _userRepository.GetByEmail(userData.Email);
        User user;
            
        if (userFetchResult.HasError<UserNotFoundError>())
        {
            user = User.Create(userData.AvatarId, userData.Email);
            await _userRepository.Create(user);
        }
        else
        {
            user = userFetchResult.Value;
        }

        return _tokenIssuer.IssueToken(user);
    }
}
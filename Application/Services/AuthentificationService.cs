using Application.DTO;
using Application.Errors;
using Application.Interfaces.Infrastructure;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;
using FluentResults;

namespace Application.Services;

public class AuthenticationService(
    ITokenIssuer tokenIssuer,
    IUserRepository userRepository,
    IOAuthHandler oAuth) : IAuthenticationService
{
    private readonly ITokenIssuer _tokenIssuer = tokenIssuer;
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IOAuthHandler _oAuth = oAuth;
    public async Task<Result<AuthenticationDto>> Login(string oAuth)
    {
        Result<YandexUserData> oauthResult = await _oAuth.GetUserData(oAuth);
        if (oauthResult.IsFailed) return Result.Fail(oauthResult.Errors);
        var userData = oauthResult.Value;
        var userFetchResult = await _userRepository.GetByEmail(userData.Email);
        User user;
            
        if (userFetchResult.HasError<UserNotFoundError>())
        {
            var result = User.Create(userData.Email, userData.AvatarId, userData.DisplayName);
            if (result.IsFailed) return Result.Fail(result.Errors);
            user = result.Value;
            await _userRepository.Create(user);
        }
        else
        {
            user = userFetchResult.Value;
        }

        if (user.AvatarImgLink != userData.AvatarId)
        {
            user.UpdateImage(userData.AvatarId);
            await _userRepository.Update(user);
        }

        return new AuthenticationDto(
            Email: userData.Email,
            AccessToken: _tokenIssuer.IssueToken(user));
    }
}
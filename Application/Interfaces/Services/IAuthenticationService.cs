

using FluentResults;

namespace Application.Interfaces.Services;

public interface IAuthenticationService
{
    Task<Result<string>> Login(string oAuth);
}



using Application.DTO;
using FluentResults;

namespace Application.Interfaces.Services;

public interface IAuthenticationService
{
    Task<Result<AuthenticationDto>> Login(string oAuth);
}

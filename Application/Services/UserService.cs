using System.Security.Claims;
using Application.DTO;
using Application.Interfaces;
using Domain.Enums;
using FluentResults;

namespace Application.Services;

public class UserService : IUserService
{
    public Task<Result> Ban(ClaimsPrincipal user, string email)
    {
        throw new NotImplementedException();
    }

    public Task<Result<UserDto>> GetByMail(string email)
    {
        throw new NotImplementedException();
    }

    public Task<Result> Unban(ClaimsPrincipal user, string email)
    {
        throw new NotImplementedException();
    }

    public Task<Result<UserDto>> Update(ClaimsPrincipal user, string? firstName, string? middleName, string? lastName, string? nickname, string? course)
    {
        throw new NotImplementedException();
    }

    public Task<Result> Verify(string email, Role role)
    {
        throw new NotImplementedException();
    }
}
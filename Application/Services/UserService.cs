using System.Security.Claims;
using Application.Commands;
using Application.DTO;
using Application.Interfaces.Services;
using Domain.Enums;
using FluentResults;

namespace Application.Services;

public class UserService : IUserService
{
    public Task<Result> Ban(BanUserCommand command)
    {
        throw new NotImplementedException();
    }

    public Task<Result<UserDto>> GetByMail(string email)
    {
        throw new NotImplementedException();
    }

    public Task<Result> Unban(BanUserCommand command)
    {
        throw new NotImplementedException();
    }

    public Task<Result<UserDto>> Update(UpdateUserCommand command)
    {
        throw new NotImplementedException();
    }

    public Task<Result> Verify(UserVerificationCommand command)
    {
        throw new NotImplementedException();
    }
}
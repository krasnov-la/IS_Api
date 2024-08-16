using System.Security.Claims;
using Application.Commands.Users;
using Application.DTO;
using Domain.Enums;
using FluentResults;

namespace Application.Interfaces.Services;

public interface IUserService
{
    Task<Result> Ban(BanUserCommand command);
    Task<Result<UserDto>> GetByMail(string email);
    Task<Result> Unban(BanUserCommand command);
    Task<Result<UserDto>> Update(UpdateUserCommand command);
    Task<Result> Verify(UserVerificationCommand command);
}
using System.Security.Claims;
using Application.DTO;
using Domain.Enums;
using FluentResults;

namespace Application.Interfaces;

public interface IUserService
{
    Task<Result> Ban(ClaimsPrincipal user, string email);
    Task<Result<UserDto>> GetByMail(string email);
    Task<Result> Unban(ClaimsPrincipal user, string email);
    Task<Result<UserDto>> Update(ClaimsPrincipal user, string? firstName, string? middleName, string? lastName, string? nickname, string? course);
    Task<Result> Verify(string email, Role role);
}
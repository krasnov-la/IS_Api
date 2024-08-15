using System.Security.Claims;

namespace Application.Commands;

public record UpdateUserCommand(
    ClaimsPrincipal User,
    string? FirstName,
    string? MiddleName,
    string? LastName,
    string? Nickname,
    string? Course);
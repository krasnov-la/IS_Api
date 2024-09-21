using System.Security.Claims;

namespace Application.Commands.Users;

public record UpdateUserCommand(
    ClaimsPrincipal User,
    string? Nickname,
    string? Course);
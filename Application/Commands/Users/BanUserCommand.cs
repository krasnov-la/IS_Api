using System.Security.Claims;

namespace Application.Commands.Users;

public record BanUserCommand(
    ClaimsPrincipal User,
    string Email);
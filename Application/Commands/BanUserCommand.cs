using System.Security.Claims;

namespace Application.Commands;

public record BanUserCommand(
    ClaimsPrincipal User,
    string Email);
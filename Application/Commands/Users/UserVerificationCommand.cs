using Domain.Enums;

namespace Application.Commands.Users;

public record UserVerificationCommand(
    string Email,
    Role Role);
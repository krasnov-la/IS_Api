using Domain.Enums;

namespace Application.Commands;

public record UserVerificationCommand(
    string Email,
    Role Role);
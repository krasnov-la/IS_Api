namespace Contracts.Users;

public record UserUpdateRequest(
    string? Nickname,
    string? Course
);
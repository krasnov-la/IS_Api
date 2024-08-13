namespace Contracts.Users;

public record UserUpdateRequest(
    string? Nickname,
    string? FirstName,
    string? LastName,
    string? MiddleName,
    string? Course
);
namespace Application.DTO;

public record UserDto(
    string AvatarImgLink,
    string Nickname,
    string EmailAddress,
    string FirstName,
    string LastName,
    string? MiddleName,
    string Role,
    string? Course,
    string? BannedBy
);
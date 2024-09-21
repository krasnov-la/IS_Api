using System.Text.Json.Serialization;

namespace Contracts.Users;

public record UserShortResponse(
    string? AvatarImgLink,
    string? Nickname,
    string FullName,
    string EmailAddress,
    string Role,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    string? Course
);
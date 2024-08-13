using System.Text.Json.Serialization;

namespace Contracts.Users;

public record UserFullResponse(
    string? AvatarImgLink,
    string? Nickname,
    string EmailAddress,
    string? FirstName,
    string? LastName,
    string? MiddleName,
    string Role,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    string? Course,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    string? BannedBy
);
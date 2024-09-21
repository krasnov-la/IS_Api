using System.Text.Json.Serialization;

namespace Application.DTO;

public record YandexUserData(
    [property: JsonPropertyName("default_email")]
    string Email,
    [property: JsonPropertyName("default_avatar_id")]
    string AvatarId,
    [property: JsonPropertyName("display_name")]
    string DisplayName
);
namespace Application.DTO.Authentication;

public class TokensDto
(
    string accessToken,
    string refreshToken,
    DateTime refreshExpire
)
{
    public string AccessToken {get; init; } = accessToken;
    public string RefreshToken {get; init; } = refreshToken;
    public DateTime RefreshExpire {get; init; } = refreshExpire;
}
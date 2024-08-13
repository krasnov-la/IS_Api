namespace Application.DTO.Authentication;

public class AuthenticationDto(string login, TokensDto tokens)
{
    public string Login { get; init; } = login;
    public TokensDto Tokens { get; init; } = tokens;
}
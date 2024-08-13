namespace Infrastructure.Options.Authentication;

public class CookieOptions
{
    public required string Token { get; init; }
    public required string Refresh { get; init; }
    public required string ExpirationFlag { get; init; }
    public required string ExpirationPyload { get; init; }
}
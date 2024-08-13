namespace Infrastructure.Options.Authentication;

public class JwtOptions //TODO: add section name as static value
{
    public required string Issuer { get; init; }
    public required string Audience { get; init; }
    public required string Key { get; init; }
}
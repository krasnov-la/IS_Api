namespace Contracts.Authentication;

public record AuthenticationResponse(
    string Email,
    string AccessToken
);

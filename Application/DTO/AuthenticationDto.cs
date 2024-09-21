namespace Application.DTO;

public record AuthenticationDto(
    string Email,
    string AccessToken
);
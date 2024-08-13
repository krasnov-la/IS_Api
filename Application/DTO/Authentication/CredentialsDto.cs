using Domain.Enums;

namespace Application.DTO.Authentication;

public class CredentialsDto(
    string login,
    Role role,
    string hashedPassword,
    string refreshToken,
    DateTime refreshExpire
)
{
    public string Login { get; set; } = login;
    public Role Role { get; set; } = role;
    public string HashedPassword { get; set; } = hashedPassword;
    public string RefreshToken { get; set; } = refreshToken;
    public DateTime RefreshExpire { get; set; } = refreshExpire;
}
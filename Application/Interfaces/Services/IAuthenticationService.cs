
namespace Application.Interfaces.Services;

public interface IAuthenticationService
{
    Task<string> GenerateToken(string oAuth);
}

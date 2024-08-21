

namespace Application.Interfaces.Services;

public interface IAuthenticationService
{
    Task<string> Login(string oAuth);
}

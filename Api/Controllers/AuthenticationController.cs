using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController(IAuthenticationService authenticationService) : ApiController
{
    private readonly IAuthenticationService _authService = authenticationService;
    [HttpGet("{oAuth}")]
    public async Task<IActionResult> GenerateToken(string oAuth)
    {
        return Ok(await _authService.GenerateToken(oAuth));
    }
}
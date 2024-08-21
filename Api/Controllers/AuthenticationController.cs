using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController(IAuthenticationService authenticationService) : ApiController
{
    private readonly IAuthenticationService _authService = authenticationService;
    [HttpGet("login/{oAuth}")]
    public async Task<IActionResult> Login(string oAuth)
    {
        return Ok(await _authService.Login(oAuth));
    }
}
using Application.Commands.Users;
using Application.DTO;
using Application.Interfaces.Services;
using Contracts.Users;
using Domain.Enums;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
[ApiController]
[Route("users")]
public class UserController(IUserService userService) : ApiController
{
    private readonly IUserService _userService = userService;
    [HttpGet("{email}")]
    [Produces(typeof(UserShortResponse))]
    public async Task<IActionResult> GetByMail(string email)
    {
        Result<UserDto> result = await _userService.GetByMail(email);
        return ResultToResponse(result, ToShortResponse);
    }

    [HttpGet("{email}/full")]
    //[Authorize] admin only
    [Produces(typeof(UserFullResponse))]
    public async Task<IActionResult> GetByMailFull(string email)
    {
        Result<UserDto> result = await _userService.GetByMail(email);
        return ResultToResponse(result, ToFullResponse);
    }

    [HttpPost("{email}/verify/{role}")]
    //[Authorize] admin only
    public async Task<IActionResult> Verify(string email, Role role)
    {
        Result result = await _userService.Verify(
            new UserVerificationCommand(email, role));
        return ResultToResponse(result);
    }

    [HttpPatch("update-personal-info")]
    //[Authorize]
    [Produces(typeof(UserFullResponse))]
    public async Task<IActionResult> UpdateInfo([FromBody] UserUpdateRequest request)
    {
        Result<UserDto> result = await _userService.Update(
            new UpdateUserCommand(
                HttpContext.User,
                request.FirstName,
                request.MiddleName,
                request.LastName,
                request.Nickname,
                request.Course
        ));
        return ResultToResponse(result, ToFullResponse);    
    }

    [HttpPost("{email}/ban")]
    //[Authorize] admin only
    public async Task<IActionResult> Ban(string email)
    {
        Result result = await _userService.Ban(new BanUserCommand(HttpContext.User, email));
        return ResultToResponse(result);
    }
    [HttpPost("{email}/unban")]
    //[Authorize] admin only
    public async Task<IActionResult> Unban(string email)
    {
        Result result = await _userService.Unban(new BanUserCommand(HttpContext.User, email));
        return ResultToResponse(result);
    }

    [NonAction]
    private static UserFullResponse ToFullResponse(UserDto dto)
    {
        return new UserFullResponse(
            AvatarImgLink: dto.AvatarImgLink,
            Nickname: dto.Nickname,
            EmailAddress: dto.EmailAddress,
            FirstName: dto.FirstName,
            LastName: dto.LastName,
            MiddleName: dto.MiddleName,
            Role: dto.Role,
            Course: dto.Course,
            BannedBy: dto.BannedBy
        );
    }

    [NonAction]
    private static UserShortResponse ToShortResponse(UserDto dto)
    {
        return new UserShortResponse(
            AvatarImgLink: dto.AvatarImgLink,
            Nickname: dto.Nickname,
            EmailAddress: dto.EmailAddress,
            Role: dto.Role,
            Course: dto.Course
        );
    }
}
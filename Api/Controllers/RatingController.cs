using Application.DTO;
using Application.Interfaces.Services;
using Contracts.Ratings;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("rating")]
public class RatingController(IRatingService ratingService) : ApiController
{
    private readonly IRatingService _ratingService = ratingService;

    [HttpGet("personal")]
    [Authorize("Student")]
    [Produces(typeof(PersonalRatingResponse))]
    public async Task<IActionResult> PersonalRating()
    {
        Result<RatingDto> result = await _ratingService.GetPersonalRating(HttpContext.User);
        return ResultToResponse(result, ToPersonalResponse);
    }

    [HttpGet("user/{email}")]
    [Produces(typeof(PersonalRatingResponse))]
    public async Task<IActionResult> GetRating(string email)
    {
        Result<RatingDto> result = await _ratingService.GetRating(email);
        return ResultToResponse(result, ToPersonalResponse);
    }

    [HttpGet("global/{count}/{offset}")]
    [Produces(typeof(List<GlobalRatingResponse>))]
    public async Task<IActionResult> GlobalRating(int count, int offset)
    {
        Result<List<RatingDto>> result = await _ratingService.GetGlobalRating(count, offset);
        return ResultToResponse(result, v => v.Select(ToGlobalResponse));
    }
    [NonAction]
    private static GlobalRatingResponse ToGlobalResponse(RatingDto dto)
    {
        return new GlobalRatingResponse(
            Place: dto.Place,
            Nickname: dto.Nickname,
            EmailAddress: dto.EmailAddress,
            AvatarImgLink: dto.AvatarImgLink,
            Score: dto.Score
        );
    }

    [NonAction]
    private static PersonalRatingResponse ToPersonalResponse(RatingDto dto)
    {
        return new PersonalRatingResponse(
            Place: dto.Place,
            Score: dto.Score
        );
    }
}
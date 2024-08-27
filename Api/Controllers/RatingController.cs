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
    [Produces(typeof(RatingResponse))]
    public async Task<IActionResult> PersonalRating()
    {
        Result<RatingDto> result = await _ratingService.GetPersonalRating(HttpContext.User);
        return ResultToResponse(result, ToResponse);
    }

    [HttpGet("global")]
    [Produces(typeof(List<RatingResponse>))]
    public async Task<IActionResult> GlobalRating()
    {
        Result<List<RatingDto>> result = await _ratingService.GetGlobalRating();
        return ResultToResponse(result, v => v.Select(ToResponse));
    }
    [NonAction]
    private static RatingResponse ToResponse(RatingDto dto)
    {
        return new RatingResponse(
            Place: dto.Place,
            Nickname: dto.Nickname,
            EmailAddress: dto.EmailAddress,
            Score: dto.Score
        );
    }
}
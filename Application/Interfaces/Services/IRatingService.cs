using System.Security.Claims;
using Application.DTO;
using FluentResults;

namespace Application.Interfaces.Services;

public interface IRatingService
{
    Task<Result<List<RatingDto>>> GetGlobalRating();
    Task<Result<RatingDto>> GetPersonalRating(ClaimsPrincipal user);
}
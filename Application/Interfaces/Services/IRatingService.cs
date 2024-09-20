using System.Security.Claims;
using Application.DTO;
using FluentResults;

namespace Application.Interfaces.Services;

public interface IRatingService
{
    Task<Result<List<RatingDto>>> GetGlobalRating(int count, int offset);
    Task<Result<RatingDto>> GetPersonalRating(ClaimsPrincipal user);
}
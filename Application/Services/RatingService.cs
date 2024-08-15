using System.Security.Claims;
using Application.DTO;
using Application.Interfaces.Services;
using FluentResults;

namespace Application.Services;

public class RatingService : IRatingService
{
    public Task<Result<List<RatingDto>>> GetGlobalRating()
    {
        throw new NotImplementedException();
    }

    public Task<Result<RatingDto>> GetPersonalRating(ClaimsPrincipal user)
    {
        throw new NotImplementedException();
    }
}
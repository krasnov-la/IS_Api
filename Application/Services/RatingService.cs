using System.Security.Claims;
using Application.DTO;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;
using FluentResults;

namespace Application.Services;

public class RatingService(IRatingRepository ratingRepository) : ServiceBase, IRatingService
{
    private readonly IRatingRepository _ratingRepository = ratingRepository;
    public async Task<Result<List<RatingDto>>> GetGlobalRating(int count, int offset)
    {
        return await _ratingRepository.GetGlobalRating(count, offset);
    }

    public async Task<Result<RatingDto>> GetPersonalRating(ClaimsPrincipal user)
    {        
        return await _ratingRepository.GetPersonalRating(new Student(ExtractEmail(user)));
    }

    public async Task<Result<RatingDto>> GetRating(string email)
    {
        return await _ratingRepository.GetPersonalRating(new Student(email));
    }
}
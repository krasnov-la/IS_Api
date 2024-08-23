using Application.DTO;
using Application.Interfaces.Repositories;
using Domain.Entities;
using FluentResults;

namespace Infrastructure.Repositories;

public class RatingRepository : IRatingRepository
{
    public Task<Result<List<RatingDto>>> GetGlobalRating()
    {
        throw new NotImplementedException();
    }

    public Task<Result<RatingDto>> GetPersonalRating(Student student)
    {
        throw new NotImplementedException();
    }
}
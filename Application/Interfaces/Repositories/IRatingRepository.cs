using Application.DTO;
using Domain.Entities;
using FluentResults;

namespace Application.Interfaces.Repositories;

public interface IRatingRepository
{
    Task<Result<List<RatingDto>>> GetGlobalRating(int count, int offset);
    Task<Result<RatingDto>> GetPersonalRating(Student student);
}
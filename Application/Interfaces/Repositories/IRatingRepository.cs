using Application.DTO;
using Domain.Entities;
using FluentResults;

namespace Application.Interfaces.Repositories;

public interface IRatingRepository
{
    Task<Result<List<RatingDto>>> GetGlobalRating();
    Task<Result<RatingDto>> GetPersonalRating(Student student);
}
using Application.DTO;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Domain.Enums;
using FluentResults;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repositories;

public class RatingRepository(DbContext db) : IRatingRepository
{
    private readonly DbSet<Request> _requests = db.Set<Request>();
    private readonly DbSet<User> _users = db.Set<User>();
    public async Task<Result<List<RatingDto>>> GetGlobalRating()
    {
        return Result.Ok(await GetGlobal());
    }

    public async Task<Result<RatingDto>> GetPersonalRating(Student student)
    {
        var personal_rating = (await GetGlobal()).FirstOrDefault(r => r.EmailAddress == student.EmailAddress);
        personal_rating ??= new RatingDto(0, "", student.EmailAddress, 0);
        return Result.Ok(personal_rating);
    }

    private async Task<List<RatingDto>> GetGlobal()
    {
        return (await _requests
            .Where(r => r.Status == RequestStatus.Approved)
            .GroupBy(r => r.Student)
            .Select(g => new
            {
                g.Key.EmailAddress,
                Total = g.Sum(r => r.Achievement.Score)
            })
            .OrderByDescending(r => r.Total)
            .ToListAsync())
            .Join(_users,
                r => r.EmailAddress,
                u => u.EmailAddress,
                (r, u) => new
                {
                    u.Nickname,
                    u.EmailAddress,
                    r.Total
                })
            .Select((r, i) => new RatingDto(i + 1, r.Nickname, r.EmailAddress, r.Total))
            .ToList();
    } 
}
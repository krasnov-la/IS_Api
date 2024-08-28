using Application.Errors;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Domain.Enums;
using FluentResults;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repositories;

public class RequestRepository(DbContext db) : RepositoryBase(db), IRequestRepository
{
    private readonly DbSet<Request> _requests = db.Set<Request>();
    public async Task<Result> Create(Request request)
    {
        _requests.Add(request);
        return await Save();
    }

    public async Task<Result> DeleteById(Guid id)
    {
        await _requests
            .Where(r => r.Id == id)
            .ExecuteDeleteAsync();

        return await Save();
    }

    public async Task<Result<List<Request>>> GetByEmail(string email, RequestStatus? status, int count, int offset)
    {
        if (count < 0 || offset < 0) return Result.Fail(new PaginationError());

        var query = _requests.Where(r => r.Student == new Student(email));
        if (status is not null) query = query.Where(r => r.Status == status);

        return Result.Ok(await query.Skip(offset).Take(count).ToListAsync());
    }

    public async Task<Result<Request>> GetById(Guid id)
    {
        var request = await _requests.FirstOrDefaultAsync(r => r.Id == id);
        if (request is null) return Result.Fail(new EntityNotFoundError("Request"));
        return Result.Ok(request);
    }

    public async Task<Result<List<Request>>> GetUnscored(int count, int offset)
    {
        if (count < 0 || offset < 0) return Result.Fail(new PaginationError());
        return Result.Ok(await _requests
            .Where(r => r.Status == RequestStatus.InProgress)
            .Skip(offset)
            .Take(count)
            .ToListAsync());
    }

    public async Task<Result> Update(Request request)
    {
        _requests.Update(request);
        return await Save();
    }
}
using Application.Errors.Common;
using Application.Interfaces.Repositories;
using Domain.Entities;
using FluentResults;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repositories;

public class ActivityRepository(DbContext db) : RepositoryBase(db), IActivityRepository
{
    private readonly DbSet<Activity> _activities = db.Set<Activity>();
    public async Task<Result> Create(Activity activity)
    {
        _activities.Add(activity);
        return await Save();
    }

    public async Task<Result> DeleteById(Guid id)
    {
        await _activities
            .Where(a => a.Id == id)
            .ExecuteDeleteAsync();
        return Result.Ok();
    }

    public async Task<Result<List<Activity>>> Get(int count, int offset)
    {
        var activities = await _activities
            .OrderBy(a => a.Start)
            .Skip(offset)
            .Take(count)
            .ToListAsync();

        return Result.Ok(activities);
    }

    public async Task<Result<Activity>> GetById(Guid id)
    {
        var activity = await _activities.FirstOrDefaultAsync(a => a.Id == id);
        if (activity is null) return Result.Fail(new EntityNotFoundError("Activity"));
        return Result.Ok(activity);
    }

    public async Task<Result> Update(Activity activity)
    {
        _activities.Update(activity);
        return await Save();
    }
}
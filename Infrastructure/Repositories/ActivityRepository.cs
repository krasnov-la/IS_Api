using Application.Interfaces.Repositories;
using Domain.Entities;
using FluentResults;

namespace Infrastructure.Repositories;

public class ActivityRepository : IActivityRepository
{
    public Task<Result> Create(Activity activity)
    {
        throw new NotImplementedException();
    }

    public Task<Result> DeleteById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Result<IEnumerable<Activity>>> Get(int count, int offset)
    {
        throw new NotImplementedException();
    }

    public Task<Result<Activity?>> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Result> Update(Activity activity)
    {
        throw new NotImplementedException();
    }
}
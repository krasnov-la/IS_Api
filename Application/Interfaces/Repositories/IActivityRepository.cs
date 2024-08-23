
using Domain.Entities;
using FluentResults;

namespace Application.Interfaces.Repositories;

public interface IActivityRepository
{
        Task<Result> Create(Activity activity);
        Task<Result> DeleteById(Guid id);
        Task<Result<IEnumerable<Activity>>> Get(int count, int offset);
        Task<Result<Activity?>> GetById(Guid id);
        Task<Result> Update(Activity activity);
}
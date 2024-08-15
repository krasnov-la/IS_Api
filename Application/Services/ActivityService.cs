using System.Security.Claims;
using Application.Commands;
using Application.DTO;
using Application.Interfaces.Services;
using FluentResults;

namespace Application.Services;

public class ActivityService : IActivityService
{
    public Task<Result<ActivityDto>> Create(NewActivityCommand command)
    {
        throw new NotImplementedException();
    }

    public Task<Result> Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Result<List<ActivityDto>>> GetActive()
    {
        throw new NotImplementedException();
    }

    public Task<Result<ActivityDto>> GetById(Guid id)
    {
        throw new NotImplementedException();
    }
}

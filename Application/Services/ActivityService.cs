using System.Security.Claims;
using Application.DTO;
using Application.Interfaces;
using FluentResults;

namespace Application.Services;

public class ActivityService : IActivityService
{
    public Task<Result<ActivityDto>> Create(ClaimsPrincipal user, string name, DateTime startimgDate, DateTime endingDate, string Preview, string Link)
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

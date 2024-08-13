using System.Security.Claims;
using Application.DTO;
using Application.Interfaces;
using Domain.Enums;
using FluentResults;

namespace Application.Services;

public class RequestService : IRequestService
{
    public Task<Result> Approve(ClaimsPrincipal user, Guid reqrequestId, float score)
    {
        throw new NotImplementedException();
    }

    public Task<Result<RequestDto>> Create(ClaimsPrincipal user, string eventName, string description, IEnumerable<Guid> imageIds)
    {
        throw new NotImplementedException();
    }

    public Task<Result> DeleteById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Result<RequestDto>> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Result<List<RequestDto>>> GetByLogin(string login, int count)
    {
        throw new NotImplementedException();
    }

    public Task<Result<List<RequestDto>>> GetByLogin(string login, RequestStatus status, int count)
    {
        throw new NotImplementedException();
    }

    public Task<Result<List<RequestDto>>> GetSelf(ClaimsPrincipal user, int count)
    {
        throw new NotImplementedException();
    }

    public Task<Result<List<RequestDto>>> GetSelf(ClaimsPrincipal user, RequestStatus requestStatus, int count)
    {
        throw new NotImplementedException();
    }

    public Task<Result<List<RequestDto>>> GetUnscored(int count)
    {
        throw new NotImplementedException();
    }

    public Task<Result> Reject(ClaimsPrincipal user, Guid requestId, string message)
    {
        throw new NotImplementedException();
    }

    public Task<Result> Revoke(Guid requestId)
    {
        throw new NotImplementedException();
    }
}
